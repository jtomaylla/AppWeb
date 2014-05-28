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
    public partial class frmMovimientoInventario : System.Web.UI.Page
    {
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        InvAlmacenDAO objAlmacenDAO = new InvAlmacenDAO();
        InvTipoTransaccionDAO objTipoTransaccionDAO = new InvTipoTransaccionDAO();
        InvTransaccionDAO objTransaccionDAO = new InvTransaccionDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        ParametroDAO objParametroDAO = new ParametroDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();
        DespachoDAO objDespachoDAO = new DespachoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnBuscar.Attributes.Add("onclick", "return js_validar_busqueda();");
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            ParametroDTO objParametroDTO =  objParametroDAO.ListarPorClave(AppConstantes.ID_PARAMETRO);

            this.txtId.Enabled = false;
            this.txtId.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            pnlBusqueda.Visible = false;
            pnlRegistro.Visible = true;

            //ALMACEN
            //List<InvAlmacenDTO> objAlmacenLista = objAlmacenDAO.Listar();
            //this.ddlAlmacen.DataSource = objAlmacenLista;
            //this.ddlAlmacen.DataTextField = "NombreAlmacen";
            //this.ddlAlmacen.DataValueField = "IdAlmacen";
            //this.ddlAlmacen.DataBind();
            //this.ddlAlmacen.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            //if (objParametroDTO.IdAlmacen > 0)
            //    foreach (ListItem li_item in this.ddlAlmacen.Items)
            //    {
            //        if (Convert.ToString(li_item.Value) == objParametroDTO.IdAlmacen.ToString())
            //            li_item.Selected = true;
            //    }


            List<ProyectoDTO> ListaProyectoDTO;

            try
            {
                ListaProyectoDTO = objProyectoDAO.ListarOrdenPorNombre();
                this.ddlProyecto.DataSource = ListaProyectoDTO;
                this.ddlProyecto.DataTextField = "NombreProyecto";
                this.ddlProyecto.DataValueField = "IdProyecto";
                this.ddlProyecto.DataBind();
                this.ddlProyecto.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }
            //objParametroDTO.IdAlmacen

            //TIPO TRANSACCION
            List<InvTipoTransaccionDTO> objTipoTransaccionLista = objTipoTransaccionDAO.Listar();
            this.ddlTipoTransaccion.DataSource = objTipoTransaccionLista;
            this.ddlTipoTransaccion.DataTextField = "NombreTransaccion";
            this.ddlTipoTransaccion.DataValueField = "IdTipoTransaccion";
            this.ddlTipoTransaccion.DataBind();
            this.ddlTipoTransaccion.Items.Insert(0, new ListItem("- Seleccione -", "0"));

            this.txtFechaTransaccion.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            
            InvTransaccionDTO transaccionDTO = new InvTransaccionDTO();
            transaccionDTO.IdProyecto = int.Parse(this.ddlProyecto.SelectedValue.ToString());
            transaccionDTO.IdTipoTransaccion = int.Parse(ddlTipoTransaccion.SelectedValue.ToString());
            transaccionDTO.IdArticulo = int.Parse(txtIdArticulo.Text);
            transaccionDTO.Descripcion = txtDescripcion.Text;
            transaccionDTO.Cantidad = Decimal.Parse(txtCantidad.Text);
            transaccionDTO.CostoUnitario = Decimal.Parse(txtPrecio.Text);
            transaccionDTO.Costo = transaccionDTO.Cantidad * transaccionDTO.CostoUnitario;
            transaccionDTO.Fecha = DateTime.Now;  //AppUtilidad.stringToDateTime(this.txtFechaTransaccion.Text, "DD/MM/YYYY");
            transaccionDTO.TipoOrigen = "MANUAL";
            transaccionDTO.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
            transaccionDTO.FechaCreacion = DateTime.Now; 

            int idTransaccion = objTransaccionDAO.Agregar(transaccionDTO);
            txtId.Text = idTransaccion.ToString();

            DespachoDTO objDespachoDTO = new DespachoDTO();

            objDespachoDTO.TipoOrigen = "TRX";
            objDespachoDTO.IdOrigen = idTransaccion;
            objDespachoDTO.FechaDespacho = DateTime.Now;
            objDespachoDTO.Estado = "1";
            objDespachoDTO.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
            objDespachoDTO.FechaCreacion = DateTime.Now;

            objDespachoDAO.Agregar(objDespachoDTO);

            this.lblMensaje.Text = "Se registro la transaccion de inventario";

        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloDTO obj;

            try
            {
                int idArticulo = Convert.ToInt32(gvLista.SelectedRow.Cells[0].Text);
                obj = objArticuloDAO.ListarPorClave(idArticulo);

                this.txtArticulo.Text = obj.CodigoArticulo.ToString();
                this.txtPrecio.Text = obj.UltimoPrecioOc.ToString();
                this.txtIdArticulo.Text = obj.IdArticulo.ToString();
                this.txtArticuloDesc.Text = obj.Descripcion;

                pnlBusqueda.Visible = false;
                pnlRegistro.Visible = true;
            }
            catch (Exception err)
            {
                // this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = false;
            pnlRegistro.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = true;
            pnlRegistro.Visible = false;
            //Buscar Articulo
            String strBusqueda = txtArticuloDesc.Text;
            List<ArticuloDTO> articulos = objArticuloDAO.ListarBusquedaPorProyecto(strBusqueda, Convert.ToInt32(this.ddlProyecto.SelectedValue));
            this.gvLista.DataSource = articulos;
            this.gvLista.DataBind();
        }
    }
}