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

//using pe.com.seg.dal.dto;
//using pe.com.seg.dal.dao;
//using pe.com.sil.dal.dao;
using System.Data;


namespace AppWeb
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        ListadoArtDAO objListado = new ListadoArtDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            
            //myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("ListadoArticulos.rpt");
            myReportDocument.Load(strRuta);

            DataTable dt = objListado.ListarTodos();
            myReportDocument.SetDataSource(dt);

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Listado");
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string strRuta = Server.MapPath("ListadoArticulos.rpt");
            myReportDocument.Load(strRuta);

            DataTable dt = objListado.ListarTodos();
            myReportDocument.SetDataSource(dt);

            myReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, false, "Listado");
        }
    }
}