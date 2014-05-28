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
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmOrdenCompraAprobacion : System.Web.UI.Page
    {

        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        FormaPagoDAO objFormaPagoDAO = new FormaPagoDAO();
        OrdenCompraNivelAprobacionDAO objOrdenCompraNivelAprobacionDAO = new OrdenCompraNivelAprobacionDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnAprobar.Attributes.Add("onclick", "return js_validar_aprobar();");

        }

        protected void InicializaPagina()
        {
            int IdOrdenCompra;

            if (Session["ID_ORDEN_COMPRA_APROBACION"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            IdOrdenCompra = Convert.ToInt32(Session["ID_ORDEN_COMPRA_APROBACION"]);

            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblTipoOrdenCompra.Text = obj.NombreTipoOrdenCompra;
            this.lblNombreProyecto.Text = obj.NombreProyecto;
            this.lblNombreSede.Text = obj.NombreSede;
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            this.lblNombreMoneda.Text = obj.NombreMoneda;
            this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            this.lblEstadoAprobacion.Text = obj.NombreEstadoAprobacion;

            this.lblDescripcionOC.Text = obj.DescripcionOrdenCompra;

            if (obj.FechaEntrega.Year == 1)
                this.lblFechaEntrega.Text = "";
            else
                this.lblFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");

            FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(obj.IdFormaPago);

            this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;

            if (obj.FlagIGVBool)
                this.chkIGV.Checked = true;
            else
                this.chkIGV.Checked = false;

            List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";

            try
            {

                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

                int IdOrdenCompra = Convert.ToInt32(this.txtIdOrdenCompra.Text);
                OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

                objOrdenCompraDTO.EstadoAprobacion = AppConstantes.ESTADO_APROBACION_OC_APROBADO;
                objOrdenCompraDTO.FechaAprobacion = DateTime.Now;
                objOrdenCompraDTO.FechaModificacion = DateTime.Now;
                objOrdenCompraDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                objOrdenCompraDAO.Actualizar(objOrdenCompraDTO);

                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompraDTO.IdCotizacion);
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_PENDIENTE_ENVIO_PROVEEDOR;

                objPedidoDAO.Actualizar(objPedidoDTO);

                Response.Redirect("frmOrdenCompraAprobacionLista.aspx");

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }

        }
    
    }
}