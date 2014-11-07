using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;

using AjaxControlToolkit;
using System.Globalization;

namespace AppWeb
{
    public partial class frmPedidoLista : System.Web.UI.Page
    {

        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

        }



        protected void InicializaPagina()
        {

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            //listar lineas
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);
            this.gvPedidoLista.DataSource = objPedidoLista;            
            this.gvPedidoLista.DataBind();
            LlenarModalFiltro(this.gvPedidoLista);
        }

        

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("ID_PEDIDO", "0");
            Response.Redirect("frmPedido.aspx?accion=new");
        }

        protected void gvPedidoLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdPedido = int.Parse(e.CommandArgument.ToString());
            PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(IdPedido);
    
            if (e.CommandName == "Seleccionar")
            {
                if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                {

                    UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

                    if (objUsuario.IdUsuario == objPedidoDTO.IdUsuarioCreacion)
                    {
                        Session.Add("ID_PEDIDO", IdPedido);
                        Response.Redirect("frmPedido.aspx?accion=edit");
                    }
                    else
                    {
                        Session.Add("ID_PEDIDO_CONSULTA", IdPedido);
                        Response.Redirect("frmPedidoConsulta.aspx");
                    }
                }
                else
                {
                    Session.Add("ID_PEDIDO_CONSULTA", IdPedido);
                    Response.Redirect("frmPedidoConsulta.aspx");
                }

            }
            else
                if (e.CommandName == "Eliminar")
                {

                }
        }

        protected void gvPedidoLista_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            this.gvPedidoLista.PageIndex = e.NewPageIndex;
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);
            this.gvPedidoLista.DataSource = objPedidoLista;
            this.gvPedidoLista.DataBind();
        }

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
                        DateTime fechavalor = Convert.ToDateTime(valorcomparar.Substring(0,10), culture);
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
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);
            DataTable dtobjPedidoLista = ConvertToDataTable(objPedidoLista);

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
            gvPedidoLista.DataSource = dtview;
            gvPedidoLista.DataBind();

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
            columnavalores.Add(new ListItem("Pedido", "int#IdPedido"));
            columnavalores.Add(new ListItem("Tipo", "str#NombreTipoPedido"));
            columnavalores.Add(new ListItem("Proyecto", "str#NombreProyecto"));
            columnavalores.Add(new ListItem("Solicitante", "str#NombreSolicitante"));
            columnavalores.Add(new ListItem("Moneda", "str#CodMoneda"));
            columnavalores.Add(new ListItem("Descripción", "str#Descripcion"));
            columnavalores.Add(new ListItem("Fecha", "dat#FechaPedido"));
            columnavalores.Add(new ListItem("Estado", "str#NombreEstado"));
            columnavalores.Add(new ListItem("FechaAprob", "dat#FechaAprobacionTexto"));
            columnavalores.Add(new ListItem("EstadoControl", "str#NombreEstadoControl"));
            columnavalores.Add(new ListItem("O/C", "str#OrdenCompra"));
            return columnavalores;
        }

        public DataTable ConvertToDataTable(List<PedidoDTO> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(PedidoDTO));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (PedidoDTO item in data)
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
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            //listar lineas
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);

            ddlfiltrarlistado.DataSource = objPedidoLista;
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