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
    public partial class frmPedidoLineaAprobacionResponsable : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnEnviarAprobar.Attributes.Add("onclick", "return confirm('Desea Ud. Aprobar el Pedido?');");
            this.btnRechazar.Attributes.Add("onclick", "return confirm('Desea Ud. Rechazar el Pedido?');");
            this.btnCodigoPresupuesto.Attributes.Add("onclick", "return js_codigo_presupuesto();");

        }

        protected void InicializaPagina()
        {

            string LoginUsuario = this.txtIdUsuario.Text = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            PedidoDTO obj = null;
            int IdPedido;

            if (Session["id_pedido"] == null)
            {
                IdPedido = 0;
            }
            else
            {
                IdPedido = Convert.ToInt32(Session["id_pedido"]);
                this.txtIdPedido.Text = IdPedido.ToString();
            }

            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            if (IdPedido > 0)
            {
                obj = objPedidoDAO.ListarPorClave(IdPedido);
                if (obj != null)
                {
                    this.txtIdPedido.Text = obj.IdPedido.ToString();
                    this.lblFechaPedido.Text = obj.FechaPedido.ToString("dd/MM/yyyy");
                    this.lblDescripcionPedido.Text = obj.Descripcion;
                    this.lblProyecto.Text = obj.NombreProyecto;
                    this.lblSede.Text = obj.NombreSede;
                    this.lblNombreSolicitante.Text= obj.NombreSolicitante;
                    this.lblMoneda.Text = obj.NombreMoneda;
                    this.lblEstado.Text = obj.NombreEstado;
                    this.lblTipoPedido.Text = obj.NombreTipoPedido;
                    if (obj.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                    {
                        this.btnCodigoPresupuesto.Enabled = false;
                    }

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                    this.panPedidoDetalleLineas.Visible = true;
                    
                    if (obj.Estado != AppConstantes.ESTADO_PEDIDO_APROBACION_RESPONSABLE)
                    {
                        this.btnEnviarAprobar.Visible = false;
                    }

                }

            }
        }

        protected void btnEnviarAprobar_Click(object sender, EventArgs e)
        {
            PedidoDTO obj = new PedidoDTO();
            List<PedidoDetalleDTO> ListaPedidoDet = null;
            
            string LoginUsuario = this.txtIdUsuario.Text = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

            if (ListaPedidoDet.Count > 0)
            {
                obj = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
                obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA;
                obj.IdUsuarioModificacion = objUsuario.IdUsuario;
                obj.FechaModificacion = DateTime.Now;
                objPedidoDAO.Actualizar(obj);

                Response.Redirect("frmPedidoAprobacionResponsable.aspx");

            }
        }

        protected void btnListaPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPedidoAprobacionResponsable.aspx");
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {

            PedidoDTO obj = new PedidoDTO();
            List<PedidoDetalleDTO> ListaPedidoDet = null;

            string LoginUsuario = this.txtIdUsuario.Text = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

            if (ListaPedidoDet.Count > 0)
            {
                obj = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
                obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_RECHAZADO;

                obj.IdUsuarioModificacion = objUsuario.IdUsuario;
                obj.FechaModificacion = DateTime.Now;

                objPedidoDAO.Actualizar(obj);

                Response.Redirect("frmPedidoAprobacionResponsable.aspx");

            }

        }


    }
}