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
    public partial class frmRecepcionInventario : System.Web.UI.Page
    {

        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        RecepcionLineaDAO objRecepcionLineaDAO = new RecepcionLineaDAO();

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
            List<RecepcionLineaDTO> objLista = objRecepcionLineaDAO.ListarPendienteDeInventariar();
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdRecepcionLinea = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_RECEPCION_LINEA", IdRecepcionLinea);
                Response.Redirect("frmRecepcionInventarioTransaccion.aspx");
            }
        }

    }
}