using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;

namespace AppWeb.Seguridad
{
    public partial class frmFuncionLista : System.Web.UI.Page
    {
        FuncionDAO objFuncionDAO = new FuncionDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            this.btnEliminar.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");

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

            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtFuncion.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = false;

            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtFuncion.Text = "";
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
            FuncionDTO obj = new FuncionDTO();


            if (this.txtId.Text == "")
            {
                obj.NombreFuncion = this.txtNombre.Text;
                obj.Funcion = this.txtFuncion.Text;   
                if (this.chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";

                int id = objFuncionDAO.Agregar(obj);

                this.txtId.Text = id.ToString();
                //this.lblMensaje.Text = "Se registro el Usuario";

                this.panRegistro.Visible = true;
                this.panLista.Visible = false;

                this.btnGrabar.Visible = false;
                this.btnActualizar.Visible = true;
                this.btnEliminar.Visible = true;
                this.btnCancelar.Visible = true;

             }

            
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            FuncionDTO obj = new FuncionDTO();
 
            if (this.txtId.Text != "")
            {
                objFuncionDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                this.txtId.Text = "";
                this.txtNombre.Text  = "";
                this.txtFuncion.Text = "";
                this.chkEstado.Checked = true;

            }
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            
            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = false;

            Listar();
         }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

            FuncionDTO obj;
            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objFuncionDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtNombre.Text = obj.NombreFuncion;
                this.txtFuncion.Text = obj.Funcion; 
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

        protected void Listar()
        {
            List<FuncionDTO> obj;
            FuncionDAO objDAO = new FuncionDAO();
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = false;

            Listar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            FuncionDTO obj = new FuncionDTO();

            obj = objFuncionDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.NombreFuncion = this.txtNombre.Text;
            obj.Funcion = this.txtFuncion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objFuncionDAO.Actualizar(obj);

        }

    }
}