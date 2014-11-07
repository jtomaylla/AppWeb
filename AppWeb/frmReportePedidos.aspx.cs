using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AppWeb.Reporte;
using pe.com.sil.dal.dao;
using pe.com.sil.dal.dto;

using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmReportePedidos : System.Web.UI.Page
    {

        SedeDAO objSedeDAO = new SedeDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnReporte.Attributes.Add("onclick", "return js_validar();");
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            this.ddlSede.Items.Clear();

            List<SedeDTO> ListaSede;
            List<ProyectoDTO> ListaProyecto;

            try
            {
                ListaSede =  objSedeDAO.Listar();
                this.ddlSede.DataSource = ListaSede;
                this.ddlSede.DataTextField = "NombreSede";
                this.ddlSede.DataValueField = "IdSede";
                this.ddlSede.DataBind();
                this.ddlSede.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }

            try
            {
                ListaProyecto = objProyectoDAO.Listar();
                this.ddlProyecto.DataSource = ListaProyecto;
                this.ddlProyecto.DataTextField = "NombreProyecto";
                this.ddlProyecto.DataValueField = "IdProyecto";
                this.ddlProyecto.DataBind();
                this.ddlProyecto.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }
            
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            PedidoDAO objPedidoDAO = new PedidoDAO();
            ParametroDAO objParametroDAO  = new ParametroDAO();
            ParametroDTO objParametroDTO = objParametroDAO.ListarPorClave(1);
            dsReportes dsReporte = new dsReportes();
            
            List<PedidoDTO> Lista = objPedidoDAO.ListarReporte(AppUtilidad.stringToDateTime(this.txtFechaInicial.Text, "DD/MM/YYYY"),
                                                   AppUtilidad.stringToDateTime(this.txtFechaFinal.Text, "DD/MM/YYYY"),
                                                   Convert.ToInt32(this.ddlSede.SelectedValue),
                                                   Convert.ToInt32(this.ddlProyecto.SelectedValue));

            this.lblMensaje.Text = "";

            if (Lista.Count > 0)
            {
                dsReportes.ParametroRow drParametroRow = dsReporte.Parametro.NewParametroRow();

                drParametroRow.id_reporte = 1;
                drParametroRow.titulo1 = "REPORTE DE SOLICITUDES DE PEDIDOS DE COMPRA";
                drParametroRow.titulo2 = "Desde " + this.txtFechaInicial.Text + " al " + this.txtFechaFinal.Text;
                drParametroRow.empresa = objParametroDTO.RazonSocial;
                dsReporte.Parametro.AddParametroRow(drParametroRow);

                foreach (PedidoDTO reg in Lista)
                {
                    dsReportes.PedidoRow drPedidoRow = dsReporte.Pedido.NewPedidoRow();

                    drPedidoRow.id_reporte = 1;
                    drPedidoRow.id_pedido = reg.IdPedido;
                    drPedidoRow.fecha = reg.FechaPedido.ToString("dd/MM/yyyy");
                    drPedidoRow.descripcion = reg.Descripcion;
                    drPedidoRow.sede = reg.NombreSede;
                    drPedidoRow.proyecto = reg.NombreProyecto;
                    drPedidoRow.estado_aprobacion = reg.NombreEstado;
                    drPedidoRow.estado_control = reg.NombreEstadoControl;
                    drPedidoRow.solicitante = reg.NombreSolicitante;
                    drPedidoRow.orden_compra = reg.OrdenCompra;
                    drPedidoRow.tipo_pedido = reg.NombreTipoPedido;

                    dsReporte.Pedido.AddPedidoRow(drPedidoRow);
                }

                CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
                myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                string strRuta = Server.MapPath("rptPedido.rpt");
                myReportDocument.Load(strRuta);
                myReportDocument.SetDataSource(dsReporte);
                Session.Add("ReporteCrystal", myReportDocument);
                Session.Add("FormatoReporte", "PDF");

                string strRutaWeb = Request.ApplicationPath;

                Response.Write("<script language='javascript'>window.open('ReportePedido.aspx" + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");
            }
            else
            {
                this.lblMensaje.Text = "Noy registros con los parametros indicados";
            }

        }
    }
}