using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.seg.dal.dao;
using pe.com.seg.dal.dto;

using pe.com.rbtec.web;

namespace AppWeb.Seguridad
{
    public partial class frmUsuarioCambioClave : System.Web.UI.Page
    {
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
            this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            this.txtLoginUsuario.ReadOnly = true;
            this.txtLoginUsuario.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            if (Session["ID_USUARIO"] == null)
            {
                string LoginUsuario = HttpContext.Current.User.Identity.Name;
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

                this.txtId.Text = objUsuario.IdUsuario.ToString();
                this.txtLoginUsuario.Text = objUsuario.LoginUsuario;

                this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
                this.btnCancelar.Visible = false;

                Session.Add("ID_USUARIO", null);
            
            }
            else 
            {
                this.txtId.Text = Session["ID_USUARIO"].ToString();
                this.txtLoginUsuario.Text = Session["LOGIN_USUARIO"].ToString();

                this.btnActualizar.Attributes.Add("onclick", "return js_validar();");

                Session.Add("ID_USUARIO", null);
            
            }



        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioDTO obj = new UsuarioDTO();

            if (this.txtClave.Text != this.txtClave2.Text)
            {
                this.lblMensaje.Text = "Claves no coinciden";
                return;
            }
            obj = objUsuarioDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));
            obj.Clave = this.txtClave.Text;
            obj.FechaModificacion = DateTime.Now;
            objUsuarioDAO.ActualizarClave(obj);
            this.lblMensaje.Text = "Se actualizo la Clave de Usuario";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmUsuarioLista.aspx");
        }

    }
}