using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmInventarioArticulo : System.Web.UI.Page
    {
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        InvUnidadMedidaDAO objUnidadMedidaDAO = new InvUnidadMedidaDAO();
        InvTransaccionDAO objTransaccionDAO = new InvTransaccionDAO();
        InvTipoTransaccionDAO objTipoTransaccionDAO = new InvTipoTransaccionDAO();
        Decimal dStock = 0;
        ProyectoDAO objProyectoDAO = new ProyectoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnBuscar.Attributes.Add("onclick", "return js_validar_busqueda();");
            this.btnKardex.Attributes.Add("onclick", "return js_imprimir_kardex();");
            this.btnlistadoart.Attributes.Add("onclick", "return js_imprimir_listado();");
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            pnlBusqueda.Visible = false;
            pnlPrincipal.Visible = true;
            //UNIDAD DE MEDIDA
            List<InvUnidadMedidaDTO> objUnidadMedidaLista = objUnidadMedidaDAO.Listar();
            this.ddlUnidad.DataSource = objUnidadMedidaLista;
            this.ddlUnidad.DataTextField = "NombreUnidadMedida";
            this.ddlUnidad.DataValueField = "IdUnidadMedida";
            this.ddlUnidad.DataBind();

            try
            {
                List<ProyectoDTO> ListaProyectoDTO = objProyectoDAO.ListarOrdenPorNombre();
                this.ddlProyecto.DataSource = ListaProyectoDTO;
                this.ddlProyecto.DataTextField = "NombreProyecto";
                this.ddlProyecto.DataValueField = "IdProyecto";
                this.ddlProyecto.DataBind();
                this.ddlProyecto.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloDTO obj;

            this.lblMensaje.Text = "";

            try
            {
                int idArticulo = Convert.ToInt32(gvLista.SelectedRow.Cells[0].Text);
                obj = objArticuloDAO.ListarPorClave(idArticulo);

                this.txtIdArticulo.Text = obj.IdArticulo.ToString();
                this.txtArticulo.Text = obj.CodigoArticulo.ToString();
                this.txtDescripcion.Text = obj.Descripcion;

                this.ddlUnidad.SelectedValue = obj.IdUnidadMedida.ToString();

                //CARGAR TRANSACCION
                List<InvTransaccionDTO> objTransaccion = objTransaccionDAO.ListarPorArticuloProyecto(obj.IdArticulo, Convert.ToInt32(this.ddlProyecto.SelectedValue));
                this.gvTransaccion.DataSource = objTransaccion;
                this.gvTransaccion.DataBind();

                txtStockActual.Text = dStock.ToString();

                pnlBusqueda.Visible = false;
                pnlPrincipal.Visible = true;
            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.pnlBusqueda.Visible = false;
            this.pnlPrincipal.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = true;
            pnlPrincipal.Visible = false;

            //BUSCAR ARTICULO
            String strBusqueda = txtArticuloDesc.Text;
            List<ArticuloDTO> articulos = objArticuloDAO.ListarBusquedaPorProyecto(strBusqueda, Convert.ToInt32(this.ddlProyecto.SelectedValue));
            this.gvLista.DataSource = articulos;
            this.gvLista.DataBind();

            
        }

        protected void gvTransaccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                InvTransaccionDTO fila = (InvTransaccionDTO)e.Row.DataItem;
                Label lblTransaccion = (Label)e.Row.FindControl("lblTransaccion");
                Label lblIngreso = (Label)e.Row.FindControl("lblIngreso");
                Label lblSalida = (Label)e.Row.FindControl("lblSalida");
                InvTipoTransaccionDTO tipo = objTipoTransaccionDAO.ListarPorClave(fila.IdTipoTransaccion);
                lblTransaccion.Text = tipo.NombreTransaccion;
                if (tipo.Clase.Equals("I"))
                {
                    lblIngreso.Text = fila.Cantidad.ToString();
                    lblSalida.Text = "0";
                    dStock += fila.Cantidad;
                }
                else
                {
                    lblIngreso.Text = "0";
                    lblSalida.Text = fila.Cantidad.ToString();
                    dStock -= fila.Cantidad;
                }
            }
        }

        protected void btnKardex_Click(object sender, EventArgs e)
        {
            Decimal dStockArticulo = 0;
            List<InvTransaccionDTO> objTransaccionLista = objTransaccionDAO.ListarPorArticuloProyecto(Convert.ToInt32(this.txtIdArticulo.Text), Convert.ToInt32(this.ddlProyecto.SelectedValue));


            foreach (InvTransaccionDTO fila in objTransaccionLista) 
            {
                InvTipoTransaccionDTO tipo = objTipoTransaccionDAO.ListarPorClave(fila.IdTipoTransaccion);
                
                if (tipo.Clase.Equals("I"))
                {
   
                    dStockArticulo += fila.Cantidad;
                }
                else
                {

                    dStockArticulo -= fila.Cantidad;
                }


            }

        }

        protected void btnlistadoart_Click(object sender, EventArgs e)
        {

        }
    }
}