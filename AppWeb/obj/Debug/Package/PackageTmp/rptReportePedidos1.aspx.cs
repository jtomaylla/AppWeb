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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using pe.com.rbtec.web;
namespace AppWeb
{
    public partial class rptReportePedidos1 : System.Web.UI.Page
    {

        PedidoDAO objPedidoDAO = new PedidoDAO();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            crvReporte.Visible = true;
            string fechainicial = Request.QueryString["fechainicial"].ToString();
            string fechafinal = Request.QueryString["fechafinal"].ToString();
            string idsede = Request.QueryString["idsede"].ToString();
            string idproyecto = Request.QueryString["idproyecto"].ToString();
            string idestado = Request.QueryString["idestado"].ToString();

            ds = objPedidoDAO.ListarReportePedidos(AppUtilidad.stringToDateTime(fechainicial, "DD/MM/YYYY"),
                                                   AppUtilidad.stringToDateTime(fechafinal, "DD/MM/YYYY"),
                                                   Convert.ToInt32(idsede),
                                                   Convert.ToInt32(idproyecto),
                                                   idestado);


            dt = ds.Tables[0];
            CrystalDecisions.CrystalReports.Engine.ReportDocument rDoc;
            rDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rDoc.Load(Server.MapPath("rptReportePedidos.rpt")); // Your .rpt file path
            rDoc.SetDataSource(dt); //set dataset to the report viewer.
            rDoc.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Listado");

        }

        protected void crvReporte_Unload(object sender, EventArgs e)
        {
            //myReportDocument.Close();
            //myReportDocument.Dispose(); 
        }

        protected void crvReporte_Init(object sender, EventArgs e)
        {

        }

 
    }
}