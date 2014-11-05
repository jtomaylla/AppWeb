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
    public partial class ReportePedido : System.Web.UI.Page
    {


        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();

        CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;

        protected void Page_Load(object sender, EventArgs e)
        {

            string strFormatoReporte = "PDF";  //PDF, XLS, DOC

            if (Session["FormatoReporte"] != null) strFormatoReporte = Session["FormatoReporte"].ToString();

            MemoryStream stream = new MemoryStream();
            myReportDocument = (CrystalDecisions.CrystalReports.Engine.ReportDocument)Session["ReporteCrystal"];

            switch (strFormatoReporte)
            {
                case "PDF":
                    stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.ContentType = "application/pdf";
                    break;
                case "XLS":
                    stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
                    Response.ContentType = "application/vnd.ms-excel";
                    break;
                case "DOC":
                    stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                    Response.ContentType = "application/doc";
                    break;
                default:
                    stream = (MemoryStream)myReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.ContentType = "application/pdf";
                    break;
            }


            myReportDocument.Close();
            myReportDocument.Dispose();

            //Escribir PDF
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/pdf";

            Response.BinaryWrite(stream.ToArray());
            Response.End();

            stream.Flush();
            stream.Close();
            stream.Dispose();

        }

    }
}