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
    public partial class frmMantProveedor : System.Web.UI.Page
    {
        ProveedorDAO objProveedorDAO = new ProveedorDAO();
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
            Listar();
            this.txtId.Enabled = false;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            List<ValorDTO> objTipoUsuarioLista = objTablaDAO.ListarTipoPersona();
            this.ddlTipo.DataSource = objTipoUsuarioLista;
            this.ddlTipo.DataTextField = "Descripcion";
            this.ddlTipo.DataValueField = "Valor";
            this.ddlTipo.DataBind();
            this.ddlTipo.Items.Insert(0, new ListItem("- Seleccione -", "0"));
        }

        protected void Listar()
        {
            List<ProveedorDTO> obj;
            try
            {
                obj = objProveedorDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtRazonSocial.Text = "";
            this.txtRuc.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.txtTelefono.Text = "";
            this.txtContacto.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            ProveedorDTO obj = new ProveedorDTO();

            obj.RazonSocial = this.txtRazonSocial.Text;
            obj.Ruc = this.txtRuc.Text;
            obj.TipoPersona = ddlTipo.SelectedValue.ToString();
            obj.Direccion = this.txtDireccion.Text;
            obj.Email = this.txtEmail.Text;
            obj.Telefono = this.txtTelefono.Text;
            obj.Contacto = this.txtContacto.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";
            obj.UsuarioCreacion = "1";
            int id = objProveedorDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ProveedorDTO obj = new ProveedorDTO();

            obj = objProveedorDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.RazonSocial = this.txtRazonSocial.Text;
            obj.Ruc = this.txtRuc.Text;
            obj.TipoPersona = ddlTipo.SelectedValue.ToString();
            obj.Direccion = this.txtDireccion.Text;
            obj.Email = this.txtEmail.Text;
            obj.Telefono = this.txtTelefono.Text;
            obj.Contacto = this.txtContacto.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objProveedorDAO.Actualizar(obj);
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProveedorDTO obj;

            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objProveedorDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtRazonSocial.Text = obj.RazonSocial;
                this.txtRuc.Text = obj.Ruc;
                ddlTipo.SelectedValue = obj.TipoPersona;
                this.txtDireccion.Text = obj.Direccion;
                this.txtEmail.Text = obj.Email;
                this.txtTelefono.Text = obj.Telefono;
                this.txtContacto.Text = obj.Contacto;

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
                // this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ProveedorDTO obj = new ProveedorDTO();

            if (this.txtId.Text != "")
            {
                objProveedorDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                this.txtId.Text = "";
                this.txtRazonSocial.Text = "";
                this.txtRuc.Text = "";
                this.txtDireccion.Text = "";
                this.txtEmail.Text = "";
                this.txtTelefono.Text = "";
                this.txtContacto.Text = "";
                this.chkEstado.Checked = true;

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

        protected void gvLista_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            Listar();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Seleccionar")
            {

                ProveedorDTO obj;

                try
                {

                    foreach (ListItem li_item in this.ddlTipo.Items) li_item.Selected = false;


                    int IdProveedor = int.Parse(e.CommandArgument.ToString());

                    this.txtId.Text = IdProveedor.ToString();

                    obj = objProveedorDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                    this.txtRazonSocial.Text = obj.RazonSocial;
                    this.txtRuc.Text = obj.Ruc;

                    foreach (ListItem li_item in this.ddlTipo.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.TipoPersona)
                            li_item.Selected = true;
                    }

                    this.txtDireccion.Text = obj.Direccion;
                    this.txtEmail.Text = obj.Email;
                    this.txtTelefono.Text = obj.Telefono;
                    this.txtContacto.Text = obj.Contacto;

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
                    // this.lblMensaje.Text = err.Message.ToString();
                }
               
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ProveedorDTO> obj;
            try
            {
                string strBusqueda = txtBusqueda.Text;
                obj = objProveedorDAO.ListarBusqueda(strBusqueda);
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }
        }
 
    }
}