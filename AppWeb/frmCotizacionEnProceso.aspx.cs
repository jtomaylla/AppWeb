using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.ComponentModel;
//using System.Configuration;

using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;
using System.Globalization;

namespace AppWeb
{
    public partial class frmCotizacionEnProceso : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        CotizacionDAO objCotizacionDAO = new CotizacionDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {

            string LoginUsuario = HttpContext.Current.User.Identity.Name;

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            //Lista
            List<CotizacionDTO> Lista = objCotizacionDAO.ListarEnProceso();
            this.gvCotizaciones.DataSource = Lista;
            this.gvCotizaciones.DataBind();

            LlenarModalFiltro(this.gvCotizaciones);

        }

        protected void gvCotizaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdCotizacion = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_COTIZACION", IdCotizacion);
                Response.Redirect("frmCotizacion.aspx");
                
            }
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
            
            //Lista
            List<CotizacionDTO> Lista = objCotizacionDAO.ListarEnProceso();


            DataTable dtobjPedidoLista = this.ConvertToDataTable(Lista);

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
            gvCotizaciones.DataSource = dtview;
            gvCotizaciones.DataBind();

            lstfiltrar.Items.Clear();
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
            columnavalores.Add(new ListItem("Cotización", "int#IdCotizacion"));
            columnavalores.Add(new ListItem("Fecha", "dat#FechaCotizacion"));
            columnavalores.Add(new ListItem("Descripción", "str#DescripcionCotizacion"));
            columnavalores.Add(new ListItem("Mon", "str#CodMoneda"));
            columnavalores.Add(new ListItem("Estado", "str#NombreEstado"));
            columnavalores.Add(new ListItem("Pedido", "int#IdPedido"));
            columnavalores.Add(new ListItem("Proyecto", "str#NombreProyecto"));
            columnavalores.Add(new ListItem("Sede", "str#NombreSede"));
            columnavalores.Add(new ListItem("Solicitante", "str#NombreUsuarioSolicitante"));
            return columnavalores;
        }

        public DataTable ConvertToDataTable(List<CotizacionDTO> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(CotizacionDTO));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (CotizacionDTO item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

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
            List<CotizacionDTO> Lista = objCotizacionDAO.ListarEnProceso();

            ddlfiltrarlistado.DataSource = Lista;
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