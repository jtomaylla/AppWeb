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
    public partial class frmUsuarioLista : System.Web.UI.Page
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
            Listar();
            this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            this.txtId.Text = "";
            this.txtLoginUsuario.Text = "";
            this.txtNombre.Text = "";
            this.txtClave.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            this.panPerfiles.Visible = false;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = true;
            this.btnCancelar.Visible = true;

            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            UsuarioDTO obj = new UsuarioDTO();

            if (txtId.Text == "")
            {
                obj.LoginUsuario = this.txtLoginUsuario.Text;
                obj.Clave = this.txtClave.Text;
                obj.NombreUsuario = this.txtNombre.Text;
                if (this.chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";
                obj.Email = this.txtEmail.Text;
                obj.FechaCreacion = DateTime.Now;
                obj.FechaModificacion = DateTime.Now;
                int id = objUsuarioDAO.Agregar(obj);
                this.txtId.Text = id.ToString();
                this.lblMensaje.Text = "Se registro el Usuario";

                this.panRegistro.Visible = true;
                this.panLista.Visible = false;
                this.panPerfiles.Visible = true;

                this.btnGrabar.Visible = false;
                this.btnActualizar.Visible = true;
                this.btnEliminar.Visible = true;
                this.btnCancelar.Visible = true;

                //LISTAR PERFILES
                ListarPerfiles(id);
            }


        }

        protected void Listar()
        {
            List<UsuarioDTO> obj;
            UsuarioDAO objDAO = new UsuarioDAO();

            try
            {
                obj = objDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();

            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void ListarPerfiles(int idUsuario)
        {
            List<PerfilDTO> objPerfil;
            UsuarioPerfilDTO objUsuarioPerfilDTO;

            PerfilDAO objPerfilDAO = new PerfilDAO();
            
            UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();
            try
            {
                //CARGAR PERFILES
                tvwPerfiles.Nodes.Clear();
                objPerfil = objPerfilDAO.Listar();
                foreach (PerfilDTO perfil in objPerfil)
                {
                    if (perfil.Estado.Equals("1"))
                    {
                        TreeNode nodo1 = new TreeNode((string)perfil.NombrePerfil);
                        nodo1.Value = perfil.IdPerfil.ToString();
                        tvwPerfiles.Nodes.Add(nodo1);
                        //VERIFICAR SI USUARIO TIENE PERFIL ASIGNADO
                        int idPerfil = perfil.IdPerfil;
                        objUsuarioPerfilDTO = objUsuarioPerfilDAO.ListarPorClave(idUsuario, idPerfil);
                        if (objUsuarioPerfilDTO.IdPerfil > 0)
                            nodo1.Checked = true;
                    }
                }
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioDTO obj;
            try
            {
                //this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                //int idUsuario = Convert.ToInt32(this.txtId.Text);
                //obj = objUsuarioDAO.ListarPorClave(idUsuario);

                //this.txtNombre.Text = obj.NombreUsuario ;
                //this.txtLoginUsuario.Text = obj.LoginUsuario;
                //this.txtClave.Text = obj.Clave;
                //this.txtClave.Visible = false;
                //if (obj.Estado == "1") 
                //    this.chkEstado.Checked = true; 
                //else
                //    this.chkEstado.Checked = false;

                //this.panRegistro.Visible = true;
                //this.panLista.Visible = false;
                //this.panPerfiles.Visible = true;

                //this.btnGrabar.Visible = false;
                //this.btnActualizar.Visible = true;
                //this.btnEliminar.Visible = true;
                //this.btnCancelar.Visible = true;

                ////CARGAR PERFILES
                //ListarPerfiles(idUsuario);

            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtLoginUsuario.Text = "";
            this.txtNombre.Text = "";
            this.txtClave.Text = "";
            this.txtEmail.Text = "";
            this.chkEstado.Checked = true;
            this.txtClave.Enabled = true;

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioDTO obj = new UsuarioDTO();

            obj = objUsuarioDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));
            obj.LoginUsuario = this.txtLoginUsuario.Text;
            //obj.Clave = this.txtClave.Text;
            obj.NombreUsuario = this.txtNombre.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";
            obj.Email = this.txtEmail.Text;
            obj.FechaModificacion = DateTime.Now;
            objUsuarioDAO.Actualizar(obj);
            this.lblMensaje.Text = "Se actualizo el Usuario";

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtLoginUsuario.Text = "";
            this.txtNombre.Text = "";
            this.txtClave.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            this.panPerfiles.Visible = false;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;

            Listar();

        }

        protected void btnGrabarPerfil_Click(object sender, EventArgs e)
        {
            UsuarioPerfilDTO objUsuarioPerfilDTO;
            UsuarioPerfilDAO objUsuarioPerfilDAO = new UsuarioPerfilDAO();

            int idUsuario = Convert.ToInt32(this.txtId.Text);
            for (int i = 0; i < tvwPerfiles.Nodes.Count; i++)
            {
                TreeNode nodo1 = tvwPerfiles.Nodes[i];
                int idPerfil = int.Parse(nodo1.Value);
                if (nodo1.Checked)
                {
                    objUsuarioPerfilDTO = objUsuarioPerfilDAO.ListarPorClave(idUsuario, idPerfil);
                    if (objUsuarioPerfilDTO.IdPerfil == 0)
                    {
                        UsuarioPerfilDTO objUsuarioPerfil = new UsuarioPerfilDTO();
                        objUsuarioPerfil.IdUsuario = idUsuario;
                        objUsuarioPerfil.IdPerfil = idPerfil;
                        objUsuarioPerfilDAO.Agregar(objUsuarioPerfil);
                    }
                }
                else
                {
                    UsuarioPerfilDTO objUsuarioPerfil = new UsuarioPerfilDTO();
                    objUsuarioPerfil.IdUsuario = idUsuario;
                    objUsuarioPerfil.IdPerfil = idPerfil;
                    objUsuarioPerfilDAO.Eliminar(objUsuarioPerfil);
                }
            }
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UsuarioDTO usuario = (UsuarioDTO)e.Row.DataItem;
                ImageButton imgSelect = (ImageButton)e.Row.FindControl("imgSelect");
                imgSelect.CommandArgument = usuario.IdUsuario.ToString();

                ImageButton imgCambioClave = (ImageButton)e.Row.FindControl("imgCambioClave");
                imgCambioClave.CommandArgument = usuario.IdUsuario.ToString() + "|" + usuario.LoginUsuario;
            }
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    this.txtId.Text = e.CommandArgument.ToString();
                    int idUsuario = Convert.ToInt32(this.txtId.Text);
                    UsuarioDTO obj = objUsuarioDAO.ListarPorClave(idUsuario);

                    this.txtNombre.Text = obj.NombreUsuario ;
                    this.txtLoginUsuario.Text = obj.LoginUsuario;
                    this.txtClave.Text = obj.Clave;
                    this.txtClave.Enabled = false;
                    if (obj.Estado == "1") 
                        this.chkEstado.Checked = true; 
                    else
                        this.chkEstado.Checked = false;
                    this.txtEmail.Text = obj.Email;

                    this.panRegistro.Visible = true;
                    this.panLista.Visible = false;
                    this.panPerfiles.Visible = true;

                    this.btnGrabar.Visible = false;
                    this.btnActualizar.Visible = true;
                    this.btnEliminar.Visible = true;
                    this.btnCancelar.Visible = true;

                    //CARGAR PERFILES
                    ListarPerfiles(idUsuario);
                    break;
                case "CambiarClave":
                    String argumentos = e.CommandArgument.ToString();
                    String strCaracter = "|";
                    char chrCaracter = strCaracter[0];
                    String[] args = argumentos.Split(chrCaracter);
                    Session["ID_USUARIO"] = args[0];
                    Session["LOGIN_USUARIO"] = args[1];
                    Response.Redirect("frmUsuarioCambioClave.aspx");
                    break;
            }
        }

        

    }
}