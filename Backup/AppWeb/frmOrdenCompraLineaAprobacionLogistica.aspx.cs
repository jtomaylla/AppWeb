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
    public partial class frmOrdenCompraLineaAprobacionLogistica : System.Web.UI.Page
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

            this.btnActualizar.Attributes.Add("onclick","return js_validar();");
            this.btnAprobar.Attributes.Add("onclick", "return js_validar_aprobar();");
            
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
            this.lblTipoOrdenCompra.Text = obj.NombreTipoOrdenCompra;
            this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblNombreProyecto.Text = obj.NombreProyecto;
            this.lblNombreSede.Text = obj.NombreSede;
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            this.lblNombreMoneda.Text = obj.NombreMoneda;
            this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            this.lblEstadoAprobacion.Text = obj.NombreEstadoAprobacion;

            this.txtDescripcionOC.Text = obj.DescripcionOrdenCompra;

            if (obj.FechaEntrega.Year == 1)
                this.txtFechaEntrega.Text = "";
            else
                this.txtFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");
            
            this.ddlFormaPago.Items.Clear();

            List<FormaPagoDTO> ListaFormaPagoDTO;
            SedeDAO objDAO = new SedeDAO();

            try
            {
                ListaFormaPagoDTO = objFormaPagoDAO.Listar();
                this.ddlFormaPago.DataSource = ListaFormaPagoDTO;
                this.ddlFormaPago.DataTextField = "NombreFormaPago";
                this.ddlFormaPago.DataValueField = "IdFormaPago";
                this.ddlFormaPago.DataBind();
                this.ddlFormaPago.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }
            
            foreach (ListItem li_item in this.ddlFormaPago.Items)
            {
                if (Convert.ToString(li_item.Value) == obj.IdFormaPago.ToString())
                    li_item.Selected = true;
            }

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

                Actualizar();

                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

                int IdOrdenCompra = Convert.ToInt32(this.txtIdOrdenCompra.Text);
                OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);
                
                OrdenCompraNivelAprobacionDTO objOrdenCompraNivelAprobacionDTO = objOrdenCompraNivelAprobacionDAO.ObtenerAprobadorOrdenCompra(
                            objOrdenCompraDTO.ImporteOrdenCompra,
                            objOrdenCompraDTO.CodMoneda
                            );
                
                objOrdenCompraDTO.EstadoAprobacion = AppConstantes.ESTADO_APROBACION_OC_ENPROCESO;
                //objOrdenCompraDTO.FechaAprobacion = DateTime.Now;
                objOrdenCompraDTO.IdUsuarioAprobacion = objOrdenCompraNivelAprobacionDTO.IdUsuarioAprobacion;
                objOrdenCompraDTO.FechaModificacion = DateTime.Now;
                objOrdenCompraDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                objOrdenCompraDAO.Actualizar(objOrdenCompraDTO);


                CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(objOrdenCompraDTO.IdCotizacion);
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
                objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_EN_APROBACION_OC;
                //objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_PENDIENTE_ENVIO_PROVEEDOR;

                objPedidoDAO.Actualizar(objPedidoDTO);

                Response.Redirect("frmOrdenCompraAprobacionLogistica.aspx");

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
                    
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            this.lblError.Text = "";

            try
            {
                Actualizar();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
                        
        }

        protected void Actualizar() 
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(Convert.ToInt32(this.lblIdOrdenCompra.Text));

            objOrdenCompraDTO.DescripcionOrdenCompra = this.txtDescripcionOC.Text;
            objOrdenCompraDTO.IdFormaPago = Convert.ToInt32(this.ddlFormaPago.SelectedValue);

            if (this.txtFechaEntrega.Text.Length > 0)
                objOrdenCompraDTO.FechaEntrega = AppUtilidad.stringToDateTime(this.txtFechaEntrega.Text, "DD/MM/YYYY");
            else
                objOrdenCompraDTO.FechaEntrega = AppUtilidad.stringToDateTime("01/01/0001", "DD/MM/YYYY");

            if (this.chkIGV.Checked)
                objOrdenCompraDTO.FlagIGV = "1";
            else
                objOrdenCompraDTO.FlagIGV = "0";

            objOrdenCompraDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
            objOrdenCompraDTO.FechaModificacion = DateTime.Now;

            objOrdenCompraDAO.Actualizar(objOrdenCompraDTO);
        
        }
    
    }
}