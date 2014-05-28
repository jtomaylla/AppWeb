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
    public partial class frmPedidoLineaAprobacionLogistica : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        PedidoPresupuestoDAO objPedidoPresupuestoDAO = new PedidoPresupuestoDAO();

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

            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            this.txtIdPedido.ReadOnly = true;
            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            if (objUsuarioDTO != null)
                this.txtIdUsuario.Text = objUsuarioDTO.IdUsuario.ToString();

            PedidoDTO objPedidoDTO = null;
            int IdPedido;

            if (Session["ID_PEDIDO_APROBACION_LOGISTICA"] == null)
            {
                IdPedido = 0;
            }
            else
            {
                IdPedido = Convert.ToInt32(Session["ID_PEDIDO_APROBACION_LOGISTICA"]);
                this.txtIdPedido.Text = IdPedido.ToString();
            }
                       

            if (IdPedido > 0)
            {
                objPedidoDTO = objPedidoDAO.ListarPorClave(IdPedido);
                if (objPedidoDTO != null)
                {
                    this.txtIdPedido.Text = objPedidoDTO.IdPedido.ToString();
                    this.lblFechaPedido.Text = objPedidoDTO.FechaPedido.ToString("dd/MM/yyyy");

                    List<PedidoPresupuestoDTO> ListaPedidoPresupuestoDTO = objPedidoPresupuestoDAO.Listar(objPedidoDTO.IdPedido);
                    string codigosPresupuesto = "";
                    if (ListaPedidoPresupuestoDTO.Count > 0)
                    {
                        foreach (PedidoPresupuestoDTO item in ListaPedidoPresupuestoDTO)
                        {
                            codigosPresupuesto = codigosPresupuesto + " " + item.CodigoPresupuesto;
                        }
                    }

                    this.lblCodigoPresupuesto.Text = codigosPresupuesto;

                    this.lblDescripcionPedido.Text = objPedidoDTO.Descripcion;
                    this.lblProyecto.Text = objPedidoDTO.NombreProyecto;
                    this.lblSede.Text = objPedidoDTO.NombreSede;
                    this.lblNombreSolicitante.Text = objPedidoDTO.NombreSolicitante;
                    this.lblMoneda.Text = objPedidoDTO.NombreMoneda;
                    this.lblEstado.Text = objPedidoDTO.NombreEstado;
                    this.lblTipoPedido.Text = objPedidoDTO.NombreTipoPedido;

                    if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                    {
                        this.btnCodigoPresupuesto.Visible = false;
                        this.lblCodigoPresupuesto.Visible = false;
                    }

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                    this.panPedidoDetalleLineas.Visible = true;
                    this.btnEnviarAprobar.Visible = false;

                    if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA)
                    {
                        this.btnEnviarAprobar.Visible = true;
                    }
                }

            }
        }

        protected void btnEnviarAprobar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";

            try
            {
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                PedidoDTO objPedidoDTO = null;
                List<PedidoDetalleDTO> ListaPedidoDet = null;

                ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

                if (ListaPedidoDet.Count > 0)
                {
                    objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
                    List<PedidoPresupuestoDTO> ListaPedidoPresupuestoDTO = objPedidoPresupuestoDAO.Listar(objPedidoDTO.IdPedido);

                    if (ListaPedidoPresupuestoDTO.Count > 0)
                    {
                        objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_APROBADO;

                        if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_COMPRA ||
                            objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_SERVICIO)
                            objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_COTIZACION_PENDIENTE;
                        else
                            objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_EN_DESPACHO;

                        objPedidoDTO.FechaAprobacion = DateTime.Now;
                        objPedidoDTO.IdUsuarioModificacion = objUsuario.IdUsuario;
                        objPedidoDTO.FechaModificacion = DateTime.Now;
                        objPedidoDAO.Actualizar(objPedidoDTO);

                        Response.Redirect("frmPedidoAprobacionLogistica.aspx");
                    }
                    else
                    {
                        this.lblMensaje.Text = "Pedido no tiene códigos de presupuesto asignado";
                    }
                    

                }
                        
            }
            catch(Exception ex) 
            {
                this.lblMensaje.Text = ex.ToString();            
            }

        }

        protected void btnListaPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPedidoAprobacionLogistica.aspx");
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {

            this.lblMensaje.Text = "";

            try
            {

                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                PedidoDTO objPedidoDTO = null;
                List<PedidoDetalleDTO> ListaPedidoDet = null;
            
                ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

                if (ListaPedidoDet.Count > 0)
                {
                    objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
                    objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_RECHAZADO;
                    objPedidoDTO.IdUsuarioModificacion = objUsuario.IdUsuario;
                    objPedidoDTO.FechaModificacion = DateTime.Now;
                    objPedidoDAO.Actualizar(objPedidoDTO);

                    Response.Redirect("frmPedidoAprobacionLogistica.aspx");

                }

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }

    
    }
}