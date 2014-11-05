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
    public partial class frmRecepcionServicio : System.Web.UI.Page
    {

        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();

        RecepcionDAO objRecepcionDAO = new RecepcionDAO();
        RecepcionLineaDAO objRecepcionLineaDAO = new RecepcionLineaDAO();

        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();

        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnBuscar.Attributes.Add("onclick", "return js_validar_buscar();");
            this.btnRecepcionar.Attributes.Add("onclick", "return js_validar();");
        }

        protected void InicializaPagina()
        {
            this.panRecepcion.Visible = false;
            LimpiarCampos();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.lblMensajeRecepcion.Text = "";

            if (this.txtNumOrdenCompra.Text != "")
            {
                int IdOrdenCompra;
                bool isNum = Int32.TryParse(this.txtNumOrdenCompra.Text, out IdOrdenCompra);

                if (isNum)
                    BuscarOrdenCompra(IdOrdenCompra);
                else
                    this.lblMensajeRecepcion.Text = "Ingrese Valor numerico para Numero de Orden de Compra";

            }
            else
            {
                this.lblMensajeRecepcion.Text = "Ingrese Numero de Orden de Compra";
            }
            
        }

        protected void btnRecepcionar_Click(object sender, EventArgs e)
        {

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            Boolean hayRecepcion = false;
            
            this.lblMensaje.Text = "";

            foreach (GridViewRow row in this.gvLista.Rows)
            {
                DataKey dKey = gvLista.DataKeys[row.RowIndex];
                CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");

                if (chkSeleccion.Checked)
                {
                    hayRecepcion = true;
                }
            }

            if (!hayRecepcion)
            {
                this.lblMensaje.Text = "Seleccione una linea para realizar la confirmación de atención";
            }

            if (hayRecepcion)
            {

                OrdenCompraDTO objOrdenCompraDTO = new OrdenCompraDTO();
                RecepcionDTO objRecepcion = new RecepcionDTO();

                objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(Convert.ToInt32(this.txtIdOrdenCompra.Text));

                objRecepcion.IdProveedor = objOrdenCompraDTO.IdProveedor;
                objRecepcion.FechaRecepcion = AppUtilidad.stringToDateTime(this.txtFechaRecepcion.Text, "DD/MM/YYYY");
                objRecepcion.NumeroRecibo = this.txtGuiaRemision.Text;
                objRecepcion.Anotaciones = this.txtObservaciones.Text;
                objRecepcion.IdOrdenCompra = objOrdenCompraDTO.IdOrdenCompra;
                objRecepcion.TipoRecepcion = "SERVICIO";
                objRecepcion.FechaCreacion = DateTime.Now;
                objRecepcion.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
                objRecepcion.IdSede = objOrdenCompraDTO.IdSede;
                objRecepcion.IdProyecto = objOrdenCompraDTO.IdProyecto;

                int IdRecepcion = objRecepcionDAO.Agregar(objRecepcion);

                foreach (GridViewRow row in this.gvLista.Rows)
                {
                    DataKey dKey = gvLista.DataKeys[row.RowIndex];
                    int IdOrdenCompraLinea = Convert.ToInt32(dKey[0].ToString());

                    decimal cantidad = Convert.ToDecimal(row.Cells[5].Text);
                    decimal cantidad_orden_compra = Convert.ToDecimal(row.Cells[5].Text);
                    decimal cantidad_recibida = Convert.ToDecimal(row.Cells[5].Text);
                    //decimal cantidad_pendiente = cantidad_orden_compra - cantidad_recibida;

                    OrdenCompraLineaDTO objOrdenCompraLineaDTO = new OrdenCompraLineaDTO();
                    RecepcionLineaDTO objRecepcionLinea = new RecepcionLineaDTO();

                    objOrdenCompraLineaDTO = objOrdenCompraLineaDAO.ListarPorClave(objOrdenCompraDTO.IdOrdenCompra, IdOrdenCompraLinea);

                    objRecepcionLinea.IdRecepcion = IdRecepcion;
                    objRecepcionLinea.IdOrdenCompra = objOrdenCompraLineaDTO.IdOrdenCompra;
                    objRecepcionLinea.IdOrdenCompraLinea = objOrdenCompraLineaDTO.IdOrdenCompraLinea;
                    objRecepcionLinea.IdArticulo = objOrdenCompraLineaDTO.IdArticulo;
                    objRecepcionLinea.CantidadRecepcionada = cantidad;
                    objRecepcionLinea.Anotaciones = "";
                    objRecepcionLinea.FechaCreacion = DateTime.Now;
                    objRecepcionLinea.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
                    objRecepcionLinea.Estado = AppConstantes.ESTADO_RECEPCION_INGRESO_OC;
                    objRecepcionLineaDAO.Agregar(objRecepcionLinea);

                    objOrdenCompraLineaDTO.EstadoControl = AppConstantes.ESTADO_CONTROL_OC_CERRADO_PARA_RECEPCION;
                    objOrdenCompraLineaDTO.FechaModificacion = DateTime.Now;
                    objOrdenCompraLineaDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                    objOrdenCompraLineaDAO.Actualizar(objOrdenCompraLineaDTO);

                }

                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompraDTO.IdCotizacion);
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_CON_RECEPCION;
                objPedidoDAO.Actualizar(objPedidoDTO);
                
                objOrdenCompraDTO.EstadoControl = AppConstantes.ESTADO_CONTROL_OC_CERRADO_PARA_RECEPCION;
                objOrdenCompraDTO.FechaModificacion = DateTime.Now;
                objOrdenCompraDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                objOrdenCompraDAO.Actualizar(objOrdenCompraDTO);

                this.lblMensajeRecepcion.Text = "Se genero la confirmación de atención " + IdRecepcion.ToString();
                this.panRecepcion.Visible = false;

            } // if (hayRecepcion)
        }

        protected void BuscarOrdenCompra(int IdOrdenCompra)
        {

            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            if (obj != null)
            {
                if (obj.IdTipoOrdenCompra == AppConstantes.TIPO_ORDEN_COMPRA_SERVICIO)
                {
                    if (obj.EstadoControl == AppConstantes.ESTADO_CONTROL_OC_ACTIVO)
                    {
                        if (obj.EstadoAprobacion == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                        {

                            if (obj.EnviadoProveedor == AppConstantes.FLAG_SI)
                            {

                                this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
                                this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
                                this.lblTipoOrdenCompra.Text = obj.NombreTipoOrdenCompra;
                                this.lblNombreProyecto.Text = obj.NombreProyecto;
                                this.lblNombreSede.Text = obj.NombreSede;
                                this.lblRazonSocial.Text = obj.RazonSocial;
                                this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
                                this.lblNombreMoneda.Text = obj.NombreMoneda;
                                this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();

                                List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.ListarPendienteRecepcion(IdOrdenCompra);

                                if (objLista.Count > 0)
                                {
                                    this.gvLista.DataSource = objLista;
                                    this.gvLista.DataBind();
                                    this.panRecepcion.Visible = true;
                                }
                                else
                                {
                                    this.lblMensajeRecepcion.Text = "Orden de compra no disponible, no tiene lineas pendientes de confirmación de atención";
                                    this.panRecepcion.Visible = false;
                                    LimpiarCampos();
                                }
                            } //if (obj.EnviadoProveedor == AppConstantes.FLAG_SI)
                            else
                            {
                                this.lblMensajeRecepcion.Text = "Orden de compra aun no fue enviada al proveedor";
                                this.panRecepcion.Visible = false;
                                LimpiarCampos();
                            }

                        }
                        else // if (obj.EstadoAprobacion == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                        {
                            this.lblMensajeRecepcion.Text = "Orden de compra no esta APROBADA";
                            this.panRecepcion.Visible = false;
                            LimpiarCampos();
                        }
                    }
                    else // if (obj.EstadoControl == AppConstantes.ESTADO_CONTROL_OC_ACTIVO)
                    {
                        this.lblMensajeRecepcion.Text = "Orden de compra no esta CERRADA";
                        this.panRecepcion.Visible = false;
                        LimpiarCampos();
                    }
                } // if (obj.IdTipoOrdenCompra == 2)
                else
                {
                    this.lblMensajeRecepcion.Text = "Orden de compra no es de SERVICIO";
                    this.panRecepcion.Visible = false;
                    LimpiarCampos();
                }
            }
            else //if (obj != null)
            {
                this.lblMensajeRecepcion.Text = "Orden de compra no disponible o no existe para confirmación de atención";
                this.panRecepcion.Visible = false;
                LimpiarCampos();
            }
        }

        protected void LimpiarCampos()
        {

        }


    }
}