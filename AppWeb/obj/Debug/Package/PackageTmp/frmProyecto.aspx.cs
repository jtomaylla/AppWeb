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
    public partial class frmProyecto : System.Web.UI.Page
    {
        ProyectoDAO objProyectoDAO = new ProyectoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnEliminar.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");
            this.btnAsignarUsuario.Attributes.Add("onclick", "return js_validar_asignacion();");
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

            List<UsuarioDTO> objUsuarioLista = objUsuarioDAO.Listar();

            this.ddlUsuario.DataSource = objUsuarioLista;
            this.ddlUsuario.DataTextField = "NombreUsuario";
            this.ddlUsuario.DataValueField = "IdUsuario";
            this.ddlUsuario.DataBind();
            this.ddlUsuario.Items.Insert(0, new ListItem("- Seleccione -", "0"));


            List<ValorDTO> objTipoUsuarioLista = objTablaDAO.ListarTipoUsuarioProyecto();
            this.ddlTipo.DataSource = objTipoUsuarioLista;
            this.ddlTipo.DataTextField = "Descripcion";
            this.ddlTipo.DataValueField = "Valor";
            this.ddlTipo.DataBind();
            this.ddlTipo.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            //ListarUsuarioProyecto

            //objUsuarioDAO.ListarUsuarioProyecto
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            ProyectoDTO obj = new ProyectoDTO();

            obj.NombreProyecto = this.txtNombre.Text;
            obj.NombreCorto = this.txtNombreCorto.Text;

            if (this.chkEstado.Checked)
               obj.Estado = "1";
            else
               obj.Estado = "0";

            int id = objProyectoDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
            this.panUsuario.Visible = true;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            Listar();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
            this.panUsuario.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible =  false;
            this.btnCancelar.Visible = true;
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ProyectoDTO obj = new ProyectoDTO();

            obj = objProyectoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));
            obj.NombreProyecto = this.txtNombre.Text;
            obj.NombreCorto = this.txtNombreCorto.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objProyectoDAO.Actualizar(obj);

        }
        
        protected void Listar()
        {
            List<ProyectoDTO> obj;
            try
            {
                obj = objProyectoDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            ProyectoDTO obj = new ProyectoDTO();
            
            if (this.txtId.Text != "")
            {

                int count = objProyectoDAO.CountPedidos(Convert.ToInt32(this.txtId.Text));
                
                if (count == 0) {
                    objProyectoDAO.Eliminar(Convert.ToInt32(this.txtId.Text));
                    this.txtId.Text = "";
                    this.txtNombre.Text = "";
                    this.chkEstado.Checked = true;
                    this.panRegistro.Visible = false;
                    this.panLista.Visible = true;
                    Listar();
                }
                else
                {
                    this.lblMensaje.Text = "No se puede eliminar el registro, proyecto tiene pedidos asociados";
                }

            }

        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProyectoDTO obj;

            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objProyectoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtNombre.Text = obj.NombreProyecto;
                this.txtNombreCorto.Text = obj.NombreCorto;
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

                List<UsuarioProyectoDTO> ListaUsuarioProyecto = objUsuarioDAO.ListarUsuarioProyecto(obj.IdProyecto);
                gvUsuario.DataSource = ListaUsuarioProyecto;
                gvUsuario.DataBind();



            }
            catch (Exception err)
            {
               // this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void gvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DataRowView row = (DataRowView)e.Row.DataItem;
                UsuarioProyectoDTO row = (UsuarioProyectoDTO)e.Row.DataItem;
                DropDownList ddlTipoGridView = (DropDownList)e.Row.FindControl("ddlTipoGridView");

                List<ValorDTO> objTipoUsuarioLista = objTablaDAO.ListarTipoUsuarioProyecto();
                ddlTipoGridView.DataSource = objTipoUsuarioLista;
                ddlTipoGridView.DataTextField = "Descripcion";
                ddlTipoGridView.DataValueField = "Valor";
                ddlTipoGridView.DataBind();
                ddlTipoGridView.Items.Insert(0, new ListItem("- Seleccione -", "0"));

                foreach (ListItem li_item in ddlTipoGridView.Items)
                {
                    if (Convert.ToString(li_item.Value) == row.Tipo)
                        li_item.Selected = true;
                }

            }
        }

        protected void btnAsignarUsuario_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            try 
            {

                UsuarioProyectoDTO obj = new UsuarioProyectoDTO();

                obj.IdUsuario = Convert.ToInt32(this.ddlUsuario.SelectedValue);
                obj.IdProyecto = Convert.ToInt32(this.txtId.Text);
                obj.Estado = "1";
                obj.Tipo = this.ddlTipo.SelectedValue;

                objUsuarioDAO.UsuarioProyectoAgregar(obj);
                //Listar
                List<UsuarioProyectoDTO> ListaUsuarioProyecto = objUsuarioDAO.ListarUsuarioProyecto(obj.IdProyecto);
                gvUsuario.DataSource = ListaUsuarioProyecto;
                gvUsuario.DataBind();
            
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnActualizarGridView_Click(object sender, EventArgs e)
        {
            UsuarioProyectoDTO obj = new UsuarioProyectoDTO();

            foreach (GridViewRow row in this.gvUsuario.Rows)
            {
                string IdProyecto = gvUsuario.DataKeys[row.RowIndex].Values[0].ToString();
                string IdUsuario = gvUsuario.DataKeys[row.RowIndex].Values[1].ToString();

                CheckBox chkEstado = (CheckBox)row.Cells[2].FindControl("chkEstadoGridView");
                DropDownList ddlTipo = (DropDownList)row.Cells[2].FindControl("ddlTipoGridView");

                obj.IdProyecto = Convert.ToInt32(IdProyecto);

                obj.IdUsuario = Convert.ToInt32(IdUsuario);
                
                if (chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";

                obj.Tipo = ddlTipo.SelectedValue;

                objUsuarioDAO.UsuarioProyectoActualizar(obj);

            }

        }

    }
}