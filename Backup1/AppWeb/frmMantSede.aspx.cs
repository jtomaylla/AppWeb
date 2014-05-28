using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmMantSede : System.Web.UI.Page
    {
        SedeDAO objSedeDAO = new SedeDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnEliminar.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");
            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");

            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            Listar();
            this.txtId.Enabled = false;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
        }

        protected void Listar()
        {
            List<SedeDTO> obj;
            try
            {
                obj = objSedeDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void Limpiar()
        {
            this.txtId.Text = "";
            this.txtDescripcion.Text = "";
            this.txtDireccion.Text = "";
            this.chkEstado.Checked = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                SedeDTO obj;
                try
                {
                    int IdActivoFijo = int.Parse(e.CommandArgument.ToString());

                    this.txtId.Text = IdActivoFijo.ToString();
                    obj = objSedeDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                    this.txtDescripcion.Text = obj.NombreSede;
                    this.txtDireccion.Text = obj.Direccion;

                    if (obj.Estado == "1")
                        this.chkEstado.Checked = true;
                    else
                        this.chkEstado.Checked = false;

                    this.panRegistro.Visible = true;
                    this.panLista.Visible = false;

                    this.btnGrabar.Visible = false;
                    this.btnActualizar.Visible = true;
                    this.btnEliminar.Visible = true;
                    this.btnCancelar.Visible = true;
                }
                catch (Exception err)
                {
                    this.lblMensaje.Text = err.Message.ToString();
                }
            }
        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Listar();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SedeDTO obj = new SedeDTO();

            obj.NombreSede = txtDescripcion.Text;
            obj.Direccion = txtDireccion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            int id = objSedeDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            SedeDTO obj = new SedeDTO();

            obj = objSedeDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.NombreSede = txtDescripcion.Text;
            obj.Direccion = txtDireccion.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objSedeDAO.Actualizar(obj);

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            SedeDTO obj = new SedeDTO();

            if (this.txtId.Text != "")
            {
                objSedeDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                Limpiar();
            }

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            Listar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnNuevo.Visible = true;
            this.txtId.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            Listar();
        }


    }
}