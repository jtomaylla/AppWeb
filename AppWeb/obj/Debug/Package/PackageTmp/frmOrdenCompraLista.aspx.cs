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

using System.Data;
using AjaxControlToolkit;
using System.ComponentModel;
using System.Globalization;

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
            List<OrdenCompraDTO> objLista = objOrdenCompraDAO.Listar("0");
            
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();
            //gvLista.Columns.RemoveAt(12);
            //gvLista.Columns.RemoveAt(13);
            //gvLista.Columns.RemoveAt(14);
            LlenarModalFiltro(this.gvLista);
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

            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                case DataControlRowType.DataRow:
                    if (chkanulados.Checked)
                    {
                        e.Row.Cells[12].Visible = true;
                        e.Row.Cells[13].Visible = true;
                        e.Row.Cells[14].Visible = true;
                        e.Row.Cells[16].Visible = false;
                    }
                    else
                    {
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                        e.Row.Cells[14].Visible = false;
                        e.Row.Cells[16].Visible = true;
                    }
                    
                    break;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnPDF = (Button)e.Row.FindControl("btnPDF");
                try
                {
                    OrdenCompraDTO obj = (OrdenCompraDTO)e.Row.DataItem;
                    if (obj.EstadoAprobacion == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                    {
                        btnPDF.Attributes.Add("onclick", "return js_imprimir_oc(" + obj.IdOrdenCompra + ");");
                    }
                    else
                    {
                        btnPDF.Visible = false;
                    }
                }
                catch
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    if (dr["EstadoAprobacion"].ToString() == AppConstantes.ESTADO_APROBACION_OC_APROBADO)
                    {
                        btnPDF.Attributes.Add("onclick", "return js_imprimir_oc(" + dr["IdOrdenCompra"].ToString() + ");");
                    }
                    else
                    {
                        btnPDF.Visible = false;
                    }
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
        //modal

        protected void lnkfiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                string[] listavalor;
                listavalor = ddlfiltrar.SelectedValue.Split('#');
                string cadenabusca;
                string valorcomparar;
                if (chkfiltromodal.Checked && ddlfiltrarlistado.SelectedIndex > 0)
                {
                    valorcomparar = ddlfiltrarlistado.SelectedItem.Text;
                }
                else
                {
                    valorcomparar = txtfiltrar.Text;
                }


                switch (listavalor[0])
                {
                    case "int":
                        switch (ddlcondiciones.SelectedValue)
                        {
                            case "1":
                                cadenabusca = listavalor[1] + "=" + valorcomparar;
                                break;
                            case "2":
                                cadenabusca = listavalor[1] + " >= " + valorcomparar;
                                break;
                            case "3":
                                cadenabusca = listavalor[1] + " <= " + valorcomparar;
                                break;
                            default:
                                cadenabusca = listavalor[1] + " like '%" + valorcomparar + "%'";
                                break;
                        }

                        break;
                    case "str":
                        switch (ddlcondiciones.SelectedValue)
                        {
                            case "1":
                                cadenabusca = listavalor[1] + "='" + valorcomparar + "'";
                                break;
                            case "4":
                                cadenabusca = listavalor[1] + " like '%" + valorcomparar + "%'";
                                break;
                            default:
                                cadenabusca = listavalor[1] + " like '%" + valorcomparar + "%'";
                                break;
                        }
                        break;
                    case "dat":
                        CultureInfo culture = new CultureInfo("es-ES");
                        DateTime fechavalor = Convert.ToDateTime(valorcomparar.Substring(0, 10), culture);
                        switch (ddlcondiciones.SelectedValue)
                        {
                            case "1":
                                cadenabusca = listavalor[1] + " >= #" + fechavalor.Month.ToString() + "/" + fechavalor.Day.ToString() + "/" + fechavalor.Year.ToString() + " 00:00:00#" + " AND " +
                            listavalor[1] + " <= #" + fechavalor.Month.ToString() + "/" + fechavalor.Day.ToString() + "/" + fechavalor.Year.ToString() + " 23:59:59#";
                                break;
                            case "2":
                                cadenabusca = listavalor[1] + " >= #" + fechavalor.Month.ToString() + "/" + fechavalor.Day.ToString() + "/" + fechavalor.Year.ToString() + " 00:00:00#";
                                break;
                            case "3":
                                cadenabusca = listavalor[1] + " <= #" + fechavalor.Month.ToString() + "/" + fechavalor.Day.ToString() + "/" + fechavalor.Year.ToString() + " 23:59:59#";
                                break;
                            default:
                                cadenabusca = listavalor[1] + " like '%" + valorcomparar + "%'";
                                break;
                        }

                        break;
                    default:
                        cadenabusca = listavalor[1] + " like '%" + valorcomparar + "%'";
                        break;
                }

                lstfiltrar.Items.Add(cadenabusca);

                //ddlfiltrar.SelectedIndex = 0;
                ddlfiltrarlistado.SelectedIndex = 0;
                txtfiltrar.Text = "";
            }
            catch
            {
                lblmensaje.ForeColor = System.Drawing.Color.Red;
                lblmensaje.Text = "Verifique los valores";
            }

        }

        protected void lnkaceptarfiltro_Click(object sender, EventArgs e)
        {
            List<OrdenCompraDTO> objLista = new List<OrdenCompraDTO>();
            //Lista
            if (chkanulados.Checked)
            {
                objLista = objOrdenCompraDAO.Listar("1");
            }
            else
            {
                objLista = objOrdenCompraDAO.Listar("0");
            }
            


            DataTable dtobjPedidoLista = this.ConvertToDataTable(objLista);

            DataView dtview = dtobjPedidoLista.DefaultView;
            //dtview.Sort = "IDPEDIDO DESC";
            string cadenafiltro;
            cadenafiltro = "";
            int cuenta;
            cuenta = 0;
            string condicion;
            foreach (ListItem filtros in lstfiltrar.Items)
            {
                if (!(cuenta == 0))
                {
                    condicion = " and ";
                }
                else
                {
                    condicion = "";
                }
                cadenafiltro = cadenafiltro + condicion + filtros.Text;
                cuenta = cuenta + 1;

            }
            dtview.RowFilter = cadenafiltro;
            gvLista.DataSource = dtview;
            gvLista.DataBind();

            //lstfiltrar.Items.Clear();
            lblmensaje.Text = "";
            modalfiltrar.Hide();
        }

        protected void lnkfiltrocerrar_Click(object sender, EventArgs e)
        {
            this.modalfiltrar.Hide();
        }

        protected void lnkcancelarfiltro_Click(object sender, EventArgs e)
        {
            ddlfiltrar.SelectedIndex = 0;
            txtfiltrar.Text = "";
            lstfiltrar.Items.Clear();
            lblmensaje.Text = "";
        }

        private void LlenarModalFiltro(GridView dt)
        {
            List<ListItem> listado = new List<ListItem>();
            listado = this.ListaColumnas();

            foreach (ListItem litem in listado)
            {
                ddlfiltrar.Items.Add(litem);
            }
            ddlfiltrar.Items.Insert(0, "Seleccione");
        }

        private List<ListItem> ListaColumnas()
        {
            List<ListItem> columnavalores = new List<ListItem>();
            columnavalores.Add(new ListItem("O/C", "int#IdOrdenCompra"));
            columnavalores.Add(new ListItem("Tipo", "str#NombreTipoOrdenCompra"));
            columnavalores.Add(new ListItem("Proyecto", "str#NombreProyecto"));
            columnavalores.Add(new ListItem("Sede", "str#NombreSede"));
            columnavalores.Add(new ListItem("Proveedor", "str#RazonSocial"));
            columnavalores.Add(new ListItem("Fecha", "dat#FechaOrdenCompra"));
            columnavalores.Add(new ListItem("Descripción", "str#DescripcionOrdenCompra"));
            columnavalores.Add(new ListItem("Mon", "str#CodMoneda"));
            columnavalores.Add(new ListItem("Importe", "int#ImporteOrdenCompra"));
            columnavalores.Add(new ListItem("Estado", "str#NombreEstadoControl"));
            columnavalores.Add(new ListItem("EstadoAprob", "str#NombreEstadoAprobacion"));
            columnavalores.Add(new ListItem("EnvProv", "str#EnviadoProveedor"));
            return columnavalores;
        }

        public DataTable ConvertToDataTable(List<OrdenCompraDTO> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(OrdenCompraDTO));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (OrdenCompraDTO item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvLista.PageIndex = e.NewPageIndex;
            List<OrdenCompraDTO> objLista = new List<OrdenCompraDTO>();

            if (lstfiltrar.Items.Count == 0)
            {
                if (chkanulados.Checked)
                {
                    objLista = objOrdenCompraDAO.Listar("1");
                }
                else
                {
                    objLista = objOrdenCompraDAO.Listar("0");
                }
                
                this.gvLista.DataSource = objLista;
                this.gvLista.DataBind();
            }
            else
            {

                if (chkanulados.Checked)
                {
                    objLista = objOrdenCompraDAO.Listar("1");
                }
                else
                {
                    objLista = objOrdenCompraDAO.Listar("0");
                }

                


                DataTable dtobjPedidoLista = this.ConvertToDataTable(objLista);

                DataView dtview = dtobjPedidoLista.DefaultView;
                //dtview.Sort = "IDPEDIDO DESC";
                string cadenafiltro;
                cadenafiltro = "";
                int cuenta;
                cuenta = 0;
                string condicion;
                foreach (ListItem filtros in lstfiltrar.Items)
                {
                    if (!(cuenta == 0))
                    {
                        condicion = " and ";
                    }
                    else
                    {
                        condicion = "";
                    }
                    cadenafiltro = cadenafiltro + condicion + filtros.Text;
                    cuenta = cuenta + 1;

                }
                dtview.RowFilter = cadenafiltro;
                gvLista.DataSource = dtview;
                gvLista.DataBind();

                //lstfiltrar.Items.Clear();
                
                
            }
        }

        protected void chkanulados_CheckedChanged(object sender, EventArgs e)
        {
            List<OrdenCompraDTO> objLista = new List<OrdenCompraDTO>();

            if (lstfiltrar.Items.Count == 0)
            {
                if (chkanulados.Checked)
                {
                    objLista = objOrdenCompraDAO.Listar("1");
                }
                else
                {
                    objLista = objOrdenCompraDAO.Listar("0");
                }

                this.gvLista.DataSource = objLista;
                this.gvLista.DataBind();
            }
            else
            {

                if (chkanulados.Checked)
                {
                    objLista = objOrdenCompraDAO.Listar("1");
                }
                else
                {
                    objLista = objOrdenCompraDAO.Listar("0");
                }




                DataTable dtobjPedidoLista = this.ConvertToDataTable(objLista);

                DataView dtview = dtobjPedidoLista.DefaultView;
                //dtview.Sort = "IDPEDIDO DESC";
                string cadenafiltro;
                cadenafiltro = "";
                int cuenta;
                cuenta = 0;
                string condicion;
                foreach (ListItem filtros in lstfiltrar.Items)
                {
                    if (!(cuenta == 0))
                    {
                        condicion = " and ";
                    }
                    else
                    {
                        condicion = "";
                    }
                    cadenafiltro = cadenafiltro + condicion + filtros.Text;
                    cuenta = cuenta + 1;

                }
                dtview.RowFilter = cadenafiltro;
                gvLista.DataSource = dtview;
                gvLista.DataBind();

                //lstfiltrar.Items.Clear();


            }
        }


        private void LlenarCombocondiciones(string tipodato)
        {
            ddlcondiciones.Items.Clear();
            switch (tipodato)
            {
                case "int":
                    ddlcondiciones.Items.Add(new ListItem("igual a", "1"));
                    ddlcondiciones.Items.Add(new ListItem("mayor igual a", "2"));
                    ddlcondiciones.Items.Add(new ListItem("menor igual a", "3"));
                    break;
                case "str":
                    ddlcondiciones.Items.Add(new ListItem("igual a", "1"));
                    ddlcondiciones.Items.Add(new ListItem("contiene a", "4"));
                    break;
                case "dat":
                    ddlcondiciones.Items.Add(new ListItem("igual a", "1"));
                    ddlcondiciones.Items.Add(new ListItem("mayor igual a", "2"));
                    ddlcondiciones.Items.Add(new ListItem("menor igual a", "3"));
                    break;
            }
            ddlcondiciones.Items.Insert(0, new ListItem("Seleccione", "0"));

        }


        protected void ddlfiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ddlfiltrar.SelectedValue.Substring(0, 3);
            this.LlenarCombocondiciones(valor);
            string[] listavalor;
            listavalor = ddlfiltrar.SelectedValue.Split('#');
            //string cadenabusca;
            this.LlenarListadoSegunColumna(listavalor[1]);

        }

        protected void chkfiltromodal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfiltromodal.Checked)
            {
                txtfiltrar.Visible = false;
                ddlfiltrarlistado.Visible = true;

            }
            else
            {
                txtfiltrar.Visible = true;
                ddlfiltrarlistado.Visible = false;
                ddlfiltrarlistado.Items.Clear();
            }
        }

        private void LlenarListadoSegunColumna(string columna)
        {

            //listar lineas
            List<OrdenCompraDTO> objLista = objOrdenCompraDAO.Listar("0");

            ddlfiltrarlistado.DataSource = objLista;
            ddlfiltrarlistado.DataTextField = columna;
            ddlfiltrarlistado.DataBind();

            //quitando duplicados
            List<string> sindupli = new List<string>();
            foreach (ListItem fila in ddlfiltrarlistado.Items)
            {

                sindupli.Add(fila.Text);

            }
            ddlfiltrarlistado.Items.Clear();
            IEnumerable<string> filtrado = sindupli.Distinct();

            foreach (string valor in filtrado)
            {
                ddlfiltrarlistado.Items.Add(valor);
            }

            ddlfiltrarlistado.Items.Insert(0, "Seleccione");

        }
    }
}