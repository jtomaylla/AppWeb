using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.sil.dal.dao;
using System.Data;

namespace AppWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
        AlertaDAO objAlertaDAO = new AlertaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //CargarTreeView();
                MenuUsuario();
                Lista();
            } 
            
        }


        protected void MenuUsuario() 
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);
            FuncionDAO objFuncionDAO = new FuncionDAO();
            PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();

            List<PerfilFuncionDTO> ListaPerfilFuncion = new List<PerfilFuncionDTO>();
            List<UsuarioPerfilDTO> ListaPerfil = objUsuarioPerfilDAO.ListarPorUsuario(objUsuario.IdUsuario);
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
        
        protected void CargarTreeView()
        {

            PerfilDAO objPerfilDAO = new PerfilDAO();
            PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();
            FuncionDAO objFuncionDAO = new FuncionDAO();

            List<PerfilDTO> ListaPerfil = new List<PerfilDTO>();
            List<PerfilFuncionDTO> ListaPerfilFuncion = new List<PerfilFuncionDTO>();

            ListaPerfil = objPerfilDAO.Listar(); 

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

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void Lista() 
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            DataTable dt = objAlertaDAO.ListarPorUsuario(objUsuario.IdUsuario);

            this.gvLista.DataSource = dt;
            this.gvLista.DataBind();


        }
    }
}
