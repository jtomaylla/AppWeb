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
    public partial class frmPatrimonio : System.Web.UI.Page
    {

        ActivoFijoDAO objActivoFijoDAO = new ActivoFijoDAO();
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
            List<ActivoFijoDTO> obj;
            try
            {
                obj = objActivoFijoDAO.Listar();
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
            this.txtCodigo.Text = "";
            this.txtObservacion1.Text = "";
            this.txtDescripcion.Text = "";
            this.txtMarca.Text = "";
            this.txtModelo.Text = "";
            this.txtSerie.Text = "";
            this.txtLocalOrigen.Text = "";
            this.txtUbicacion.Text = "";
            this.txtAreaProyecto.Text = "";
            this.txtUsuarioAsignacion.Text = "";
            this.txtFactura.Text = "";
            this.txtProveedor.Text = "";
            this.txtRuc.Text = "";
            this.txtPrecioSoles.Text = "";
            this.txtPrecioDolares.Text = "";
            this.txtObservacion2.Text = "";
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
                ActivoFijoDTO obj;
                try
                {
                    int IdActivoFijo = int.Parse(e.CommandArgument.ToString());

                    this.txtId.Text = IdActivoFijo.ToString();
                    obj = objActivoFijoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                    this.txtCodigo.Text = obj.Codigo;
                    this.txtObservacion1.Text = obj.Observacion1;
                    this.txtDescripcion.Text = obj.Descripcion;
                    this.txtMarca.Text = obj.Marca;
                    this.txtModelo.Text = obj.Modelo;
                    this.txtSerie.Text = obj.Serie;
                    this.txtLocalOrigen.Text = obj.LocalOrigen;
                    this.txtUbicacion.Text = obj.Ubicacion;
                    this.txtAreaProyecto.Text = obj.AreaProyecto;
                    this.txtUsuarioAsignacion.Text = obj.UsuarioAsignacion;
                    this.txtFactura.Text = obj.Factura;
                    this.txtProveedor.Text = obj.Proveedor;
                    this.txtRuc.Text = obj.RucProveedor;
                    this.txtPrecioSoles.Text = obj.PrecioSoles.ToString();
                    this.txtPrecioDolares.Text = obj.PrecioDolares.ToString();
                    this.txtObservacion2.Text = obj.Observacion2;

                    if (obj.FechaBaja.Year == 1)
                        this.txtFechaBaja.Text = "";
                    else
                        this.txtFechaBaja.Text = obj.FechaBaja.ToString("dd/MM/yyyy");

                    if (obj.FechaFactura.Year == 1)
                        this.txtFechaFactura.Text = "";
                    else
                        this.txtFechaFactura.Text = obj.FechaFactura.ToString("dd/MM/yyyy");

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

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            ActivoFijoDTO obj = new ActivoFijoDTO();

            obj.Codigo = txtCodigo.Text;
            obj.Observacion1 = txtObservacion1.Text;
            
            if (this.txtFechaBaja.Text != "")
                obj.FechaBaja = AppUtilidad.stringToDateTime(this.txtFechaBaja.Text, "DD/MM/YYYY");
            
            obj.Descripcion = txtDescripcion.Text;
            obj.Marca = txtMarca.Text;
            obj.Modelo = txtModelo.Text;
            obj.Serie = txtSerie.Text;
            obj.Factura = txtFactura.Text;
            
            if (this.txtFechaFactura.Text != "")
                obj.FechaFactura = AppUtilidad.stringToDateTime(this.txtFechaFactura.Text, "DD/MM/YYYY");

            obj.Proveedor = txtProveedor.Text;
            obj.RucProveedor = txtRuc.Text;

            if (this.txtPrecioSoles.Text.Length > 0)
                obj.PrecioSoles = decimal.Parse(this.txtPrecioSoles.Text);

            if (this.txtPrecioDolares.Text.Length > 0)
                obj.PrecioDolares = decimal.Parse(this.txtPrecioDolares.Text);

            obj.Observacion2 = txtObservacion2.Text;
            obj.LocalOrigen = txtLocalOrigen.Text;
            obj.Ubicacion = txtUbicacion.Text;
            obj.AreaProyecto = txtAreaProyecto.Text;
            obj.UsuarioAsignacion = txtUsuarioAsignacion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;

            int id =  objActivoFijoDAO.Agregar(obj);

            this.txtId.Text = id.ToString();

            this.btnNuevo.Visible = false;
            this.btnActualizar.Visible = true;
            this.btnEliminar.Visible = true;
            this.panRegistro.Visible = true;
            this.panLista.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            ActivoFijoDTO obj = new ActivoFijoDTO();

            obj = objActivoFijoDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

            obj.Codigo = txtCodigo.Text;
            obj.Observacion1 = txtObservacion1.Text;
            
            if (this.txtFechaBaja.Text != "")
                obj.FechaBaja = AppUtilidad.stringToDateTime(this.txtFechaBaja.Text, "DD/MM/YYYY");
            
            obj.Descripcion = txtDescripcion.Text;
            obj.Marca = txtMarca.Text;
            obj.Modelo = txtModelo.Text;
            obj.Serie = txtSerie.Text;
            obj.Factura = txtFactura.Text;
            
            if (this.txtFechaFactura.Text != "")
                obj.FechaFactura = AppUtilidad.stringToDateTime(this.txtFechaFactura.Text, "DD/MM/YYYY");

            obj.Proveedor = txtProveedor.Text;
            obj.RucProveedor = txtRuc.Text;

            if (this.txtPrecioSoles.Text.Length > 0)
                obj.PrecioSoles = decimal.Parse(this.txtPrecioSoles.Text);

            if (this.txtPrecioDolares.Text.Length > 0)
                obj.PrecioDolares = decimal.Parse(this.txtPrecioDolares.Text);


            obj.Observacion2 = txtObservacion2.Text;
            obj.LocalOrigen = txtLocalOrigen.Text;
            obj.Ubicacion = txtUbicacion.Text;
            obj.AreaProyecto = txtAreaProyecto.Text;
            obj.UsuarioAsignacion = txtUsuarioAsignacion.Text;

            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            obj.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;

            objActivoFijoDAO.Actualizar(obj);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ActivoFijoDTO obj = new ActivoFijoDTO();

            if (this.txtId.Text != "")
            {
                objActivoFijoDAO.Eliminar(Convert.ToInt32(this.txtId.Text));

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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ActivoFijoDTO> obj;
            try
            {
                string strBusqueda = txtBusqueda.Text;
                obj = objActivoFijoDAO.ListarBusqueda(strBusqueda);
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