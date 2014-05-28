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

using AppWeb.Reporte;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmOrdenCompraLista : System.Web.UI.Page
    {
        IgvDAO objIGVDAO = new IgvDAO();
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            List<OrdenCompraDTO> objLista = objOrdenCompraDAO.Listar();
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdOrdenCompra = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_ORDEN_COMPRA", IdOrdenCompra);
                Response.Redirect("frmOrdenCompra.aspx");
            }

            //if (e.CommandName == "VerPDF")
            //{
            //    FormatoOrdenVenta(IdOrdenCompra);

            //}
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrdenCompraDTO obj = (OrdenCompraDTO)e.Row.DataItem;
                Button btnPDF = (Button)e.Row.FindControl("btnPDF");

                if (obj.EstadoAprobacion == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                {
                    btnPDF.Attributes.Add("onclick", "return js_imprimir_oc(" + obj.IdOrdenCompra + ");");
                }
                else 
                {
                    btnPDF.Visible = false;
                }


            }
           
        }

        private void FormatoOrdenVenta(int IdOrdenCompra) 
        {
  
            //OrdenCompraDTO objOrdenCompra = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);
            //List<OrdenCompraLineaDTO> objOrdenCompraLinea = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);

            //dsReportes dsReporte = new dsReportes();

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


            //CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
            //myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //string strRuta = Server.MapPath("rptOrdenCompra.rpt");
            //myReportDocument.Load(strRuta);
            //myReportDocument.SetDataSource(dsReporte);
            //Session.Add("ReporteCrystal", myReportDocument);
            //Session.Add("FormatoReporte", "PDF");
            
            string strRutaWeb = Request.ApplicationPath;

            //Response.Write("<script language='javascript'>window.open('" + strRutaWeb + "frmVisorReporte.aspx" + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");
            //Response.Write("<script language='javascript'>window.open('" + strRutaWeb + "frmOrdenCompraImpresion.aspx?id=" + IdOrdenCompra.ToString() + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");
            Response.Write("<script language='javascript'>JS_openWindow('" + strRutaWeb + "frmOrdenCompraImpresion.aspx?id=" + IdOrdenCompra.ToString() + "','Reporte','600','300','no', 'no', 'no', 'no', 'no');</script>");


        }
    }
}