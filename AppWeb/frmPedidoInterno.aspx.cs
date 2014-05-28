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
    public partial class frmPedidoInterno : System.Web.UI.Page
    {

        ArticuloDAO objArticuloDAO = new ArticuloDAO();
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

            this.btnGrabarPedido.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizarPedido.Attributes.Add("onclick", "return js_validar();");

            this.btnGrabarLinea.Attributes.Add("onclick", "return js_validar_linea();");
            this.btnActualizarLinea.Attributes.Add("onclick", "return js_validar_linea();");
            this.btnBuscar.Attributes.Add("onclick", "return js_validar_busqueda();");

            this.btnEliminarPedido.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");
            this.btnEliminarLinea.Attributes.Add("onclick", "return confirm('" + AppConstantes.MSG_ELIMINAR_REGISTRO + "')");

            this.btnEnviarAprobar.Attributes.Add("onclick", "return confirm('Desea Ud. Enviar a Aprobar?');");
            this.btnCodigoPresupuesto.Attributes.Add("onclick", "return js_codigo_presupuesto();");
        }

        protected void InicializaPagina()
        {

            if (Request.QueryString["accion"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            this.pnlBusqueda.Visible = false;

            this.btnGrabarPedido.Visible = false;
            this.btnActualizarPedido.Visible = false;
            this.btnEliminarPedido.Visible = false;
            this.btnAgregarLinea.Visible = false;
            this.btnLineas.Visible = false;
            this.btnEnviarAprobar.Visible = false;

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            ListarProyectos();
            ListarSedes();
            ListarTipoPedido();

            PedidoDTO obj = null;
            int IdPedido = 0;

            if (Request.QueryString["accion"].ToString() == "new")
            {
                IdPedido = 0;
            }
            else
            {
                if (Request.QueryString["accion"].ToString() == "edit")
                {
                    IdPedido = Convert.ToInt32(Session["ID_PEDIDO"]);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

            //------------------------------------
            if (IdPedido > 0)
            {
                obj = objPedidoDAO.ListarPorClave(IdPedido);
                if (obj != null)
                {
                    this.txtIdPedido.Text = obj.IdPedido.ToString();
                    this.lblFechaPedido.Text = obj.FechaPedido.ToString("dd/MM/yyyy");
                    //this.txtCodigoPresupuesto.Text = obj.CodigoPresupuesto;
                    this.txtDescripcionPedido.Text = obj.Descripcion;


                    foreach (ListItem li_item in this.ddlProyecto.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdProyecto.ToString())
                            li_item.Selected = true;
                    }

                    foreach (ListItem li_item in this.ddlSede.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdSede.ToString())
                            li_item.Selected = true;
                    }

                    this.lblNombreSolicitante.Text = obj.NombreSolicitante;

                    foreach (ListItem li_item in this.ddlTipoPedido.Items)
                    {
                        if (Convert.ToString(li_item.Value) == obj.IdTipoPedido.ToString())
                            li_item.Selected = true;
                    }

                    this.ddlTipoPedido.Enabled = false;

                    this.lblEstado.Text = obj.NombreEstado;

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                    this.panPedidoDetalle.Visible = false;
                    this.panPedidoDetalleLineas.Visible = true;
                    this.pnlBusqueda.Visible = false;

                    this.btnGrabarPedido.Visible = false;
                    this.btnActualizarPedido.Visible = true;
                    this.btnAgregarLinea.Visible = true;
                    this.btnLineas.Visible = true;
                    this.btnEnviarAprobar.Visible = true;

                    if (obj.Estado != AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                    {
                        this.btnGrabarPedido.Visible = false;
                        this.btnActualizarPedido.Visible = false;
                        this.btnEliminarPedido.Visible = false;
                        this.btnAgregarLinea.Visible = false;
                        this.btnLineas.Visible = true;
                        this.btnEnviarAprobar.Visible = false;

                    }

                }

            }
            else
            {
                this.panPedidoDetalle.Visible = false;
                this.panPedidoDetalleLineas.Visible = false;

                this.btnGrabarPedido.Visible = true;
                this.btnActualizarPedido.Visible = false;
                this.btnEliminarPedido.Visible = false;
                this.btnAgregarLinea.Visible = false;
                this.btnLineas.Visible = false;
                this.btnEnviarAprobar.Visible = false;
                this.btnCodigoPresupuesto.Enabled = false;

                this.lblNombreSolicitante.Text = objUsuario.NombreUsuario;
                this.lblEstado.Text = AppConstantes.ESTADO_PEDIDO_BORRADOR_NOMBRE;

                foreach (ListItem li_item in this.ddlTipoPedido.Items)
                {
                    if (Convert.ToString(li_item.Value) == AppConstantes.TIPO_PEDIDO_INTERNO.ToString())
                        li_item.Selected = true;
                }

                this.ddlTipoPedido.Enabled = false;

                this.lblFechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }

            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtCodArticulo.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtNumLinea.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtUnidadMedida.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

        }

        protected void ListarProyectos()
        {
            this.ddlProyecto.Items.Clear();

            List<ProyectoDTO> obj;
            ProyectoDAO objDAO = new ProyectoDAO();
            try
            {
                obj = objDAO.Listar();
                this.ddlProyecto.DataSource = obj;
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

        protected void ListarSedes()
        {
            this.ddlSede.Items.Clear();

            List<SedeDTO> obj;
            SedeDAO objDAO = new SedeDAO();

            try
            {
                obj = objDAO.Listar();
                this.ddlSede.DataSource = obj;
                this.ddlSede.DataTextField = "NombreSede";
                this.ddlSede.DataValueField = "IdSede";
                this.ddlSede.DataBind();
                this.ddlSede.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void ListarTipoPedido()
        {
            this.ddlTipoPedido.Items.Clear();

            List<ValorDTO> obj;
            TablaDAO objDAO = new TablaDAO();

            try
            {
                obj = objDAO.ListarTipoPedido();
                this.ddlTipoPedido.DataSource = obj;
                this.ddlTipoPedido.DataTextField = "Descripcion";
                this.ddlTipoPedido.DataValueField = "Valor";
                this.ddlTipoPedido.DataBind();
                this.ddlTipoPedido.Items.Insert(0, new ListItem("- Seleccione -", ""));
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected void btnGrabarPedido_Click(object sender, EventArgs e)
        {
            PedidoDTO obj = new PedidoDTO();
            obj.Descripcion = this.txtDescripcionPedido.Text;
            obj.FechaPedido = DateTime.Now;
            obj.IdProyecto = Convert.ToInt32(this.ddlProyecto.SelectedValue);
            obj.IdSede = Convert.ToInt32(this.ddlSede.SelectedValue);
            //obj.CodigoPresupuesto = this.txtCodigoPresupuesto.Text;
            obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR;
            obj.CodMoneda = "";
            obj.IdSolicitante = Convert.ToInt32(txtIdUsuario.Text); obj.IdResponsableProyecto = 0;
            obj.IdUsuarioCreacion = Convert.ToInt32(txtIdUsuario.Text);
            obj.FechaCreacion = DateTime.Now;
            obj.IdTipoPedido = Convert.ToInt32(this.ddlTipoPedido.SelectedValue);

            int id = objPedidoDAO.Agregar(obj);
            this.txtIdPedido.Text = id.ToString();

            obj = objPedidoDAO.ListarPorClave(id);
            //--
            this.txtIdPedido.Text = obj.IdPedido.ToString();
            this.txtDescripcionPedido.Text = obj.Descripcion;

            foreach (ListItem li_item in this.ddlProyecto.Items)
            {
                if (Convert.ToString(li_item.Value) == obj.IdProyecto.ToString())
                    li_item.Selected = true;
            }

            foreach (ListItem li_item in this.ddlSede.Items)
            {
                if (Convert.ToString(li_item.Value) == obj.IdSede.ToString())
                    li_item.Selected = true;
            }


            foreach (ListItem li_item in this.ddlTipoPedido.Items)
            {
                if (Convert.ToString(li_item.Value) == obj.IdTipoPedido.ToString())
                    li_item.Selected = true;
            }

            this.lblEstado.Text = obj.NombreEstado;

            //this.txtEstado.ReadOnly = true;
            //this.txtEstado.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            //--

            this.panPedidoDetalleLineas.Visible = true;

            this.btnGrabarPedido.Visible = false;
            this.btnActualizarPedido.Visible = true;
            this.btnAgregarLinea.Visible = true;
            this.btnLineas.Visible = true;
            this.btnEnviarAprobar.Visible = true;
            this.btnCodigoPresupuesto.Enabled = true;
            this.lblMensaje.Text = "<ul><li>Se registro el pedido</ul>";

            Session.Add("ID_PEDIDO", obj.IdPedido);
            Response.Redirect("frmPedidoInterno.aspx?accion=edit");

        }

        protected void btnActualizarPedido_Click(object sender, EventArgs e)
        {
            PedidoDTO obj = new PedidoDTO();

            obj = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            obj.Descripcion = this.txtDescripcionPedido.Text;
            obj.FechaPedido = DateTime.Now;
            //obj.CodigoPresupuesto = this.txtCodigoPresupuesto.Text;
            obj.IdProyecto = Convert.ToInt32(this.ddlProyecto.SelectedValue);
            obj.IdSede = Convert.ToInt32(this.ddlSede.SelectedValue);
            obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR;
            obj.CodMoneda = "";
            obj.IdSolicitante = Convert.ToInt32(txtIdUsuario.Text);
            obj.IdResponsableProyecto = 0;
            obj.IdTipoPedido = Convert.ToInt32(this.ddlTipoPedido.SelectedValue);

            obj.IdUsuarioModificacion = Convert.ToInt32(txtIdUsuario.Text);
            obj.FechaModificacion = DateTime.Now;

            objPedidoDAO.Actualizar(obj);

            this.lblMensaje.Text = "";
        }

        protected void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            objPedidoDAO.Eliminar(Convert.ToInt32(this.txtIdPedido.Text));
            Response.Redirect("frmPedidoLista.aspx");
        }

        protected void gvPedidoLinea_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdPedidoDetalle = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Select")
            {

                PedidoDetalleDTO objPedidoDet = objPedidoDetDAO.ListarPorClave(IdPedidoDetalle);
                PedidoDTO objPedido = objPedidoDAO.ListarPorClave(objPedidoDet.IdPedido);

                //Cabecera
                this.txtIdPedido.Text = objPedido.IdPedido.ToString();
                foreach (ListItem li_item in this.ddlProyecto.Items)
                    if (Convert.ToString(li_item.Value) == objPedido.IdProyecto.ToString())
                        li_item.Selected = true;

                foreach (ListItem li_item in this.ddlSede.Items)
                    if (Convert.ToString(li_item.Value) == objPedido.IdSede.ToString())
                        li_item.Selected = true;

                this.txtDescripcionPedido.Text = objPedido.Descripcion;

                foreach (ListItem li_item in this.ddlTipoPedido.Items)
                    if (Convert.ToString(li_item.Value) == objPedido.IdTipoPedido.ToString())
                        li_item.Selected = true;

                //Detalle
                this.txtIdPedidoDetalle.Text = objPedidoDet.IdPedidoDetalle.ToString();
                this.txtNumLinea.Text = objPedidoDet.NumeroLinea.ToString();
                this.txtIdArticulo.Text = objPedidoDet.IdArticuloInventario.ToString();
                this.txtCodArticulo.Text = objPedidoDet.CodigoArticulo;
                this.txtDescripcionLinea.Text = objPedidoDet.DescripcionLinea;
                this.txtCantidad.Text = objPedidoDet.Cantidad.ToString();
                this.btnActualizarLinea.Visible = true;
                this.btnGrabarLinea.Visible = false;

                this.panPedidoDetalle.Visible = true;
                this.panPedidoDetalleLineas.Visible = false;


                if (objPedido.Estado != AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                {
                    this.btnActualizarLinea.Visible = false;
                }

            }
        }

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            //Limpia campos
            this.txtNumLinea.Text = "";
            this.txtIdPedidoDetalle.Text = "";
            this.txtCodArticulo.Text = "";
            this.txtIdArticulo.Text = "";
            this.txtDescripcionLinea.Text = "";
            this.txtCantidad.Text = "";

            this.panPedidoDetalle.Visible = true;
            this.panPedidoDetalleLineas.Visible = false;
            this.btnActualizarLinea.Visible = false;
            this.btnGrabarLinea.Visible = true;
            this.btnEliminarLinea.Visible = false;

        }

        protected void btnLineas_Click(object sender, EventArgs e)
        {
            this.panPedidoDetalle.Visible = false;
            this.panPedidoDetalleLineas.Visible = true;

            //Limpia campos
            this.txtIdPedidoDetalle.Text = "";
            this.txtDescripcionLinea.Text = "";
            this.txtCantidad.Text = "";

            //Listar Lineas
            List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));
            this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
            this.gvPedidoLinea.DataBind();

        }

        protected void btnGrabarLinea_Click(object sender, EventArgs e)
        {
            PedidoDetalleDTO objDet = new PedidoDetalleDTO();
            
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            objDet.IdPedido = Convert.ToInt32(this.txtIdPedido.Text);
            //objDet.NumeroLinea = 1;
            objDet.DescripcionLinea = this.txtDescripcionLinea.Text;
            objDet.Cantidad = Convert.ToDecimal(this.txtCantidad.Text);
            objDet.IdUnidadMedida = 0;//Convert.ToInt32(this.ddlUnidadMedida.SelectedValue);

            if (this.txtIdArticulo.Text != "")
                objDet.IdArticuloInventario = Convert.ToInt32(this.txtIdArticulo.Text);

            objDet.IdUsuarioCreacion = objUsuario.IdUsuario;
            objDet.FechaCreacion = DateTime.Now;

            int id = objPedidoDetDAO.Agregar(objDet);

            objDet = objPedidoDetDAO.ListarPorClave(id);

            this.txtIdPedidoDetalle.Text = objDet.IdPedidoDetalle.ToString();
            this.txtIdArticulo.Text = objDet.IdArticuloInventario.ToString();
            this.txtCodArticulo.Text = objDet.CodigoArticulo;
            this.txtNumLinea.Text = objDet.NumeroLinea.ToString();
            this.txtCantidad.Text = objDet.Cantidad.ToString();

            this.btnGrabarLinea.Visible = false;
            this.btnActualizarLinea.Visible = true;
            this.btnEnviarAprobar.Visible = true;

        }

        protected void btnActualizarLinea_Click(object sender, EventArgs e)
        {
            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);
            
            PedidoDetalleDTO objDet = new PedidoDetalleDTO();
            objDet = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedidoDetalle.Text));
            objDet.IdArticuloInventario = Convert.ToInt32(this.txtIdArticulo.Text);
            objDet.DescripcionLinea = this.txtDescripcionLinea.Text;
            objDet.Cantidad = Convert.ToDecimal(this.txtCantidad.Text);
            objDet.IdUnidadMedida = 0;//Convert.ToInt32(this.ddlUnidadMedida.SelectedValue);
            objDet.IdUsuarioModificacion = objUsuario.IdUsuario;
            objDet.FechaModificacion = DateTime.Now;
            objPedidoDetDAO.Actualizar(objDet);

            objDet = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedidoDetalle.Text));
            this.txtIdPedidoDetalle.Text = objDet.IdPedidoDetalle.ToString();
            this.txtIdArticulo.Text = objDet.IdArticuloInventario.ToString();
            this.txtCodArticulo.Text = objDet.CodigoArticulo;
            this.txtNumLinea.Text = objDet.NumeroLinea.ToString();
            this.txtCantidad.Text = objDet.Cantidad.ToString();

            //Listar Lineas
            List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));
            this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
            this.gvPedidoLinea.DataBind();

            this.lblMensaje.Text = "";

        }

        protected void btnEliminarLinea_Click(object sender, EventArgs e)
        {
            objPedidoDetDAO.Eliminar(Convert.ToInt32(this.txtIdPedidoDetalle.Text));

            this.panPedidoDetalle.Visible = false;
            this.panPedidoDetalleLineas.Visible = true;

            //Limpia campos
            this.txtIdPedidoDetalle.Text = "";
            this.txtDescripcionLinea.Text = "";
            this.txtCantidad.Text = "";

            //Listar Lineas
            List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));
            this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
            this.gvPedidoLinea.DataBind();

        }

        protected void btnListaPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPedidoLista.aspx");
        }

        protected void btnEnviarAprobar_Click(object sender, EventArgs e)
        {
            PedidoDTO obj = new PedidoDTO();
            List<PedidoDetalleDTO> ListaPedidoDet = null;

            ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

            if (ListaPedidoDet.Count > 0)
            {
                obj = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
                obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_RESPONSABLE;

                obj.IdUsuarioModificacion = Convert.ToInt32(txtIdUsuario.Text);
                obj.FechaModificacion = DateTime.Now;

                objPedidoDAO.Actualizar(obj);

                this.btnActualizarPedido.Visible = false;
                this.btnEliminarPedido.Visible = false;
                this.btnAgregarLinea.Visible = false;
                this.btnEnviarAprobar.Visible = false;

                Response.Redirect("frmPedidoLista.aspx");

            }
            else
            {
                this.lblMensaje.Text = "<ul><li>Pedido no tiene lineas registradas</ul>";
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = true;
            panPedidoDetalle.Visible = false;
            panPedidoDetalleLineas.Visible = false;

            //Buscar Articulo
            String strBusqueda = txtDescripcionLinea.Text;
            List<ArticuloDTO> articulos = objArticuloDAO.ListarBusqueda("", strBusqueda);
            this.gvLista.DataSource = articulos;
            this.gvLista.DataBind();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = false;
            panPedidoDetalle.Visible = true;
            panPedidoDetalleLineas.Visible = false;

        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloDTO obj;

            try
            {
                int idArticulo = Convert.ToInt32(gvLista.SelectedRow.Cells[0].Text);
                obj = objArticuloDAO.ListarPorClave(idArticulo);

                this.txtDescripcionLinea.Text = obj.Descripcion;
                this.txtIdArticulo.Text = obj.IdArticulo.ToString();
                this.txtCodArticulo.Text = obj.CodigoArticulo;
                this.txtUnidadMedida.Text = obj.NombreUnidadMedida;

                pnlBusqueda.Visible = false;
                panPedidoDetalle.Visible = true;
                panPedidoDetalleLineas.Visible = false;
            }
            catch (Exception err)
            {
                // this.lblMensaje.Text = err.Message.ToString();
            }
        }

    }
}