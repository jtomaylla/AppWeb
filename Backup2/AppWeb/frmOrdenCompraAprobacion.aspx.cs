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
        OrdenCompraAprobadorDAO objOrdenCompraAprobadorDAO = new OrdenCompraAprobadorDAO();

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
            this.lblError.Text = "";

            try
            {

                int IdOrdenCompra;

                if (Session["ID_ORDEN_COMPRA_APROBACION"] == null)
                {
                    Response.Redirect("Default.aspx");
                }

                IdOrdenCompra = Convert.ToInt32(Session["ID_ORDEN_COMPRA_APROBACION"]);

                OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

                this.txtIdOrdenCompra.Text = objOrdenCompraDTO.IdOrdenCompra.ToString();
                this.lblTipoOrdenCompra.Text = objOrdenCompraDTO.NombreTipoOrdenCompra;
                this.lblNombreProyecto.Text = objOrdenCompraDTO.NombreProyecto;
                this.lblNombreSede.Text = objOrdenCompraDTO.NombreSede;
                this.lblRazonSocial.Text = objOrdenCompraDTO.RazonSocial;
                this.lblFechaOrdenCompra.Text = objOrdenCompraDTO.FechaOrdenCompra.ToString("dd/MM/yyyy");
                this.lblNombreMoneda.Text = objOrdenCompraDTO.NombreMoneda;
                this.lblImporte.Text = objOrdenCompraDTO.ImporteOrdenCompra.ToString();
                this.lblEstadoAprobacion.Text = objOrdenCompraDTO.NombreEstadoAprobacion;
                this.lblDescripcionOC.Text = objOrdenCompraDTO.DescripcionOrdenCompra;

                if (objOrdenCompraDTO.FechaEntrega.Year == 1)
                    this.lblFechaEntrega.Text = "";
                else
                    this.lblFechaEntrega.Text = objOrdenCompraDTO.FechaEntrega.ToString("dd/MM/yyyy");

                FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(objOrdenCompraDTO.IdFormaPago);

                this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;

                if (objOrdenCompraDTO.FlagIGVBool)
                    this.chkIGV.Checked = true;
                else
                    this.chkIGV.Checked = false;

                List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(objOrdenCompraDTO.IdOrdenCompra);
                this.gvLista.DataSource = objLista;
                this.gvLista.DataBind();

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

            this.lblError.Text = "";

            try
            {
                DateTime fechaAprobacion = DateTime.Now;
                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

                int IdOrdenCompra = Convert.ToInt32(this.txtIdOrdenCompra.Text);

                //Actualiza O/C
                OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);
                objOrdenCompraDTO.IdUsuarioAprobacion = objUsuarioDTO.IdUsuario;
                objOrdenCompraDTO.EstadoAprobacion = AppConstantes.ESTADO_APROBACION_OC_APROBADO;
                objOrdenCompraDTO.FechaAprobacion = fechaAprobacion;
                objOrdenCompraDTO.FechaModificacion = DateTime.Now;
                objOrdenCompraDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                objOrdenCompraDAO.Actualizar(objOrdenCompraDTO);

                //Actualiza Pedido
                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompraDTO.IdCotizacion);
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_PENDIENTE_ENVIO_PROVEEDOR;
                objPedidoDAO.Actualizar(objPedidoDTO);

                //Actualiza Aprobador
                List<OrdenCompraAprobadorDTO> ListaOrdenCompraAprobadorDTO = objOrdenCompraAprobadorDAO.ListarPorOrdenCompra(objOrdenCompraDTO.IdOrdenCompra);
                foreach (OrdenCompraAprobadorDTO reg in ListaOrdenCompraAprobadorDTO)
                {
                    if (reg.IdUsuarioAprobacion == objOrdenCompraDTO.IdUsuarioAprobacion)
                    {
                        reg.FechaAprobacion = fechaAprobacion;
                        objOrdenCompraAprobadorDAO.Actualizar(reg);
                    }
                }

                Response.Redirect("frmOrdenCompraAprobacionLista.aspx");

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }

        }
    
    }
}