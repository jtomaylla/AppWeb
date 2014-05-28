using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using AppWeb.Reporte;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        ProveedorDAO objProveedorDAO = new ProveedorDAO();
        IgvDAO objIGVDAO = new IgvDAO();
        ParametroDAO objParametroDAO = new ParametroDAO();
        FormaPagoDAO objFormaPagoDAO = new FormaPagoDAO();
        MonedaDAO objMonedaDAO = new MonedaDAO();
        InvUnidadMedidaDAO objInvUnidadMedidaDAO = new InvUnidadMedidaDAO();
        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        PedidoPresupuestoDAO objPedidoPresupuestoDAO = new PedidoPresupuestoDAO();

        Decimal dSubTotal = 0;
        Decimal dIGV = 0;
        Decimal dTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

        }

        protected void InicializaPagina()
        {

            lblMensaje.Visible = false;
            lblMensaje.Text = "";

            try
            {

                int IdOrdenCompra;

                string id = Request.QueryString["id"].ToString();

                IdOrdenCompra = Convert.ToInt32(id);

                OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);
                ProveedorDTO objProveedorDTO = objProveedorDAO.ListarPorClave(objOrdenCompraDTO.IdProveedor);
                List<OrdenCompraLineaDTO> objOrdenCompraLinea = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
                ParametroDTO objParametroDTO = objParametroDAO.ListarPorClave(1);
                FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(objOrdenCompraDTO.IdFormaPago);
                MonedaDTO objMonedaDTO = objMonedaDAO.ListarPorClave(objOrdenCompraDTO.CodMoneda);
                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompraDTO.IdCotizacion); //editado por requerimiento del cliente
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorClave(objPedidoDTO.IdSolicitante);
                List<PedidoPresupuestoDTO> ListaPedidoPresupuestoDTO = objPedidoPresupuestoDAO.Listar(objPedidoDTO.IdPedido);

                dsReportes dsReporte = new dsReportes();

                dsReportes.ParametroRow drParametroRow = dsReporte.Parametro.NewParametroRow();
                drParametroRow.id_reporte = 1;
                drParametroRow.empresa = objParametroDTO.RazonSocial;

                if (objOrdenCompraDTO.IdTipoOrdenCompra == 1)
                    drParametroRow.titulo1 = "ORDEN DE COMPRA N° " + objOrdenCompraDTO.IdOrdenCompra.ToString();
                else
                    if (objOrdenCompraDTO.IdTipoOrdenCompra == 2)
                        drParametroRow.titulo1 = "ORDEN DE SERVICIO N° " + objOrdenCompraDTO.IdOrdenCompra.ToString();
                    else
                        drParametroRow.titulo1 = "ORDEN N° " + objOrdenCompraDTO.IdOrdenCompra.ToString();

                dsReporte.Parametro.AddParametroRow(drParametroRow);

                //MONTO DE IGV
                IgvDTO objIGVDTO = objIGVDAO.ListarIGVVigente(objOrdenCompraDTO.FechaOrdenCompra);

                dsReportes.OrdenCompraRow drOrdenCompraRow = dsReporte.OrdenCompra.NewOrdenCompraRow();
                drOrdenCompraRow.IdReporte = 1;
                drOrdenCompraRow.IdOrdenCompra = objOrdenCompraDTO.IdOrdenCompra;

                if (objProveedorDTO != null)
                {
                    drOrdenCompraRow.RazonSocial = objProveedorDTO.RazonSocial;
                    drOrdenCompraRow.Ruc = objProveedorDTO.Ruc;
                    drOrdenCompraRow.Direccion = objProveedorDTO.Direccion;
                    drOrdenCompraRow.Contacto = objProveedorDTO.Contacto;
                }

                drOrdenCompraRow.Fecha = objOrdenCompraDTO.FechaOrdenCompra.ToString("dd/MM/yyyy");
                //drOrdenCompraRow.Cotizacion = "Estimación N° " + objOrdenCompraDTO.IdCotizacion.ToString(); //modificado por req del cliente
                drOrdenCompraRow.Cotizacion = "Cotizacion N° " + objOrdenCompraDTO.NroCotizProv.ToString();

                if (objMonedaDTO != null)
                    drOrdenCompraRow.Moneda = objMonedaDTO.Simbolo;

                drOrdenCompraRow.Subtotal = objOrdenCompraDTO.ImporteOrdenCompra;

                if (objOrdenCompraDTO.FechaEntrega.Year != 1)
                    drOrdenCompraRow.FechaEntrega = objOrdenCompraDTO.FechaEntrega.ToString("dd/MM/yyyy");

                if (objFormaPagoDTO != null)
                    drOrdenCompraRow.FormaPago = objFormaPagoDTO.NombreFormaPago;

                if (objParametroDTO != null)
                {
                    drOrdenCompraRow.FacturarNombre = objParametroDTO.RazonSocial;
                    drOrdenCompraRow.FacturarRuc = objParametroDTO.Ruc;
                    //drOrdenCompraRow.Direccion = objParametroDTO.Direccion;
                    drOrdenCompraRow.FacturarDireccion = objParametroDTO.Direccion;
                }

                drOrdenCompraRow.Proyecto = objOrdenCompraDTO.NombreProyecto;

                string codigos = "";
                if (ListaPedidoPresupuestoDTO.Count > 0)
                {
                    foreach (PedidoPresupuestoDTO item in ListaPedidoPresupuestoDTO)
                    {
                        codigos = codigos + " " + item.CodigoPresupuesto;
                    }
                }

                drOrdenCompraRow.Descripcion = "Solicitado por " + objUsuarioDTO.NombreUsuario + " - Código: " + codigos;

                if (objOrdenCompraDTO.FlagIGV == "1")
                {
                    drOrdenCompraRow.IGV = drOrdenCompraRow.Subtotal * (objIGVDTO.Igv / 100);
                    drOrdenCompraRow.Total = drOrdenCompraRow.Subtotal + drOrdenCompraRow.IGV;
                    drOrdenCompraRow.PorcentajeIGV = objIGVDTO.Igv.ToString() + "%";
                }
                else
                {
                    drOrdenCompraRow.IGV = 0;
                    drOrdenCompraRow.Total = drOrdenCompraRow.Subtotal + drOrdenCompraRow.IGV;
                    drOrdenCompraRow.PorcentajeIGV = "0%";
                }

                /*
                            if (objOrdenCompraDTO.IdTipoOrdenCompra == 2)
                            {
                                drOrdenCompraRow.IGV = 0;
                                drOrdenCompraRow.Total = drOrdenCompraRow.Subtotal + drOrdenCompraRow.IGV;
                                drOrdenCompraRow.PorcentajeIGV = "0%";
                            }
                            else
                            {
                                drOrdenCompraRow.IGV = drOrdenCompraRow.Subtotal * (objIGVDTO.Igv / 100);
                                drOrdenCompraRow.Total = drOrdenCompraRow.Subtotal + drOrdenCompraRow.IGV;
                                drOrdenCompraRow.PorcentajeIGV = objIGVDTO.Igv.ToString() + "%";
                            }
                */
                drOrdenCompraRow.TotalLetras = "SON: " + AppUtilidad.numberToText(drOrdenCompraRow.Total.ToString()) + " " + objMonedaDTO.NombreMoneda;

                dsReporte.OrdenCompra.AddOrdenCompraRow(drOrdenCompraRow);

                foreach (OrdenCompraLineaDTO linea in objOrdenCompraLinea)
                {

                    InvUnidadMedidaDTO objInvUnidadMedidaDTO = objInvUnidadMedidaDAO.ListarPorClave(linea.IdUnidadMedida);
                    dsReportes.OrdenCompraLineasRow drOrdenCompraLineasRow = dsReporte.OrdenCompraLineas.NewOrdenCompraLineasRow();

                    drOrdenCompraLineasRow.IdReporte = 1;
                    drOrdenCompraLineasRow.IdOrdenCompra = objOrdenCompraDTO.IdOrdenCompra;
                    drOrdenCompraLineasRow.Linea = linea.NumeroLinea;
                    drOrdenCompraLineasRow.Cantidad = linea.Cantidad;

                    if (objInvUnidadMedidaDTO != null)
                        drOrdenCompraLineasRow.UnidadMedida = objInvUnidadMedidaDTO.NombreCorto;

                    drOrdenCompraLineasRow.DescripcionLinea = linea.DescripcionLinea;
                    drOrdenCompraLineasRow.PrecioUnitario = linea.Precio;
                    drOrdenCompraLineasRow.Importe = linea.Importe;
                    dsReporte.OrdenCompraLineas.AddOrdenCompraLineasRow(drOrdenCompraLineasRow);
                }

                CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
                myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                string strRuta = Server.MapPath("rptOrdenCompra.rpt");
                myReportDocument.Load(strRuta);
                myReportDocument.SetDataSource(dsReporte);
                Session.Add("ReporteCrystal", myReportDocument);
                Session.Add("FormatoReporte", "PDF");


                MemoryStream stream = new MemoryStream();
                stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.ContentType = "application/pdf";

                myReportDocument.Close();
                myReportDocument.Dispose();

                Response.Clear();
                Response.Buffer = true;

                Response.BinaryWrite(stream.ToArray());
                Response.End();

                stream.Flush();
                stream.Close();
                stream.Dispose();

            }
            catch(Exception ex)
            {
                lblMensaje.Visible = true;
                this.lblMensaje.Text = ex.ToString();
            }
        }

    }
}