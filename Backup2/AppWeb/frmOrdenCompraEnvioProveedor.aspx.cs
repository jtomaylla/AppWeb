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
    public partial class frmOrdenCompraEnvioProveedor : System.Web.UI.Page
    {

        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            List<OrdenCompraDTO> objLista = objOrdenCompraDAO.ListarPendienteEnvioProveedor();
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdOrdenCompra = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_ORDEN_COMPRA", IdOrdenCompra);
                Response.Redirect("frmOrdenCompraLineaEnvioProveedor.aspx");
            }

        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrdenCompraDTO obj = (OrdenCompraDTO)e.Row.DataItem;

                Button btnPDF = (Button)e.Row.FindControl("btnPDF");

                //btnPDF.Attributes.Add("onclick", "return js_imprimir_oc(" + obj.IdOrdenCompra + ");");

                if (obj.EstadoAprobacion == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                {
                    btnPDF.Attributes.Add("onclick", "return js_imprimir_oc(" + obj.IdOrdenCompra + ");");
                }
                else
                {
                    btnPDF.Visible = false;
                }

            }

        }

    
    }
}