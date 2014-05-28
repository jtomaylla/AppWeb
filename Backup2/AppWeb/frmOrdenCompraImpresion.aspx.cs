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


namespace AppWeb
{
    public partial class frmOrdenCompraImpresion : System.Web.UI.Page
    {
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        ProveedorDAO objProveedorDAO = new ProveedorDAO();
        IgvDAO objIGVDAO = new IgvDAO();
        Decimal dSubTotal = 0;
        Decimal dIGV = 0;
        Decimal dTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

        }


        protected void InicializaPagina()
        {
            int IdOrdenCompra;

            string id = Request.QueryString["id"].ToString();

            IdOrdenCompra = Convert.ToInt32(id);

            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);
            ProveedorDTO objProveedorDTO = objProveedorDAO.ListarPorClave(obj.IdProveedor);
            this.lblTitulo1.Text = "ORDEN DE COMPRA NUMERO " + obj.IdOrdenCompra.ToString();
            this.lblTitulo2.Text = "Moneda = " + obj.CodMoneda + ", Fecha = " + obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblRuc.Text = objProveedorDTO.Ruc;
            this.lblDireccion.Text = objProveedorDTO.Direccion;
            this.lblContacto.Text = objProveedorDTO.Contacto;

            /*
            this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblNombreProyecto.Text = obj.NombreProyecto;
            this.lblNombreSede.Text = obj.NombreSede;
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            this.lblNombreMoneda.Text = obj.NombreMoneda;
            this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            */
            IgvDTO IGVDTO = objIGVDAO.ListarIGVVigente(obj.FechaOrdenCompra);
            dSubTotal = obj.ImporteOrdenCompra;
            dIGV = obj.ImporteOrdenCompra * (IGVDTO.Igv)/100;
            dTotal = dSubTotal + dIGV;

            List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrdenCompraLineaDTO obj = (OrdenCompraLineaDTO)e.Row.DataItem;
                Label lblPrecio = (Label)e.Row.FindControl("lblPrecio");
                Label lblImporte = (Label)e.Row.FindControl("lblImporte");
                //lblPrecio.Text = obj.Precio.ToString();
                lblPrecio.Text = String.Format("{0:0,0.00000}", obj.Precio); 

                
                //lblImporte.Text = obj.Importe.ToString();
                lblImporte.Text = String.Format("{0:0,0.00}", obj.Importe); 
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
                Label lblIGV = (Label)e.Row.FindControl("lblIGV");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");

                //lblSubTotal.Text = dSubTotal.ToString();
                //lblIGV.Text = dIGV.ToString();
                //lblTotal.Text = dTotal.ToString();

                lblSubTotal.Text = String.Format("{0:0,0.00}", dSubTotal);
                lblIGV.Text = String.Format("{0:0,0.00}", dIGV);
                lblTotal.Text = String.Format("{0:0,0.00}", dTotal);

            }
        }

    }
}