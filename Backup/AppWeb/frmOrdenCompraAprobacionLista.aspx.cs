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
    public partial class frmOrdenCompraAprobacionLista : System.Web.UI.Page
    {
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            List<OrdenCompraDTO> objLista = objOrdenCompraDAO.ListarAprobacionPendiente(objUsuarioDTO.IdUsuario);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdOrdenCompra = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_ORDEN_COMPRA_APROBACION", IdOrdenCompra);
                Response.Redirect("frmOrdenCompraAprobacion.aspx");
            }

        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrdenCompraDTO obj = (OrdenCompraDTO)e.Row.DataItem;

            }

        }

    
    }
}