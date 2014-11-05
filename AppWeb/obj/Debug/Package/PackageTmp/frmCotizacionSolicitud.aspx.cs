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
    public partial class frmCotizacionSolicitud : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        CotizacionDAO objCotizacionDAO = new CotizacionDAO();
        PedidoPresupuestoDAO objPedidoPresupuestoDAO = new PedidoPresupuestoDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnCotizar.Attributes.Add("onclick", "return confirm('Desea Ud. iniciar la cotización del pedido?');");

        }

        protected void InicializaPagina()
        {

            if (Session["ID_PEDIDO_COTIZAR"] == null) {
                Response.Redirect("Default.aspx");
            }


            string LoginUsuario = this.txtIdUsuario.Text = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            PedidoDTO obj = null;
            int IdPedido = 0;

            IdPedido = Convert.ToInt32(Session["ID_PEDIDO_COTIZAR"]);
            this.txtIdPedido.Text = IdPedido.ToString();

            if (IdPedido > 0)
            {

                List<PedidoPresupuestoDTO> ListaPedidoPresupuestoDTO = objPedidoPresupuestoDAO.Listar(IdPedido);
                string codigos = "";
                if (ListaPedidoPresupuestoDTO.Count > 0)
                {
                    foreach (PedidoPresupuestoDTO item in ListaPedidoPresupuestoDTO)
                    {
                        codigos = codigos + " " + item.CodigoPresupuesto;
                    }
                }


                obj = objPedidoDAO.ListarPorClave(IdPedido);
                if (obj != null)
                {
                    this.lblIdPedido.Text = obj.IdPedido.ToString();
                    this.txtIdPedido.Text = obj.IdPedido.ToString();
                    this.lblFechaPedido.Text = obj.FechaPedido.ToString("dd/MM/yyyy");
                    this.lblDescripcionPedido.Text = obj.Descripcion;
                    this.lblProyecto.Text = obj.NombreProyecto;
                    this.lblSede.Text = obj.NombreSede;
                    this.lblCodigoPresupuesto.Text = obj.CodigoPresupuesto;
                    this.lblMoneda.Text = obj.NombreMoneda;
                    this.lblNombreSolicitante.Text = obj.NombreSolicitante.ToString();
                    this.lblCodigoPresupuesto.Text = codigos;
                    this.lblEstado.Text = obj.NombreEstado;

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                    this.panPedidoDetalleLineas.Visible = true;


                }

            }
        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {
            int IdCotizacion;
            IdCotizacion = objCotizacionDAO.Generar(Convert.ToInt32(this.txtIdPedido.Text), Convert.ToInt32(this.txtIdUsuario.Text) );
            
            PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_COTIZADO;
            objPedidoDAO.Actualizar(objPedidoDTO);

            Session.Add("ID_COTIZACION", IdCotizacion);
            Response.Redirect("frmCotizacion.aspx");
        }

    }
}