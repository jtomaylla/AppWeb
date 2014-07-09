using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
//test
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.sil.dal.dao;
namespace AppWeb.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e) 
        {
            UsuarioDTO objUsuarioDTO;
            UsuarioDAO objUsuarioDAO = new UsuarioDAO();
            
            objUsuarioDTO = objUsuarioDAO.VerificaAcceso(this.LoginUser.UserName, this.LoginUser.Password);
            if (objUsuarioDTO != null)
            {
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, LoginUser.RememberMeSet);
                Response.Redirect("~/Default.aspx");

            }
            else
            {
                
            
            }
            
        }
    }
}
