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
    public partial class frmOrdenCompra : System.Web.UI.Page
    {
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        FormaPagoDAO objFormaPagoDAO = new FormaPagoDAO();

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

            if (Session["ID_ORDEN_COMPRA"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            IdOrdenCompra = Convert.ToInt32(Session["ID_ORDEN_COMPRA"]);

            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblNombreProyecto.Text = obj.NombreProyecto;
            this.lblNombreSede.Text = obj.NombreSede;
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            this.lblNombreMoneda.Text = obj.NombreMoneda;
            //this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            this.lblEstadoAprobacion.Text = obj.NombreEstadoAprobacion;
            this.lblDescripcionOC.Text = obj.DescripcionOrdenCompra;
            decimal total = 0;
            if (obj.FlagIGV == "1")
            {
                this.lblflagigv.Text = "SI";
                total = obj.ImporteOrdenCompra * System.Convert.ToDecimal(1.18);
                this.lblImporte.Text = Math.Round(total, 2).ToString(); 
            }
            else
            {
                this.lblflagigv.Text = "NO";
                this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            }
                

            if (obj.FechaEntrega.Year == 1)
                this.lblFechaEntrega.Text = "";
            else
                this.lblFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");

            FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(obj.IdFormaPago);

            if (objFormaPagoDTO!=null)
                this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;

            List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

        }
  
    }
}