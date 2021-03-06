﻿using System;
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
    public partial class frmRecepcion : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();

        RecepcionDAO objRecepcionDAO = new RecepcionDAO();
        RecepcionLineaDAO objRecepcionLineaDAO = new RecepcionLineaDAO();

        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();

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

        protected void BuscarOrdenCompra(int IdOrdenCompra) 
        {


            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            if (obj != null)
            {

                if (obj.IdTipoOrdenCompra == AppConstantes.TIPO_ORDEN_COMPRA_ARTICULO)
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
                                    this.lblMensajeRecepcion.Text = "Orden de compra no disponible para recepción, no tiene lineas pendientes de recepción";
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
                }
                else //if (obj.IdTipoOrdenCompra == AppConstantes.TIPO_ORDEN_COMPRA_SERVICIO)
                {
                    this.lblMensajeRecepcion.Text = "Orden de compra no es de COMPRA DE ARTICULO";
                    this.panRecepcion.Visible = false;
                    LimpiarCampos();
                }
            }
            else //if (obj != null)
            {
                this.lblMensajeRecepcion.Text = "Orden de Compra no disponible o no existe para recepción";
                this.panRecepcion.Visible = false;
                LimpiarCampos();
            }
        }

        protected void LimpiarCampos() 
        {
        
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
            Boolean Validacion = false;

            this.lblMensaje.Text = "";
            
            foreach (GridViewRow row in this.gvLista.Rows)
            {
                DataKey dKey = gvLista.DataKeys[row.RowIndex];
                CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");
                
                if (chkSeleccion.Checked ) {
                    hayRecepcion = true;
                    TextBox txtCantidadRecepcion = (TextBox)row.Cells[0].FindControl("txtCantidadRecepcion");
                    if (txtCantidadRecepcion.Text != "")
                    {
                        decimal cantidad = Convert.ToDecimal(txtCantidadRecepcion.Text);
                        decimal cantidad_orden_compra = Convert.ToDecimal(row.Cells[5].Text);
                        decimal cantidad_recibida = Convert.ToDecimal(row.Cells[8].Text);
                        decimal cantidad_pendiente = cantidad_orden_compra - cantidad_recibida;
                        if (cantidad > 0)
                        {
                            if (cantidad <= cantidad_pendiente)
                            {
                                Validacion = true;
                            }
                            else
                            {
                                this.lblMensaje.Text = "Cantidad de recepcion es mayor a la cantidad pendiente de recepcionar";
                            }
                        }
                        else
                        {
                            this.lblMensaje.Text = "Cantidad de recepcion debe ser un valor positivo";
                        }

                    }
                    else 
                    {
                        this.lblMensaje.Text = "Indique cantida a recepcionar";
                    }
                }
            }
            
            if (!hayRecepcion)
            {
                this.lblMensaje.Text = "Seleccione una linea he indique cantida a recepcionar";
            }

            if (Validacion)
            {

                OrdenCompraDTO objOrdenCompra = new OrdenCompraDTO();
                RecepcionDTO objRecepcion = new RecepcionDTO();

                objOrdenCompra = objOrdenCompraDAO.ListarPorClave(Convert.ToInt32(this.txtIdOrdenCompra.Text));

                objRecepcion.IdProveedor = objOrdenCompra.IdProveedor;
                objRecepcion.FechaRecepcion = AppUtilidad.stringToDateTime(this.txtFechaRecepcion.Text, "DD/MM/YYYY");
                objRecepcion.NumeroRecibo = this.txtGuiaRemision.Text;
                objRecepcion.IdOrdenCompra = objOrdenCompra.IdOrdenCompra;
                objRecepcion.Anotaciones = this.txtObservaciones.Text;
                objRecepcion.TipoRecepcion = "COMPRA";
                objRecepcion.IdSede = objOrdenCompra.IdSede;
                objRecepcion.IdProyecto = objOrdenCompra.IdProyecto;
                                            
                objRecepcion.FechaCreacion = DateTime.Now;
                objRecepcion.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;

                int IdRecepcion = objRecepcionDAO.Agregar(objRecepcion);

                foreach (GridViewRow row in this.gvLista.Rows)
                {
                    DataKey dKey = gvLista.DataKeys[row.RowIndex];
                    int IdOrdenCompraLinea = Convert.ToInt32 (dKey[0].ToString());

                    TextBox txtCantidadRecepcion = (TextBox)row.Cells[0].FindControl("txtCantidadRecepcion");
                    decimal cantidad = Convert.ToDecimal(txtCantidadRecepcion.Text);
                    decimal cantidad_orden_compra = Convert.ToDecimal(row.Cells[5].Text);
                    decimal cantidad_recibida = Convert.ToDecimal(row.Cells[8].Text);
                    decimal cantidad_pendiente = cantidad_orden_compra - cantidad_recibida;

                    OrdenCompraLineaDTO objOrdenCompraLinea = new OrdenCompraLineaDTO();
                    RecepcionLineaDTO objRecepcionLinea = new RecepcionLineaDTO();

                    objOrdenCompraLinea = objOrdenCompraLineaDAO.ListarPorClave(objOrdenCompra.IdOrdenCompra, IdOrdenCompraLinea);

                    objRecepcionLinea.IdRecepcion = IdRecepcion;
                    objRecepcionLinea.IdOrdenCompra = objOrdenCompraLinea.IdOrdenCompra;
                    objRecepcionLinea.IdOrdenCompraLinea = objOrdenCompraLinea.IdOrdenCompraLinea;
                    objRecepcionLinea.IdArticulo = objOrdenCompraLinea.IdArticulo;
                    objRecepcionLinea.CantidadRecepcionada = cantidad;
                    objRecepcionLinea.Anotaciones = "";
                    objRecepcionLinea.FechaCreacion = DateTime.Now;
                    objRecepcionLinea.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
                    objRecepcionLinea.Estado = AppConstantes.ESTADO_RECEPCION_INGRESO_OC;

                    objRecepcionLineaDAO.Agregar(objRecepcionLinea);

                }

                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompra.IdCotizacion);
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_CON_RECEPCION;
                objPedidoDAO.Actualizar(objPedidoDTO);
                
                this.lblMensajeRecepcion.Text = "Se genero la Recepción " + IdRecepcion.ToString();
                this.panRecepcion.Visible = false;

            }

        }

        
    }
}