using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmGuiaRemisionPendienteLista : System.Web.UI.Page
    {
        DespachoDAO objDespachoDAO = new DespachoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            List<DespachoDTO> ListaDespachoDTO = objDespachoDAO.ListarPendienteGuia();
            this.gvLista.DataSource = ListaDespachoDTO;
            this.gvLista.DataBind();

        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdDespacho = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_DESPACHO_PENDIENTE_GUIA", IdDespacho);
                Response.Redirect("frmGuiaRemisionPendiente.aspx");
            }


        }

    }
}