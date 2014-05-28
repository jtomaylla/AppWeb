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


namespace AppWeb
{
    public partial class KardexArticulo1 : System.Web.UI.Page
    {

        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        InvUnidadMedidaDAO objUnidadMedidaDAO = new InvUnidadMedidaDAO();
        InvTransaccionDAO objTransaccionDAO = new InvTransaccionDAO();
        InvTipoTransaccionDAO objTipoTransaccionDAO = new InvTipoTransaccionDAO();
        ParametroDAO objParametroDAO = new ParametroDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

        }

        protected void InicializaPagina()
        {
            int linea = 0;

            string id = Request.QueryString["id"].ToString();
            string id2 = Request.QueryString["id2"].ToString();

            Decimal dStockArticulo = 0;
            List<InvTransaccionDTO> objTransaccionLista = objTransaccionDAO.ListarPorArticuloProyecto(Convert.ToInt32(id), Convert.ToInt32(id2));
            ParametroDTO objParametroDTO = objParametroDAO.ListarPorClave(1);
            ArticuloDTO objArticuloDTO = objArticuloDAO.ListarPorClave(Convert.ToInt32(id));
            InvUnidadMedidaDTO objInvUnidadMedidaDTO = objUnidadMedidaDAO.ListarPorClave(objArticuloDTO.IdUnidadMedida);
            ProyectoDTO objProyectoDTO = objProyectoDAO.ListarPorClave(Convert.ToInt32(id2));

            dsReportes dsReporte = new dsReportes();
            dsReportes.ParametroRow drParametroRow = dsReporte.Parametro.NewParametroRow();
            drParametroRow.id_reporte = 1;
            drParametroRow.empresa = objParametroDTO.RazonSocial;
            drParametroRow.fecha = DateTime.Now.ToString("dd/MM/yyyy");
            dsReporte.Parametro.AddParametroRow(drParametroRow);

            foreach (InvTransaccionDTO fila in objTransaccionLista)
            {
                InvTipoTransaccionDTO objInvTipoTransaccionDTO = objTipoTransaccionDAO.ListarPorClave(fila.IdTipoTransaccion);
                dsReportes.KardexRow drKardexRow = dsReporte.Kardex.NewKardexRow();
                linea = linea + 1;
                drKardexRow.id_reporte = 1;
                drKardexRow.linea = linea;
                drKardexRow.fecha = fila.Fecha.ToString("dd/MM/yyyy");
                drKardexRow.nombre_articulo = objArticuloDTO.Descripcion;
                drKardexRow.codigo_articulo = objArticuloDTO.CodigoArticulo;
                drKardexRow.unidad_medida = objInvUnidadMedidaDTO.NombreUnidadMedida;
                drKardexRow.area = objProyectoDTO.NombreProyecto;
                drKardexRow.observaciones = fila.Descripcion;// objInvTipoTransaccionDTO.NombreTransaccion;

                if (objInvTipoTransaccionDTO.Clase.Equals("I"))
                {
                    dStockArticulo += fila.Cantidad;
                    drKardexRow.entrada = fila.Cantidad;
                    drKardexRow.saldo = dStockArticulo;
                }
                else
                {
                    dStockArticulo -= fila.Cantidad;
                    drKardexRow.salida = fila.Cantidad;
                    drKardexRow.saldo = dStockArticulo;
                }
                                
                dsReporte.Kardex.AddKardexRow(drKardexRow);

            }

            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("KardexArticulo.rpt");
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
    }
}