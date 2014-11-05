using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using AppWeb.Reporte;

namespace AppWeb
{
    public partial class frmGuiaRemision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guia();
        }

        private void Guia()
        {

            dsReportes dsReporte = new dsReportes();

            dsReportes.GuiaRemisionRow drFilaGuiaRemision = dsReporte.GuiaRemision.NewGuiaRemisionRow();

            drFilaGuiaRemision.id_guia_remision = 1;
            drFilaGuiaRemision.punto_partida = "LIMA";
            drFilaGuiaRemision.punto_llegada = "San Miguel";
            drFilaGuiaRemision.fecha_emision = "28/12/2013";
            drFilaGuiaRemision.fecha_inicio_traslado = "28/12/2013";

            drFilaGuiaRemision.destinatario = "NOMBRE DEL DESTINATARIO";
            drFilaGuiaRemision.ruc_destinatario = "099227394";
            drFilaGuiaRemision.transportista = "COMESA S.A";
            drFilaGuiaRemision.ruc_transportista = "199227395";
            drFilaGuiaRemision.marca = "KIA";
            drFilaGuiaRemision.placa = "888282828";
            drFilaGuiaRemision.certificado = "2013-09";
            drFilaGuiaRemision.licencia = "201309345";

            dsReporte.GuiaRemision.AddGuiaRemisionRow(drFilaGuiaRemision);
/*
            dsReportes.GuiaRemisionDetalleRow drFilaGuiaRemisionDetalle1 = dsReporte.GuiaRemisionDetalle.NewGuiaRemisionDetalleRow();

            drFilaGuiaRemisionDetalle1.id_guia_remision = 1;
            drFilaGuiaRemisionDetalle1.item = 1;
            drFilaGuiaRemisionDetalle1.cantidad = Convert.ToDecimal("12.33");
            drFilaGuiaRemisionDetalle1.codigo = "1010010020356";
            drFilaGuiaRemisionDetalle1.descripcion = "SULFATO FERROSO 300MG. TAB.";
            drFilaGuiaRemisionDetalle1.precio = Convert.ToDecimal("1234.23000");

            dsReporte.GuiaRemisionDetalle.AddGuiaRemisionDetalleRow(drFilaGuiaRemisionDetalle1);

            dsReportes.GuiaRemisionDetalleRow drFilaGuiaRemisionDetalle2 = dsReporte.GuiaRemisionDetalle.NewGuiaRemisionDetalleRow();

            drFilaGuiaRemisionDetalle2.id_guia_remision = 1;
            drFilaGuiaRemisionDetalle2.item = 2;
            drFilaGuiaRemisionDetalle2.cantidad = Convert.ToDecimal("12.33");
            drFilaGuiaRemisionDetalle2.codigo = "6910080080703";
            drFilaGuiaRemisionDetalle2.descripcion = "FRASCO 500 ML TAPA ROSCA PIREX USA VIDRIO BOROSILICATO AUTOCLAV.";
            drFilaGuiaRemisionDetalle2.precio = Convert.ToDecimal("2004.23000");

            dsReporte.GuiaRemisionDetalle.AddGuiaRemisionDetalleRow(drFilaGuiaRemisionDetalle2);
*/
            for (int i = 1; i < 31; i++)
            {
                dsReportes.GuiaRemisionDetalleRow drFilaGuiaRemisionDetalle3 = dsReporte.GuiaRemisionDetalle.NewGuiaRemisionDetalleRow();

                drFilaGuiaRemisionDetalle3.id_guia_remision = 1;
                drFilaGuiaRemisionDetalle3.item = i;
                drFilaGuiaRemisionDetalle3.cantidad = Convert.ToDecimal("12.33");
                drFilaGuiaRemisionDetalle3.codigo = "6910080080703";
                drFilaGuiaRemisionDetalle3.descripcion = "FRASCO 500 ML TAPA ROSCA PIREX USA VIDRIO BOROSILICATO AUTOCLAV.";
                drFilaGuiaRemisionDetalle3.precio = Convert.ToDecimal("2004.23000");

                dsReporte.GuiaRemisionDetalle.AddGuiaRemisionDetalleRow(drFilaGuiaRemisionDetalle3);
            }

            //dsReportes.ParametroRow drFilaParametro = dsReporte.Parametro.NewParametroRow();
            //drFilaParametro.IdReporte = 1;
            //drFilaParametro.empresa = "EMPRESA";
            //drFilaParametro.titulo1 = "ORDEN DE COMPRA N° " + objOrdenCompra.NumeroOrdenCompra;
            //dsReporte.Parametro.AddParametroRow(drFilaParametro);

            //dsReportes.OrdenCompraRow  dsFilaOrdenCompra = dsReporte.OrdenCompra.NewOrdenCompraRow();
            //dsFilaOrdenCompra.IdReporte = 1;
            //dsFilaOrdenCompra.IdOrdenCompra = objOrdenCompra.IdOrdenCompra;
            //dsFilaOrdenCompra.Proyecto = objOrdenCompra.NombreProyecto;
            //dsFilaOrdenCompra.RazonSocial = objOrdenCompra.RazonSocial;
            //dsFilaOrdenCompra.Moneda = objOrdenCompra.NombreMoneda;
            //dsFilaOrdenCompra.Subtotal = objOrdenCompra.ImporteOrdenCompra;
            ////MONTO DE IGV
            //IgvDTO IGVDTO = objIGVDAO.ListarIGVVigente(objOrdenCompra.FechaOrdenCompra);
            //dsFilaOrdenCompra.IGV = dsFilaOrdenCompra.Subtotal * IGVDTO.Igv;
            //dsFilaOrdenCompra.Total = dsFilaOrdenCompra.Subtotal + dsFilaOrdenCompra.IGV;

            //dsReporte.OrdenCompra.AddOrdenCompraRow(dsFilaOrdenCompra);


            //foreach (OrdenCompraLineaDTO linea in objOrdenCompraLinea)
            //{
            //    dsReportes.OrdenCompraLineasRow drFilaOrdenCompraLinea = dsReporte.OrdenCompraLineas.NewOrdenCompraLineasRow();

            //    drFilaOrdenCompraLinea.IdReporte = 1;
            //    drFilaOrdenCompraLinea.IdOrdenCompra = objOrdenCompra.IdOrdenCompra;
            //    drFilaOrdenCompraLinea.Linea = linea.NumeroLinea;
            //    drFilaOrdenCompraLinea.Cantidad = linea.Cantidad;
            //    drFilaOrdenCompraLinea.UnidadMedida = linea.NombreUnidadMedida;
            //    drFilaOrdenCompraLinea.DescripcionLinea = linea.DescripcionLinea;
            //    drFilaOrdenCompraLinea.PrecioUnitario = linea.Precio;
            //    drFilaOrdenCompraLinea.Importe = linea.Importe;

            //    dsReporte.OrdenCompraLineas.AddOrdenCompraLineasRow(drFilaOrdenCompraLinea);

            //}


            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("rptGuiaRemision.rpt");
            myReportDocument.Load(strRuta);
            myReportDocument.SetDataSource(dsReporte);
            Session.Add("ReporteCrystal", myReportDocument);
            Session.Add("FormatoReporte", "PDF");

            string strRutaWeb = Request.ApplicationPath;

            Response.Write("<script language='javascript'>window.open('frmVisorReporte.aspx" + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");
            //Response.Write("<script language='javascript'>window.open('" + strRutaWeb + "frmOrdenCompraImpresion.aspx?id=" + IdOrdenCompra.ToString() + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");
            //Response.Write("<script language='javascript'>JS_openWindow('" + strRutaWeb + "frmOrdenCompraImpresion.aspx?id=" + IdOrdenCompra.ToString() + "','Reporte','600','300','no', 'no', 'no', 'no', 'no');</script>");


        }
    }
}