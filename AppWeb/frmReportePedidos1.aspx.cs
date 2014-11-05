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
    public partial class frmReportePedidos1 : System.Web.UI.Page
    {

        SedeDAO objSedeDAO = new SedeDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();
        EstadoPedidoDAO objEstadoPedidoDAO = new EstadoPedidoDAO();

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
            List<EstadoPedidoDTO> ListaEstadoPedido;

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

            try
            {
                ListaEstadoPedido = objEstadoPedidoDAO.ListarPorTipo();
                this.ddlEstadoPedido.DataSource = ListaEstadoPedido;
                this.ddlEstadoPedido.DataTextField = "NombreEstado";
                this.ddlEstadoPedido.DataValueField = "Estado";
                this.ddlEstadoPedido.DataBind();
                this.ddlEstadoPedido.Items.Insert(0, new ListItem("- Seleccione -", ""));
            }
            catch (Exception err)
            {
                throw (err);
            }
            
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("rptReportePedidos1.aspx?fechainicial=" + txtFechaInicial.Text + "&fechafinal=" + txtFechaFinal.Text + "&idsede=" + ddlSede.SelectedValue + "&idproyecto=" + ddlProyecto.SelectedValue + "&idestado=" + ddlEstadoPedido.SelectedValue);
        }
    }
}