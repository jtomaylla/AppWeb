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
    public partial class frmOrdenCompraLineaEnvioProveedor : System.Web.UI.Page
    {

        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        FormaPagoDAO objFormaPagoDAO = new FormaPagoDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnAprobar.Attributes.Add("onclick", "return confirm('Desea Ud. Enviar la Orden de Compra');");

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

            this.lblDescripcionOC.Text = obj.DescripcionOrdenCompra;
            if (obj.FechaEntrega.Year == 1)
                this.lblFechaEntrega.Text = "";
            else
                this.lblFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");

            FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(obj.IdFormaPago);
            if (objFormaPagoDTO != null)
                this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;

            List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            int IdOrdenCompra = Convert.ToInt32(this.txtIdOrdenCompra.Text);
            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            //Actualizar Cabecera de O/C
            obj.EnviadoProveedor = AppConstantes.FLAG_SI;
            obj.FechaEnvioProveedor = DateTime.Now;
            obj.ComentariosEnvioProveedor = this.txtComentarios.Text;
            obj.FechaModificacion = DateTime.Now;
            obj.IdUsuarioAprobacion = objUsuario.IdUsuario;
            objOrdenCompraDAO.Actualizar(obj);
            
            CotizacionDTO objCotizacionDTO = objCotizacionDAO.ListarPorClave(obj.IdCotizacion);
            PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objCotizacionDTO.IdPedido);
            objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_OC_ENVIADO_PROVEEDOR;
            objPedidoDAO.Actualizar(objPedidoDTO);

            // Envio por email
            
            //Retornar a Lista
            Response.Redirect("frmOrdenCompraEnvioProveedor.aspx");

        }
 

    }
}