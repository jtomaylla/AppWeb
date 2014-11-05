using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;


namespace AppWeb
{
    public partial class frmPedidoConsulta : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnCodigoPresupuesto.Attributes.Add("onclick", "return js_codigo_presupuesto();");

        }

        protected void InicializaPagina()
        {

            this.txtIdPedido.ReadOnly = true;
            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            if (Session["ID_PEDIDO_CONSULTA"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            PedidoDTO objPedidoDTO = null;
            int IdPedido = 0;

            IdPedido = Convert.ToInt32(Session["ID_PEDIDO_CONSULTA"]);
            
            if (IdPedido > 0)
            {
                objPedidoDTO = objPedidoDAO.ListarPorClave(IdPedido);
                if (objPedidoDTO != null)
                {

                    this.txtIdPedido.Text = objPedidoDTO.IdPedido.ToString();
                    this.lblTipoPedido.Text = objPedidoDTO.NombreTipoPedido;
                    this.lblFechaPedido.Text = objPedidoDTO.FechaPedido.ToString("dd/MM/yyyy");
                    this.lblDescripcionPedido.Text = objPedidoDTO.Descripcion;
                    this.lblProyecto.Text = objPedidoDTO.NombreProyecto;
                    this.lblSede.Text = objPedidoDTO.NombreSede;
                    this.lblMoneda.Text = objPedidoDTO.NombreMoneda;
                    this.lblNombreSolicitante.Text = objPedidoDTO.NombreSolicitante.ToString();

                    this.lblEstado.Text = objPedidoDTO.NombreEstado;
                    this.lblEstadoControl.Text = objPedidoDTO.NombreEstadoControl;

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                }

            }
        }


    }
}