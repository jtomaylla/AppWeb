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

namespace AppWeb
{
    public partial class frmDespachoRecepcionLista : System.Web.UI.Page
    {

        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        RecepcionDAO objRecepcionDAO = new RecepcionDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

        }

        protected void InicializaPagina()
        {

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            //listar lineas
            List<RecepcionDTO> objRecepcionLista = objRecepcionDAO.ListarPorDespachar();
            this.gvLista.DataSource = objRecepcionLista;
            this.gvLista.DataBind();
        
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdRecepcion = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Despachar")
            {
                Session.Add("ID_RECEPCION", IdRecepcion);
                Response.Redirect("frmDespachoRecepcion.aspx");
            }
        }

    }
}