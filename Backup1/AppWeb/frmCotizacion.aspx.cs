using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmCotizacion : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();

        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        CotizacionLineaDAO objCotizacionLineaDAO = new CotizacionLineaDAO();
        ProveedorDAO objProveedorDAO = new ProveedorDAO();
        CotizacionLineaProveedorDAO objCotizacionLineaProveedorDAO = new CotizacionLineaProveedorDAO();
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        IgvDAO objIgvDAO = new IgvDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnAgregarProceedor.Attributes.Add("onclick", "return js_validar_proveedor();");
            this.btnGenerarOrdenCompra.Attributes.Add("onclick", "return confirm('Desea Ud. generar la Orden de Compra?');");

        }

        protected void InicializaPagina()
        {
            this.lblMensaje.Text = "";

            try
            { 
            
                string LoginUsuario = HttpContext.Current.User.Identity.Name;
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

                if (objUsuario != null)
                    this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

                CotizacionDTO obj = null;
                int IdCotizacion = 0;
                if (Session["ID_COTIZACION"] == null)
                {
                    if (this.txtIdCotizacion.Text!="")
                        IdCotizacion = Convert.ToInt32(txtIdCotizacion.Text);
                
                }
                else
                {
                    IdCotizacion = Convert.ToInt32(Session["ID_COTIZACION"]);
                    txtIdCotizacion.Text = Convert.ToString(Session["ID_COTIZACION"]);
                }

                if (IdCotizacion > 0)
                {
                    obj = objCotizacionDAO.ListarPorClave(IdCotizacion);
                    if (obj != null)
                    {

                        PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(obj.IdPedido);

                        this.lblIdCotizacion.Text = obj.IdCotizacion.ToString();
                        this.litIdCotizacion.Text = obj.IdCotizacion.ToString();
                        this.lblIdPedido.Text = obj.IdPedido.ToString();
                        this.lblFechaSolicitudCompra.Text = objPedidoDTO.FechaPedido.ToString("dd/MM/yyyy");
                        this.lblFechaCotizacion.Text = obj.FechaCotizacion.ToString("dd/MM/yyyy");                    
                        this.txtDescripcionCotizacion.Text = obj.DescripcionCotizacion;
                        this.lblMoneda.Text = obj.NombreMoneda;
                        this.lblEstado.Text = obj.NombreEstado;
                        this.lblNombreSolicitante.Text = obj.NombreUsuarioSolicitante;

                        //Lista
                        List<CotizacionLineaDTO> Lista = objCotizacionLineaDAO.ListarPorCotizacion(IdCotizacion);
                        this.gvLineas.DataSource = Lista;
                        this.gvLineas.DataBind();

                    }

                }
                else
                {
                }


                this.panProveedor.Visible = false;

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            try 
            {
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(Convert.ToInt32(this.lblIdCotizacion.Text));
                objCotizacionDTO.DescripcionCotizacion = this.txtDescripcionCotizacion.Text;
                objCotizacionDTO.FechaModificacion = DateTime.Now;
                objCotizacionDTO.IdUsuarioModificacion = objUsuario.IdUsuario;
                objCotizacionDAO.Actualizar(objCotizacionDTO);
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }
        }

        protected void gvLineas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdCotizacionLinea = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Select")
            {
                this.txtIdCotizacionLinea.Text = IdCotizacionLinea.ToString();
                this.panProveedor.Visible = true;
                List<ProveedorDTO> Lista = objProveedorDAO.Listar();


                CotizacionLineaDTO objCotizacionLineaDTO = objCotizacionLineaDAO.ListarPorClave(IdCotizacionLinea);

                this.lblLinea.Text = "Linea " + objCotizacionLineaDTO.NumeroLinea.ToString();

                this.ddlProveedor.DataSource = Lista;
                this.ddlProveedor.DataTextField = "RazonSocial";
                this.ddlProveedor.DataValueField = "IdProveedor";
                this.ddlProveedor.DataBind();
                this.ddlProveedor.Items.Insert(0, new ListItem("- Seleccione -", "0"));

                //Listar Proveedores
                List<CotizacionLineaProveedorDTO> ListaProveedores = objCotizacionLineaProveedorDAO.Listar(Convert.ToInt32(this.lblIdCotizacion.Text), IdCotizacionLinea);
                this.gvProveedores.DataSource = ListaProveedores;
                this.gvProveedores.DataBind();

                this.panProveedor.Visible = true;

            }
        }

        protected void gvLineas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CotizacionLineaDTO row = (CotizacionLineaDTO)e.Row.DataItem;

                //if ( Convert.ToInt32(row.IdCotizacionLinea) == Convert.ToInt32(this.txtIdCotizacionLinea.Text)) 
                //{
                //    e.Row.BackColor = System.Drawing.Color.Aqua;
                //}
                //ImageButton imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");
                //imgEliminar.CommandArgument = row.IdCotizacion.ToString() + "," + row.IdCotizacionLinea.ToString() + "," + row.IdProveedor.ToString();
            }
        }

        protected void btnAgregarProceedor_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";

            try {

                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                CotizacionLineaDTO objCotizacionLineaDTO = null;
                CotizacionLineaProveedorDTO objCotizacionLineaProveedorDTO = null;
                IgvDTO objIgvDTO = objIgvDAO.ListarIGVVigente(DateTime.Now);

                int IdCotizacion = Convert.ToInt32(this.txtIdCotizacion.Text);
                int IdCotizacionLinea = Convert.ToInt32(this.txtIdCotizacionLinea.Text);
                int IdProveedor = Convert.ToInt32(this.ddlProveedor.SelectedValue);

                objCotizacionLineaDTO = objCotizacionLineaDAO.ListarPorClave(IdCotizacionLinea);

                objCotizacionLineaProveedorDTO = new CotizacionLineaProveedorDTO();

                objCotizacionLineaProveedorDTO.IdCotizacion = IdCotizacion;
                objCotizacionLineaProveedorDTO.IdCotizacionLinea = IdCotizacionLinea;
                objCotizacionLineaProveedorDTO.IdProveedor = IdProveedor;
                objCotizacionLineaProveedorDTO.Cantidad = objCotizacionLineaDTO.Cantidad;


                if (this.chkIGV.Checked)
                {
                    decimal cantidad = objCotizacionLineaDTO.Cantidad;
                    decimal importe = objCotizacionLineaDTO.Cantidad * Convert.ToDecimal(this.txtPrecio.Text);
                    decimal igv = objIgvDTO.Igv;
                    decimal importe_sin_igv = (importe * (100 / (100 + igv)));
                    decimal precio_sin_igv = (importe * (100 / (100 + igv))) / cantidad;
                    objCotizacionLineaProveedorDTO.Precio = precio_sin_igv;
                    objCotizacionLineaProveedorDTO.Importe = importe_sin_igv;
                    objCotizacionLineaProveedorDTO.FlagIgv = "0";
                
                }
                else
                {
                    objCotizacionLineaProveedorDTO.Precio = Convert.ToDecimal(this.txtPrecio.Text);
                    objCotizacionLineaProveedorDTO.Importe = objCotizacionLineaDTO.Cantidad * Convert.ToDecimal(this.txtPrecio.Text);
                    objCotizacionLineaProveedorDTO.FlagIgv = "0";
                }
                
                objCotizacionLineaProveedorDTO.FlagSeleccionado = "0";
                objCotizacionLineaProveedorDTO.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
                objCotizacionLineaProveedorDTO.FechaCreacion = DateTime.Now;
                objCotizacionLineaProveedorDTO.DiasEntrega = Convert.ToInt32(this.txtDiasEntrega.Text);

                objCotizacionLineaProveedorDAO.Agregar(objCotizacionLineaProveedorDTO);
           
                //Listar Proveedores
                List<CotizacionLineaProveedorDTO> Lista =  objCotizacionLineaProveedorDAO.Listar(IdCotizacion, IdCotizacionLinea);
                this.gvProveedores.DataSource = Lista;
                this.gvProveedores.DataBind();

                this.txtDiasEntrega.Text = "";
                this.txtPrecio.Text = "";

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }

        protected void gvProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                CotizacionLineaProveedorDTO row = (CotizacionLineaProveedorDTO)e.Row.DataItem;
                ImageButton imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");
                Button btnSeleccionar = (Button)e.Row.FindControl("btnSeleccionar");
                imgEliminar.CommandArgument = row.IdCotizacion.ToString() + "," + row.IdCotizacionLinea.ToString() + "," + row.IdProveedor.ToString();
                btnSeleccionar.CommandArgument = row.IdCotizacion.ToString() + "," + row.IdCotizacionLinea.ToString() + "," + row.IdProveedor.ToString();

                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(row.IdCotizacion);

                if (objCotizacionDTO.Estado == "2")
                {
                    btnSeleccionar.Enabled = false;
                    imgEliminar.Enabled = false;
                }

            }
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                string[] parametros = (e.CommandArgument.ToString()).Split(',');
                int IdCotizacion = Convert.ToInt32(parametros[0]);
                int IdCotizacionLinea = Convert.ToInt32(parametros[1]);
                int IdProveedor = Convert.ToInt32(parametros[2]);
                objCotizacionLineaProveedorDAO.Eliminar(IdCotizacion, IdCotizacionLinea, IdProveedor);

                //Listar Proveedores
                List<CotizacionLineaProveedorDTO> Lista = objCotizacionLineaProveedorDAO.Listar(IdCotizacion, IdCotizacionLinea);
                this.gvProveedores.DataSource = Lista;
                this.gvProveedores.DataBind();

            }

            if (e.CommandName == "Seleccionar")
            {

                string[] parametros = (e.CommandArgument.ToString()).Split(',');
                int IdCotizacion = Convert.ToInt32(parametros[0]);
                int IdCotizacionLinea = Convert.ToInt32(parametros[1]);
                int IdProveedor = Convert.ToInt32(parametros[2]);

                CotizacionLineaDTO objCotizacionLinea = objCotizacionLineaDAO.ListarPorClave(IdCotizacionLinea);
                CotizacionLineaProveedorDTO obj = objCotizacionLineaProveedorDAO.ListarPorClave(IdCotizacion, IdCotizacionLinea, IdProveedor);

                objCotizacionLinea.Precio = obj.Precio;
                objCotizacionLinea.Importe = obj.Importe;
                objCotizacionLinea.IdProveedorSeleccionado = obj.IdProveedor;
                objCotizacionLinea.DiasEntrega = obj.DiasEntrega;

                objCotizacionLineaDAO.Actualizar(objCotizacionLinea);


                //Lista
                List<CotizacionLineaDTO> Lista2 = objCotizacionLineaDAO.ListarPorCotizacion(Convert.ToInt32(this.txtIdCotizacion.Text));
                this.gvLineas.DataSource = Lista2;
                this.gvLineas.DataBind();
            
            }
        }

        protected void gvLineas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.gvLineas.Rows)
            {
                if (row.RowIndex == gvLineas.SelectedIndex)
                {
                    row.BackColor = System.Drawing.ColorTranslator.FromHtml("#A1DCF2");
                }
            }

        }

        protected void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";

            try
            {

                List<CotizacionLineaDTO> Lista = objCotizacionLineaDAO.ListarPorCotizacion(Convert.ToInt32(this.txtIdCotizacion.Text));
           
                foreach (CotizacionLineaDTO reg in Lista) 
                {
                    CotizacionLineaProveedorDTO obj = objCotizacionLineaProveedorDAO.RecomendarProveedor( reg.IdCotizacion, reg.IdCotizacionLinea);

                    if (obj != null)
                    {
                        CotizacionLineaDTO objCotizacionLinea = objCotizacionLineaDAO.ListarPorClave(reg.IdCotizacionLinea);

                        objCotizacionLinea.Precio = obj.Precio;
                        objCotizacionLinea.Importe = obj.Importe;
                        objCotizacionLinea.IdProveedorSeleccionado = obj.IdProveedor;
                        objCotizacionLinea.DiasEntrega = obj.DiasEntrega;

                        objCotizacionLineaDAO.Actualizar(objCotizacionLinea);
                
                    }

                }

                //Lista
                List<CotizacionLineaDTO> Lista2 = objCotizacionLineaDAO.ListarPorCotizacion( Convert.ToInt32(this.txtIdCotizacion.Text));
                this.gvLineas.DataSource = Lista2;
                this.gvLineas.DataBind();

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }
        }

        protected void btnGenerarOrdenCompra_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";

            try
            {
                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(Convert.ToInt32(this.txtIdCotizacion.Text));

                if (objCotizacionDTO.Estado == "1")
                {

                    int id = objOrdenCompraDAO.Generar(Convert.ToInt32(this.txtIdCotizacion.Text), objUsuarioDTO.IdUsuario);

                    objCotizacionDTO = objCotizacionDAO.ListarPorClave(Convert.ToInt32(this.txtIdCotizacion.Text));

                    PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                    objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_EN_APROBACION_OC;
                    objPedidoDAO.Actualizar(objPedidoDTO);

                    this.btnActualizar.Visible = false;
                    this.btnSeleccionarProveedor.Visible = false;
                    this.btnAgregarProceedor.Visible = false;
                    this.btnGenerarOrdenCompra.Visible = false;

                    this.lblMensaje.Text = "Se genero la Orden de Compra " + id.ToString();

                    this.panSeleccionProveedor.Visible = false;
                    this.btnSeleccionarProveedor.Visible = false;

                }
                else 
                {
                    this.panSeleccionProveedor.Visible = false;
                    this.btnSeleccionarProveedor.Visible = false;
                    this.btnActualizar.Visible = false;
                    this.btnSeleccionarProveedor.Visible = false;
                    this.btnAgregarProceedor.Visible = false;
                    this.btnGenerarOrdenCompra.Visible = false;
            
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }
        

    }
}