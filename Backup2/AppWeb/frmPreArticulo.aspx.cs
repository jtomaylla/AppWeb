﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmPreArticulo : System.Web.UI.Page
    {

        ArticuloPreDAO objArticuloDAO = new ArticuloPreDAO();
        InvClaseDAO objClaseDAO = new InvClaseDAO();
        InvFamiliaDAO objFamiliaDAO = new InvFamiliaDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();
        InvUnidadMedidaDAO objUnidadMedidaDAO = new InvUnidadMedidaDAO();
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

            //UNIDAD DE MEDIDA
            List<InvUnidadMedidaDTO> objUnidadMedidaLista = objUnidadMedidaDAO.Listar();
            this.ddlUnidad.DataSource = objUnidadMedidaLista;
            this.ddlUnidad.DataTextField = "NombreUnidadMedida";
            this.ddlUnidad.DataValueField = "IdUnidadMedida";
            this.ddlUnidad.DataBind();
            this.ddlUnidad.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            //CLASE
            List<InvClaseDTO> objClaseLista = objClaseDAO.Listar();
            this.ddlClase.DataSource = objClaseLista;
            this.ddlClase.DataTextField = "NombreClase";
            this.ddlClase.DataValueField = "IdClase";
            this.ddlClase.DataBind();
            this.ddlClase.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            //FAMILIA
            List<InvFamiliaDTO> objFamiliaLista = objFamiliaDAO.Listar();
            this.ddlFamilia.DataSource = objFamiliaLista;
            this.ddlFamilia.DataTextField = "NombreFamilia";
            this.ddlFamilia.DataValueField = "IdFamilia";
            this.ddlFamilia.DataBind();
            this.ddlFamilia.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            //PROYECTO
            List<ProyectoDTO> objProyectoLista = objProyectoDAO.Listar();
            this.ddlProyecto.DataSource = objProyectoLista;
            this.ddlProyecto.DataTextField = "NombreProyecto";
            this.ddlProyecto.DataValueField = "IdProyecto";
            this.ddlProyecto.DataBind();
            this.ddlProyecto.Items.Insert(0, new ListItem("- Seleccione -", "0"));
        }

        protected void Listar()
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            List<ArticuloPreDTO> obj;
            try
            {
                obj = objArticuloDAO.Listar();
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
            this.txtCodigoArticulo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtPrecio.Text = "";
            this.txtTiempo.Text = "";
            this.txtModelo.Text = "";
            this.txtMarca.Text = "";
            this.txtSerie.Text = "";
            this.txtLote.Text = "";
            this.txtFechaVencimiento.Text = "";

            this.chkEstado.Checked = true;
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Seleccionar")
            {
                ArticuloPreDTO obj;

                try
                {

                    foreach (ListItem li_item in this.ddlClase.Items) li_item.Selected = false;
                    foreach (ListItem li_item in this.ddlFamilia.Items) li_item.Selected = false;
                    foreach (ListItem li_item in this.ddlProyecto.Items) li_item.Selected = false;
                    foreach (ListItem li_item in this.ddlUnidad.Items) li_item.Selected = false;

                    int IdArticulo = int.Parse(e.CommandArgument.ToString());

                    this.txtId.Text = IdArticulo.ToString();
                    obj = objArticuloDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                    this.txtCodigoArticulo.Text = obj.CodigoArticulo;
                    this.txtDescripcion.Text = obj.Descripcion;

                    foreach (ListItem li_item in this.ddlClase.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdClase.ToString())
                            li_item.Selected = true;
                    }

                    foreach (ListItem li_item in this.ddlFamilia.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdFamilia.ToString())
                            li_item.Selected = true;
                    }

                    foreach (ListItem li_item in this.ddlProyecto.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdProyecto.ToString())
                            li_item.Selected = true;
                    }

                    foreach (ListItem li_item in this.ddlUnidad.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdUnidadMedida.ToString())
                            li_item.Selected = true;
                    }

                    this.txtTiempo.Text = obj.TiempoUtilMeses.ToString();
                    this.txtPrecio.Text = obj.UltimoPrecioOc.ToString();
                    this.txtMarca.Text = obj.Marca;
                    this.txtModelo.Text = obj.Modelo;

                    this.txtSerie.Text = obj.Serie;
                    this.txtLote.Text = obj.Lote;

                    if (obj.FechaVencimiento.Year == 1)
                        this.txtFechaVencimiento.Text = "";
                    else
                        this.txtFechaVencimiento.Text = obj.FechaVencimiento.ToString("dd/MM/yyyy");

                    this.txtObservaciones.Text = obj.Observaciones;
                    this.txtObservacionesAlmacenamiento.Text = obj.ObservacionesAlmacenamiento;

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
            else
                if (e.CommandName == "Eliminar")
                {

                }
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloPreDTO obj;

            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objArticuloDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtCodigoArticulo.Text = obj.CodigoArticulo;
                this.txtDescripcion.Text = obj.Descripcion;
                ddlClase.SelectedValue = obj.IdClase.ToString();
                ddlFamilia.SelectedValue = obj.IdFamilia.ToString();
                ddlProyecto.SelectedValue = obj.IdProyecto.ToString();
                this.txtTiempo.Text = obj.TiempoUtilMeses.ToString();
                this.txtPrecio.Text = obj.UltimoPrecioOc.ToString();
                this.txtMarca.Text = obj.Marca;
                this.txtModelo.Text = obj.Modelo;


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

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            ArticuloPreDTO obj = new ArticuloPreDTO();

            obj.CodigoArticulo = this.txtCodigoArticulo.Text;
            obj.IdUnidadMedida = int.Parse(this.ddlUnidad.SelectedValue);
            obj.Descripcion = this.txtDescripcion.Text;
            obj.Codigo = this.txtCodigoArticulo.Text;
            obj.IdClase = int.Parse(ddlClase.SelectedValue.ToString());
            obj.IdFamilia = int.Parse(ddlFamilia.SelectedValue.ToString());
            obj.IdProyecto = int.Parse(ddlProyecto.SelectedValue.ToString());
            obj.UltimoPrecioOc = decimal.Parse(this.txtPrecio.Text);
            obj.TiempoUtilMeses = int.Parse(this.txtTiempo.Text);
            obj.Marca = this.txtMarca.Text;
            obj.Modelo = this.txtModelo.Text;

            obj.Serie = this.txtSerie.Text;
            obj.Lote = this.txtLote.Text;

            if (this.txtFechaVencimiento.Text != "")
                obj.FechaVencimiento = AppUtilidad.stringToDateTime(this.txtFechaVencimiento.Text, "DD/MM/YYYY");

            obj.Observaciones = this.txtObservaciones.Text;
            obj.ObservacionesAlmacenamiento = this.txtObservacionesAlmacenamiento.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdUsuarioCreacion = Convert.ToInt32(this.txtIdUsuario.Text);

            int id = objArticuloDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            //this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ArticuloPreDTO obj = new ArticuloPreDTO();

            obj = objArticuloDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.CodigoArticulo = this.txtCodigoArticulo.Text;
            obj.IdUnidadMedida = int.Parse(this.ddlUnidad.SelectedValue);
            obj.Descripcion = this.txtDescripcion.Text;
            obj.Codigo = this.txtCodigoArticulo.Text;
            obj.IdClase = int.Parse(ddlClase.SelectedValue.ToString());
            obj.IdFamilia = int.Parse(ddlFamilia.SelectedValue.ToString());
            obj.IdProyecto = int.Parse(ddlProyecto.SelectedValue.ToString());
            obj.UltimoPrecioOc = decimal.Parse(this.txtPrecio.Text);
            obj.TiempoUtilMeses = int.Parse(this.txtTiempo.Text);
            obj.Modelo = this.txtModelo.Text;
            obj.Marca = this.txtMarca.Text;

            obj.Serie = this.txtSerie.Text;
            obj.Lote = this.txtLote.Text;

            if (this.txtFechaVencimiento.Text != "")
                obj.FechaVencimiento = AppUtilidad.stringToDateTime(this.txtFechaVencimiento.Text, "DD/MM/YYYY");

            obj.Observaciones = this.txtObservaciones.Text;
            obj.ObservacionesAlmacenamiento = this.txtObservacionesAlmacenamiento.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdUsuarioModificacion = Convert.ToInt32(this.txtIdUsuario.Text);

            objArticuloDAO.Actualizar(obj);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloPreDTO obj = new ArticuloPreDTO();

            if (this.txtId.Text != "")
            {
                objArticuloDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                Limpiar();

            }

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            Listar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.btnNuevo.Visible = true;
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

        protected void btnCrearArticulo_Click(object sender, EventArgs e)
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            int id = objArticuloDAO.CrearArticulo(Convert.ToInt32(this.txtId.Text), objUsuario.IdUsuario);

            this.txtId.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;

            Listar();

        }
    
    }
}