using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmIGV : System.Web.UI.Page
    {

        IgvDAO objIgvDAO = new IgvDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
            this.btnEliminar.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");

        }

        protected void InicializaPagina()
        {
            Listar();
            this.txtId.Enabled = false;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            this.txtId.Text = "";
            this.txtIGV.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaInicial.Text = "";
            this.txtFechaFinal.Text = "";


            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = false;

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtIGV.Text = "";
            this.txtDescripcion.Text = "";
            this.txtFechaInicial.Text = "";
            this.txtFechaFinal.Text = "";

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            IgvDTO obj = new IgvDTO();


            if (this.txtId.Text == "")
            {
                obj.Igv = Convert.ToDecimal(this.txtIGV.Text);
                obj.Descripcion = this.txtDescripcion.Text;

                if (this.txtFechaInicial.Text != "")
                    obj.FechaInicio = AppUtilidad.stringToDateTime(this.txtFechaInicial.Text,"DD/MM/YYYY");

                if (this.txtFechaFinal.Text != "")
                    obj.FechaFin = AppUtilidad.stringToDateTime(this.txtFechaFinal.Text, "DD/MM/YYYY");

                int id = objIgvDAO.Agregar(obj);

                this.txtId.Text = id.ToString();

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
            IgvDTO obj = new IgvDTO();

            if (this.txtId.Text != "")
            {
                objIgvDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                this.txtId.Text = "";
                this.txtIGV.Text = "";
                this.txtDescripcion.Text = "";
                this.txtFechaInicial.Text = "";
                this.txtFechaFinal.Text = "";

            }
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = false;

            Listar();
        }
        
        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Seleccionar")
            {

                IgvDTO obj = new IgvDTO();

                try
                {

                    int Id = int.Parse(e.CommandArgument.ToString());

                    this.txtId.Text = Id.ToString();
                    obj = objIgvDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                    this.txtIGV.Text = obj.Igv.ToString();
                    this.txtDescripcion.Text = obj.Descripcion;

                    if (obj.FechaInicio.Year == 1)
                        this.txtFechaInicial.Text = "";
                    else
                        this.txtFechaInicial.Text = obj.FechaInicio.ToString("dd/MM/yyyy");

                    if (obj.FechaFin.Year == 1)
                        this.txtFechaFinal.Text = "";
                    else
                        this.txtFechaFinal.Text = obj.FechaInicio.ToString("dd/MM/yyyy");

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

        protected void Listar()
        {
            List<IgvDTO> obj;
            
            try
            {
                obj = objIgvDAO.Listar();
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
            IgvDTO obj = new IgvDTO();

            obj = objIgvDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.Igv = Convert.ToDecimal(this.txtIGV.Text);
            obj.Descripcion = this.txtDescripcion.Text;

            if (this.txtFechaInicial.Text != "")
                obj.FechaInicio = AppUtilidad.stringToDateTime(this.txtFechaInicial.Text, "DD/MM/YYYY");

            if (this.txtFechaFinal.Text != "")
                obj.FechaFin = AppUtilidad.stringToDateTime(this.txtFechaFinal.Text, "DD/MM/YYYY");

            objIgvDAO.Actualizar(obj);

        }
    
    }
}