using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//test
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.sil.dal.dao;

namespace AppWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        //test
        UsuarioDAO mobjUsuarioDAO = new UsuarioDAO();
        UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
        AlertaDAO objAlertaDAO = new AlertaDAO();
        //test
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //CargarTreeView();
                string LoginUsuario = HttpContext.Current.User.Identity.Name;
                //TreeView1.Visible = false;
                MenuContent.Visible = false;
                if (LoginUsuario != "")
                {
                    //TreeView1.Visible = true;
                    MenuContent.Visible = true;
                    MenuUsuario();
                }
            } 
        }
        //test
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
        protected void MenuUsuario()
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO mobjUsuario = mobjUsuarioDAO.ListarPorLogin(LoginUsuario);
            FuncionDAO objFuncionDAO = new FuncionDAO();
            PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();

            List<PerfilFuncionDTO> ListaPerfilFuncion = new List<PerfilFuncionDTO>();
            List<UsuarioPerfilDTO> ListaPerfil = objUsuarioPerfilDAO.ListarPorUsuario(mobjUsuario.IdUsuario);
            for (int i = 0; i < ListaPerfil.Count; i++)
            {

                TreeNode ParentNode = new TreeNode();
                ParentNode.Text = ListaPerfil[i].NombrePerfil;
                ParentNode.Value = ListaPerfil[i].IdPerfil.ToString();
                TreeView1.Nodes.Add(ParentNode);

                ListaPerfilFuncion = objPerfilFuncionDAO.ListarPorPerfil(ListaPerfil[i].IdPerfil);

                for (int j = 0; j < ListaPerfilFuncion.Count; j++)
                {
                    FuncionDTO objFuncion = objFuncionDAO.ListarPorClave(ListaPerfilFuncion[j].IdFuncion);
                    TreeNode ChildNode = new TreeNode();
                    ChildNode.Text = objFuncion.NombreFuncion;
                    ChildNode.Value = objFuncion.IdFuncion.ToString();
                    ChildNode.NavigateUrl = objFuncion.Funcion;
                    ParentNode.ChildNodes.Add(ChildNode);
                }
            }

        }
        //test
    }
}
