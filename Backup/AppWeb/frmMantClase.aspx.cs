﻿using System;
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
    public partial class frmMantClase : System.Web.UI.Page
    {
        InvClaseDAO objInvClaseDAO = new InvClaseDAO();
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

        }

        protected void Listar()
        {
            List<InvClaseDTO> obj;
            try
            {
                obj = objInvClaseDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvClaseDTO obj;

            try
            {
                this.txtId.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objInvClaseDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                this.txtCodigo.Text = obj.CodClase;
                this.txtDescripcion.Text = obj.NombreClase;

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
            this.txtId.Text = "";
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            InvClaseDTO obj = new InvClaseDTO();

            obj.CodClase = this.txtCodigo.Text;
            obj.NombreClase = this.txtDescripcion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";
            int id = objInvClaseDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            InvClaseDTO obj = new InvClaseDTO();

            obj = objInvClaseDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.CodClase = this.txtCodigo.Text;
            obj.NombreClase = this.txtDescripcion.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objInvClaseDAO.Actualizar(obj);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            InvClaseDTO obj = new InvClaseDTO();

            if (this.txtId.Text != "")
            {
                objInvClaseDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

                this.txtId.Text = "";
                this.txtCodigo.Text = "";
                this.txtDescripcion.Text = "";
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
    }
}