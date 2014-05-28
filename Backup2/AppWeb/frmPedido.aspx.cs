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
    public partial class frmPedido : System.Web.UI.Page
    {
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();
        PedidoPresupuestoDAO objPedidoPresupuestoDAO = new PedidoPresupuestoDAO();

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
            this.btnRechazar.Attributes.Add("onclick", "return confirm('Desea Ud. Rechazar el Pedido?');");
        }

        protected void InicializaPagina()
        {

            if (Request.QueryString["accion"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            this.pnlBusqueda.Visible = false;

            this.btnGrabarPedido.Visible = false;
            this.btnActualizarPedido.Visible = false;
            this.btnEliminarPedido.Visible = false;
            this.btnAgregarLinea.Visible = false;
            this.btnLineas.Visible = false;
            this.btnEnviarAprobar.Visible = false;
            this.btnRechazar.Visible = false;

            ListarProyectos();
            ListarSedes();
            ListarMoneda();
            ListarTipoPedido();

            PedidoDTO objPedidoDTO = null;
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
                else {
                    Response.Redirect("Default.aspx");
                }
            }

            //------------------------------------
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

                    this.txtDescripcionPedido.Text = objPedidoDTO.Descripcion;
                    
                    foreach (ListItem li_item in this.ddlProyecto.Items)
                    {
                        if (Convert.ToString(li_item.Value) == objPedidoDTO.IdProyecto.ToString())
                            li_item.Selected = true;
                    }

                    foreach (ListItem li_item in this.ddlSede.Items)
                    {
                        if (Convert.ToString(li_item.Value) == objPedidoDTO.IdSede.ToString())
                            li_item.Selected = true;
                    }

                    this.lblNombreSolicitante.Text = objPedidoDTO.NombreSolicitante;

                    if (objPedidoDTO.CodMoneda != null)
                    {
                        foreach (ListItem li_item in this.ddlMoneda.Items)
                        {
                            if (Convert.ToString(li_item.Value) == objPedidoDTO.CodMoneda.ToString())
                                li_item.Selected = true;
                            else
                                li_item.Selected = false;
                        }
                    }
                    foreach (ListItem li_item in this.ddlTipoPedido.Items)
                    {
                        if (Convert.ToString(li_item.Value) == objPedidoDTO.IdTipoPedido.ToString())
                            li_item.Selected = true;
                    }

                    this.ddlTipoPedido.Enabled = false;


                    this.lblEstado.Text = objPedidoDTO.NombreEstado;

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
/*
                    if (obj.Estado != AppConstantes.ESTADO_PEDIDO_BORRADOR) 
                    {
                        this.btnGrabarPedido.Visible = false;
                        this.btnActualizarPedido.Visible = false;
                        this.btnEliminarPedido.Visible = false;
                        this.btnAgregarLinea.Visible = false;
                        this.btnLineas.Visible = true;
                        this.btnEnviarAprobar.Visible = false;
                        this.btnLineas.Visible = false;

                    }
*/
                    if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                    {
                        this.txtPrecioReferencial.Visible = false;
                        this.lblPrecioReferencial1.Visible = false;
                        this.lblPrecioReferencial2.Visible = false;

                        this.txtImporte.Visible = false;
                        this.lblImporte1.Visible = false;
                        this.lblImporte2.Visible = false;

                        this.ddlMoneda.Enabled = false;
                        this.btnCodigoPresupuesto.Enabled = false;
                    }

                    if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_RESPONSABLE || objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA)
                    {
                        this.btnRechazar.Visible = true;
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
                this.btnRechazar.Visible = false;

                this.lblNombreSolicitante.Text = objUsuario.NombreUsuario;
                this.lblEstado.Text = AppConstantes.ESTADO_PEDIDO_BORRADOR_NOMBRE;

                foreach (ListItem li_item in this.ddlTipoPedido.Items)
                {
                    if (Convert.ToString(li_item.Value) == AppConstantes.TIPO_PEDIDO_COMPRA.ToString())
                        li_item.Selected = true;
                }

                //this.ddlTipoPedido.Enabled = false;

                this.lblFechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }

            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtCodArticulo.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtNumLinea.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtImporte.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
            this.txtUnidadMedida.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);
        }

        protected void ListarProyectos()
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            this.ddlProyecto.Items.Clear();

            List<ProyectoDTO> ListaProyectoDTO;

            try
            {
                ListaProyectoDTO = objProyectoDAO.Listar(objUsuarioDTO.IdUsuario);
                this.ddlProyecto.DataSource = ListaProyectoDTO;
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

        protected void ListarMoneda()
        {
            this.ddlMoneda.Items.Clear();

            List<ValorDTO> obj;
            TablaDAO objDAO = new TablaDAO();

            try
            {
                obj = objDAO.ListarMoneda();
                this.ddlMoneda.DataSource = obj;
                this.ddlMoneda.DataTextField = "Descripcion";
                this.ddlMoneda.DataValueField = "Valor";
                this.ddlMoneda.DataBind();
                this.ddlMoneda.Items.Insert(0, new ListItem("- Seleccione -", ""));
            }
            catch (Exception err)
            {
                throw (err);
            }

            foreach (ListItem li_item in this.ddlMoneda.Items)
            {
                if (Convert.ToString(li_item.Value) == AppConstantes.MONEDA_DEFECTO)
                    li_item.Selected = true;
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

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            lblMensaje.Text = "";
            try
            { 
                    PedidoDTO obj = new PedidoDTO();
                    obj.Descripcion = this.txtDescripcionPedido.Text;
                    obj.FechaPedido = DateTime.Now;
                    obj.IdProyecto = Convert.ToInt32(this.ddlProyecto.SelectedValue);
                    obj.IdSede = Convert.ToInt32(this.ddlSede.SelectedValue);
                    obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR;
                    obj.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_BORRADOR;

                    if (obj.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                        obj.CodMoneda = "";
                    else
                        obj.CodMoneda = this.ddlMoneda.SelectedValue;

                    obj.IdSolicitante = objUsuario.IdUsuario;
                    obj.IdResponsableProyecto = 0;
                    obj.IdUsuarioCreacion = objUsuario.IdUsuario;
                    obj.FechaCreacion = DateTime.Now;
                    obj.IdTipoPedido = Convert.ToInt32(this.ddlTipoPedido.SelectedValue);

                    int id = objPedidoDAO.Agregar(obj);
                    this.txtIdPedido.Text = id.ToString();


                    obj = objPedidoDAO.ListarPorClave(id);

                    this.ddlTipoPedido.Enabled = false;

                    if (obj.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO )
                    {
                        this.txtPrecioReferencial.Visible = false;
                        this.lblPrecioReferencial1.Visible = false;
                        this.lblPrecioReferencial2.Visible = false;

                        this.txtImporte.Visible = false;
                        this.lblImporte1.Visible = false;
                        this.lblImporte2.Visible = false;
                    }

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

                    if (obj.CodMoneda != null)
                        foreach (ListItem li_item in this.ddlMoneda.Items)
                        {
                            if (Convert.ToString(li_item.Value) == obj.CodMoneda.ToString())
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
                    Response.Redirect("frmPedido.aspx?accion=edit");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.ToString();
            }

        }

        protected void btnActualizarPedido_Click(object sender, EventArgs e)
        {
            
            PedidoDTO obj = new PedidoDTO();
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            
            obj = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            obj.Descripcion = this.txtDescripcionPedido.Text;
            obj.FechaPedido = DateTime.Now;
            obj.IdProyecto = Convert.ToInt32(this.ddlProyecto.SelectedValue);
            obj.IdSede = Convert.ToInt32(this.ddlSede.SelectedValue);
            //obj.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR;
            //obj.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_BORRADOR;

            if (obj.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                obj.CodMoneda = "";
            else
                obj.CodMoneda = this.ddlMoneda.SelectedValue;

            obj.IdSolicitante = objUsuario.IdUsuario;
            obj.IdResponsableProyecto = 0;
            obj.IdTipoPedido = Convert.ToInt32(this.ddlTipoPedido.SelectedValue);

            obj.IdUsuarioModificacion = objUsuario.IdUsuario;
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
                        
            if (e.CommandName == "Eliminar")
            {
                objPedidoDetDAO.Eliminar(IdPedidoDetalle);
            }

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

                if (objPedido.CodMoneda != null)
                    foreach (ListItem li_item in this.ddlMoneda.Items)
                        if (Convert.ToString(li_item.Value) == objPedido.CodMoneda.ToString())
                            li_item.Selected = true;

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
                this.txtPrecioReferencial.Text = objPedidoDet.PrecioReferencial.ToString();
                this.txtImporte.Text = objPedidoDet.Importe.ToString();
                this.btnActualizarLinea.Visible = true;
                this.btnGrabarLinea.Visible = false;

                this.panPedidoDetalle.Visible = true;
                this.panPedidoDetalleLineas.Visible = false;


                //if (objPedido.Estado != AppConstantes.ESTADO_PEDIDO_BORRADOR)
                //{
                //    this.btnActualizarLinea.Visible = false;
                //}

            }
        }
        
        protected void gvPedidoLinea_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PedidoDetalleDTO fila = (PedidoDetalleDTO)e.Row.DataItem;
                Button btnEditar = (Button)e.Row.FindControl("btnEditar");
/*
                if (fila.EstadoPedido == AppConstantes.ESTADO_PEDIDO_APROBADO)
                    btnEditar.Enabled = false;
                */

            }
        }

        protected void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            //Limpia campos
            this.lblMensaje.Text = "";
            this.txtNumLinea.Text = "";
            this.txtIdPedidoDetalle.Text = "";
            this.txtCodArticulo.Text = "";
            this.txtIdArticulo.Text = "";
            this.txtDescripcionLinea.Text = "";
            this.txtCantidad.Text = "";
            this.txtPrecioReferencial.Text = "";
            this.txtImporte.Text = "";
            this.txtUnidadMedida.Text = "";

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
            this.txtPrecioReferencial.Text = "";

            //Listar Lineas
            List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));
            this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
            this.gvPedidoLinea.DataBind();

        }

        protected void btnGrabarLinea_Click(object sender, EventArgs e)
        {
            PedidoDetalleDTO objDet = new PedidoDetalleDTO();
            PedidoDTO objPedidoDTO = new PedidoDTO();
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            objDet.IdPedido = Convert.ToInt32(this.txtIdPedido.Text);
            //objDet.NumeroLinea = 1;
            objDet.DescripcionLinea = this.txtDescripcionLinea.Text;
            objDet.Cantidad = Convert.ToDecimal(this.txtCantidad.Text);


            if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                objDet.PrecioReferencial = 0;
            else
                objDet.PrecioReferencial = Convert.ToDecimal(this.txtPrecioReferencial.Text);

            if (this.txtIdArticulo.Text!="")
                objDet.IdArticuloInventario = Convert.ToInt32(this.txtIdArticulo.Text);

            ArticuloDTO objArticuloDTO = objArticuloDAO.ListarPorClave(objDet.IdArticuloInventario);

            objDet.IdUnidadMedida = objArticuloDTO.IdUnidadMedida;
            objDet.IdUsuarioCreacion = objUsuario.IdUsuario;
            objDet.FechaCreacion = DateTime.Now;

            int id = objPedidoDetDAO.Agregar(objDet);
            
            objDet = objPedidoDetDAO.ListarPorClave(id);
            
            this.txtIdPedidoDetalle.Text = objDet.IdPedidoDetalle.ToString();
            this.txtIdArticulo.Text = objDet.IdArticuloInventario.ToString();
            this.txtCodArticulo.Text = objDet.CodigoArticulo;
            this.txtNumLinea.Text = objDet.NumeroLinea.ToString();
            this.txtCantidad.Text = objDet.Cantidad.ToString();
            this.txtPrecioReferencial.Text = objDet.PrecioReferencial.ToString();
            this.txtImporte.Text = objDet.Importe.ToString();

            this.btnGrabarLinea.Visible = false;
            this.btnActualizarLinea.Visible = true;
            this.btnEliminarLinea.Visible = true;
            this.btnEnviarAprobar.Visible = true;

        }

        protected void btnActualizarLinea_Click(object sender, EventArgs e)
        {
            PedidoDTO objPedidoDTO = new PedidoDTO();
            PedidoDetalleDTO objDet = new PedidoDetalleDTO();
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            objDet = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedidoDetalle.Text));
            objDet.IdArticuloInventario = Convert.ToInt32(this.txtIdArticulo.Text);
            objDet.DescripcionLinea = this.txtDescripcionLinea.Text;
            objDet.Cantidad = Convert.ToDecimal(this.txtCantidad.Text);


            if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_INTERNO)
                objDet.PrecioReferencial = 0;
            else
                objDet.PrecioReferencial = Convert.ToDecimal(this.txtPrecioReferencial.Text);

            ArticuloDTO objArticuloDTO = objArticuloDAO.ListarPorClave(objDet.IdArticuloInventario);
            objDet.IdUnidadMedida = objArticuloDTO.IdUnidadMedida;

            objDet.IdUsuarioModificacion = objUsuario.IdUsuario;
            objDet.FechaModificacion = DateTime.Now;
            objPedidoDetDAO.Actualizar(objDet);

            objDet = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedidoDetalle.Text));
            this.txtIdPedidoDetalle.Text = objDet.IdPedidoDetalle.ToString();
            this.txtIdArticulo.Text = objDet.IdArticuloInventario.ToString();
            this.txtCodArticulo.Text = objDet.CodigoArticulo;
            this.txtNumLinea.Text = objDet.NumeroLinea.ToString();
            this.txtCantidad.Text = objDet.Cantidad.ToString();
            this.txtPrecioReferencial.Text = objDet.PrecioReferencial.ToString();
            this.txtImporte.Text = objDet.Importe.ToString();

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
            this.txtPrecioReferencial.Text = "";
            this.txtImporte.Text = "";

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
            this.lblMensaje.Text = "";

            PedidoDTO objPedidoDTO = null;
            List<PedidoDetalleDTO> ListaPedidoDet = null;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            ListaPedidoDet = objPedidoDetDAO.ListarPorPedido(Convert.ToInt32(this.txtIdPedido.Text));

            if (ListaPedidoDet.Count > 0)
            {

                objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));

                int flag = 0;
                if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                {
                    flag = 1;
                }
                else
                {
                    List<PedidoPresupuestoDTO> ListaPedidoPresupuestoDTO = objPedidoPresupuestoDAO.Listar(objPedidoDTO.IdPedido);
                    if (ListaPedidoPresupuestoDTO.Count > 0)
                        flag = 1;
                    else
                        flag = 0;
                }


                if (flag == 1)
                {

                    if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                    {
                        objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_RESPONSABLE;
                    }
                    else
                    {
                        if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_RESPONSABLE)
                        {
                            objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA;
                        }
                        else
                        {
                            if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_EN_APROBACION_LOGISTICA)
                            {
                                objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_APROBADO;
                                objPedidoDTO.FechaAprobacion = DateTime.Now;

                                if (objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_COMPRA || objPedidoDTO.IdTipoPedido == AppConstantes.TIPO_PEDIDO_SERVICIO)
                                    objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_CONTROL_COTIZACION_PENDIENTE;
                                else
                                    objPedidoDTO.EstadoControl = AppConstantes.PEDIDO_ESTADO_EN_DESPACHO;
                            }
                        }
                    }


                    objPedidoDTO.IdUsuarioModificacion = objUsuario.IdUsuario;
                    objPedidoDTO.FechaModificacion = DateTime.Now;

                    objPedidoDAO.Actualizar(objPedidoDTO);

                    this.btnActualizarPedido.Visible = false;
                    this.btnEliminarPedido.Visible = false;
                    this.btnAgregarLinea.Visible = false;
                    this.btnEnviarAprobar.Visible = false;

                    Response.Redirect("frmPedidoLista.aspx");
                }
                else
                {
                    this.lblMensaje.Text = "Pedido no tiene codigos de presupuesto asignados<br/><br/>";
                }
            }
            else 
            {
                this.lblMensaje.Text = "Pedido no tiene lineas registradas<br/><br/>";
            }
 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = true;
            panPedidoDetalle.Visible = false;
            panPedidoDetalleLineas.Visible = false;
 
            //Buscar Articulo
            String strBusqueda = txtDescripcionLinea.Text;
            List<ArticuloDTO> articulos = objArticuloDAO.ListarBusquedaPorProyecto(strBusqueda, Convert.ToInt32(this.ddlProyecto.SelectedValue));
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
                this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            PedidoDTO objPedidoDTO = new PedidoDTO();
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            objPedidoDTO = objPedidoDAO.ListarPorClave(Convert.ToInt32(this.txtIdPedido.Text));
            objPedidoDTO.Estado = AppConstantes.PEDIDO_ESTADO_APROBACION_RECHAZADO;

            objPedidoDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
            objPedidoDTO.FechaModificacion = DateTime.Now;

            objPedidoDAO.Actualizar(objPedidoDTO);

            Response.Redirect("frmPedidoLista.aspx");

            
        }
 
    }
}