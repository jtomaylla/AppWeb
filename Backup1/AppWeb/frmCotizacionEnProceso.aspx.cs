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
    public partial class frmCotizacionEnProceso : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        CotizacionDAO objCotizacionDAO = new CotizacionDAO();

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

            //Lista
            List<CotizacionDTO> Lista = objCotizacionDAO.ListarEnProceso();
            this.gvCotizaciones.DataSource = Lista;
            this.gvCotizaciones.DataBind();

        }

        protected void gvCotizaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdCotizacion = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_COTIZACION", IdCotizacion);
                Response.Redirect("frmCotizacion.aspx");
                
            }
        }


    }
}