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

using AppWeb.Reporte;


namespace AppWeb
{
    public partial class frmDespachoPedidoInterno : System.Web.UI.Page
    {

        PedidoDetalleDAO objPedidoDetDAO = new PedidoDetalleDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        TablaDAO objTablaDAO = new TablaDAO();
        SedeDAO objSedeDAO = new SedeDAO();

        DespachoDAO objDespachoDAO = new DespachoDAO();
        DespachoLineaDAO objDespachoLineaDAO = new DespachoLineaDAO();
        GuiaRemisionDAO objGuiaRemisionDAO = new GuiaRemisionDAO();
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        ParametroDAO objParametroDAO = new ParametroDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            //this.btnDespachar.Attributes.Add("onclick", "return js_validar();");

        }

        protected void InicializaPagina()
        {

            string LoginUsuario = this.txtIdUsuario.Text = HttpContext.Current.User.Identity.Name;

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            PedidoDTO obj = null;
            int IdPedido;

            if (Session["ID_PEDIDO_INTERNO"] == null)
            {
                IdPedido = 0;
            }
            else
            {
                IdPedido = Convert.ToInt32(Session["ID_PEDIDO_INTERNO"]);
                this.txtIdPedido.Text = IdPedido.ToString();
            }

            this.txtIdPedido.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            if (IdPedido > 0)
            {
                obj = objPedidoDAO.ListarPorClave(IdPedido);
                if (obj != null)
                {
                    this.txtIdPedido.Text = obj.IdPedido.ToString();
                    //this.lblIdPedido.Text = obj.IdPedido.ToString();
                    this.lblFechaPedido.Text = obj.FechaPedido.ToString("dd/MM/yyyy");
                    this.lblDescripcionPedido.Text = obj.Descripcion;
                    this.lblProyecto.Text = obj.NombreProyecto;
                    this.lblSede.Text = obj.NombreSede;
                    this.lblNombreSolicitante.Text = obj.NombreSolicitante;
                    //this.lblCodigoPresupuesto.Text = obj.CodigoPresupuesto;
                    this.lblEstado.Text = obj.NombreEstado;
                    this.lblTipoPedido.Text = obj.NombreTipoPedido;

                    //listar lineas
                    List<PedidoDetalleDTO> objPedidoDetalleLista = objPedidoDetDAO.ListarPorPedido(IdPedido);
                    this.gvPedidoLinea.DataSource = objPedidoDetalleLista;
                    this.gvPedidoLinea.DataBind();

                    this.panPedidoDetalleLineas.Visible = true;

                }

            }

   
           
        }

        protected void btnListaPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPedidoAprobacionResponsable.aspx");
        }

        protected void gvPedidoLinea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDespachar_Click(object sender, EventArgs e)
        {
/*
            GuiaRemisionDTO objGuiaRemisionDTO = new GuiaRemisionDTO();
            DespachoDTO objDespachoDTO = new DespachoDTO();
            
            Boolean hayDepacho = false;

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);
            
            foreach (GridViewRow row in this.gvPedidoLinea.Rows)
            {
                DataKey dKey = gvPedidoLinea.DataKeys[row.RowIndex];
                CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");

                if (chkSeleccion.Checked)
                {
                    TextBox txtCantidadDespacho = (TextBox)row.Cells[0].FindControl("txtCantidadDespacho");
                    if (txtCantidadDespacho.Text != "")
                    {
                        decimal cantidad = Convert.ToDecimal(txtCantidadDespacho.Text);
                        //Verifica STOCK
                     
                        //objPedidoDetDAO.ListarPorClave(
                        //objArticuloDAO.Stock(
                        hayDepacho = true;
                        

                    }
                }
            }

            if (hayDepacho)
            {

                foreach (GridViewRow row in this.gvPedidoLinea.Rows)
                {
                    DataKey dKey = gvPedidoLinea.DataKeys[row.RowIndex];
                    CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");

                    if (chkSeleccion.Checked)
                    {
                        hayDepacho = true;
                        TextBox txtCantidadDespacho = (TextBox)row.Cells[0].FindControl("txtCantidadDespacho");

                        if (txtCantidadDespacho.Text != "")
                        {
                            decimal cantidad = Convert.ToDecimal(txtCantidadDespacho.Text);
                            PedidoDetalleDTO objPedidoDetalleDTO = objPedidoDetDAO.ListarPorClave( Convert.ToInt32( dKey[0]));
                            objPedidoDetalleDTO.CantidadDespacho = Convert.ToDecimal(txtCantidadDespacho.Text);
                            objPedidoDetDAO.Actualizar(objPedidoDetalleDTO);
                        }
                    }
                }


                if (this.lblIdGuiaRemision.Text == "")
                {
                    //---------------------------------------------
                    objGuiaRemisionDTO.IdPuntoPartida = Convert.ToInt32(this.ddlPuntoPartida.SelectedValue);
                    objGuiaRemisionDTO.IdPuntoLlegada = Convert.ToInt32(this.ddlPuntoLlegada.SelectedValue);
                    objGuiaRemisionDTO.FechaEmision = AppUtilidad.stringToDateTime(this.txtFechaEmision.Text, "DD/MM/YYYY");
                    objGuiaRemisionDTO.FechaInicioTraslado = AppUtilidad.stringToDateTime(this.txtFechaTraslado.Text, "DD/MM/YYYY");
                    objGuiaRemisionDTO.RazonSocialDestinatario = this.txtDestinatario.Text;
                    objGuiaRemisionDTO.RucDestinatario = this.txtRucDestinatario.Text;
                    objGuiaRemisionDTO.RazonSocialTransportista = this.txtTransportista.Text;
                    objGuiaRemisionDTO.RucTransportista = this.txtRucTransportista.Text;
                    objGuiaRemisionDTO.Marca = this.txtMarca.Text;
                    objGuiaRemisionDTO.Placa = this.txtPlaca.Text;
                    objGuiaRemisionDTO.Certificado = this.txtCetificado.Text;
                    objGuiaRemisionDTO.Licencia = this.txtLicencia.Text;
                    objGuiaRemisionDTO.NumeroComprobantePago = this.txtComprobante.Text;

                    objGuiaRemisionDTO.Serie = this.txtSerie.Text.PadRight(3, '0');
                    objGuiaRemisionDTO.Numero = this.txtNumero.Text.PadLeft(6, '0');

                    objGuiaRemisionDTO.IdUsuarioCreacion = objUsuario.IdUsuario;
                    objGuiaRemisionDTO.FechaCreacion = DateTime.Now;

                    int IdGuiaRemision = objGuiaRemisionDAO.Agregar(objGuiaRemisionDTO);
                    this.lblIdGuiaRemision.Text = IdGuiaRemision.ToString();

                    //---------------------------------------------
                    objDespachoDTO.TipoOrigen = "PED";
                    objDespachoDTO.IdOrigen = Convert.ToInt32(this.txtIdPedido.Text);
                    objDespachoDTO.FechaDespacho = DateTime.Now;
                    objDespachoDTO.Estado = "1";
                    objDespachoDTO.IdGuiaRemision = IdGuiaRemision;
                    objDespachoDTO.IdUsuarioCreacion = objUsuario.IdUsuario;
                    objDespachoDTO.FechaCreacion = DateTime.Now;

                    int IdDespacho = objDespachoDAO.Agregar(objDespachoDTO);
                    this.lblIdDespacho.Text = IdDespacho.ToString();

                    //---------------------------------------------
                     objGuiaRemisionDTO = objGuiaRemisionDAO.ListarPorClave(IdGuiaRemision);
                    SedeDTO objSedeDTO1 = objSedeDAO.ListarPorClave(objGuiaRemisionDTO.IdPuntoPartida);
                    SedeDTO objSedeDTO2 = objSedeDAO.ListarPorClave(objGuiaRemisionDTO.IdPuntoLlegada);

                    dsReportes dsReporte = new dsReportes();

                    dsReportes.GuiaRemisionRow drFilaGuiaRemision = dsReporte.GuiaRemision.NewGuiaRemisionRow();

                    drFilaGuiaRemision.id_guia_remision = IdGuiaRemision;
                    drFilaGuiaRemision.punto_partida = objSedeDTO1.Direccion;
                    drFilaGuiaRemision.punto_llegada = objSedeDTO2.Direccion;
                    drFilaGuiaRemision.fecha_emision = objGuiaRemisionDTO.FechaEmision.ToString("dd/MM/yyyy");
                    drFilaGuiaRemision.fecha_inicio_traslado = objGuiaRemisionDTO.FechaInicioTraslado.ToString("dd/MM/yyyy");

                    drFilaGuiaRemision.destinatario = objGuiaRemisionDTO.RazonSocialDestinatario;
                    drFilaGuiaRemision.ruc_destinatario = objGuiaRemisionDTO.RucDestinatario;
                    drFilaGuiaRemision.transportista = objGuiaRemisionDTO.RazonSocialTransportista;
                    drFilaGuiaRemision.ruc_transportista = objGuiaRemisionDTO.RazonSocialTransportista;
                    drFilaGuiaRemision.marca = objGuiaRemisionDTO.Marca;
                    drFilaGuiaRemision.placa = objGuiaRemisionDTO.Placa;
                    drFilaGuiaRemision.certificado = objGuiaRemisionDTO.Certificado;
                    drFilaGuiaRemision.licencia = objGuiaRemisionDTO.Licencia;
                    drFilaGuiaRemision.comprobante = objGuiaRemisionDTO.NumeroComprobantePago;
                    drFilaGuiaRemision.numero = objGuiaRemisionDTO.Serie + "-" + objGuiaRemisionDTO.Numero;

                    dsReporte.GuiaRemision.AddGuiaRemisionRow(drFilaGuiaRemision);

                    List<DespachoLineaDTO> ListaDespachoLinea = objDespachoLineaDAO.ListarPorDespacho(IdDespacho);

                    foreach (DespachoLineaDTO item in ListaDespachoLinea)
                    {
                        ArticuloDTO objArticuloDTO = objArticuloDAO.ListarPorClave(item.IdArticulo);
                        dsReportes.GuiaRemisionDetalleRow drFilaGuiaRemisionDetalle = dsReporte.GuiaRemisionDetalle.NewGuiaRemisionDetalleRow();

                        drFilaGuiaRemisionDetalle.id_guia_remision = IdGuiaRemision;
                        drFilaGuiaRemisionDetalle.item = item.NumeroLinea;
                        drFilaGuiaRemisionDetalle.cantidad = item.CantidadDespacho; // Convert.ToDecimal("12.33");
                        drFilaGuiaRemisionDetalle.codigo = objArticuloDTO.CodigoArticulo;
                        drFilaGuiaRemisionDetalle.descripcion = objArticuloDTO.Descripcion;
                        drFilaGuiaRemisionDetalle.precio = item.PrecioUnitario; // Convert.ToDecimal("2004.23000");

                        dsReporte.GuiaRemisionDetalle.AddGuiaRemisionDetalleRow(drFilaGuiaRemisionDetalle);

                    }
                    //---------------------------------------------
                    CrystalDecisions.CrystalReports.Engine.ReportDocument myReportDocument;
                    myReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    string strRuta = Server.MapPath("rptGuiaRemision.rpt");
                    myReportDocument.Load(strRuta);
                    myReportDocument.SetDataSource(dsReporte);
                    Session.Add("ReporteCrystal", myReportDocument);
                    Session.Add("FormatoReporte", "PDF");

                    string strRutaWeb = Request.ApplicationPath;

                    Response.Write("<script language='javascript'>window.open('frmVisorReporte.aspx" + "','ventana','scrollbars=1,resizable=1,width=800,height=600,left=20,top=0');</script>");

                    this.btnDespachar.Enabled = false;

                }

           
            }

            */
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDespachoPedidoInternoLista.aspx");
        }

        protected void btnDespacho_Click(object sender, EventArgs e)
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
           
            Boolean hayDepacho = false;

            ParametroDTO objParametroDTO = objParametroDAO.ListarPorClave(AppConstantes.ID_PARAMETRO);
            
            foreach (GridViewRow row in this.gvPedidoLinea.Rows)
            {
                DataKey dKey = gvPedidoLinea.DataKeys[row.RowIndex];
                CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");

                if (chkSeleccion.Checked)
                {
                    TextBox txtCantidadDespacho = (TextBox)row.Cells[0].FindControl("txtCantidadDespacho");
                    if (txtCantidadDespacho.Text != "")
                    {
                        decimal cantidad = Convert.ToDecimal(txtCantidadDespacho.Text);
                        //Verifica STOCK

                        PedidoDetalleDTO objPedidoDetalleDTO = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(dKey[0]));
                        PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objPedidoDetalleDTO.IdPedido);
                        //objArticuloDAO.Stock(

                        Decimal stock = objArticuloDAO.Stock(objPedidoDetalleDTO.IdArticuloInventario, objPedidoDTO.IdProyecto);
                        hayDepacho = true;

                        if (cantidad > stock)
                            hayDepacho = false;


                    }
                }
            }

            //---------------------------------------
            // Despacho
            //  Despacho Linea
            //  Inv Transaccion

            if (hayDepacho)
            {
                foreach (GridViewRow row in this.gvPedidoLinea.Rows)
                {
                    DataKey dKey = gvPedidoLinea.DataKeys[row.RowIndex];
                    CheckBox chkSeleccion = (CheckBox)row.Cells[0].FindControl("chkSeleccion");

                    if (chkSeleccion.Checked)
                    {
                        TextBox txtCantidadDespacho = (TextBox)row.Cells[0].FindControl("txtCantidadDespacho");
                        if (txtCantidadDespacho.Text != "")
                        {
                            decimal cantidad = Convert.ToDecimal(txtCantidadDespacho.Text);
                            //Verifica STOCK

                            PedidoDetalleDTO objPedidoDetalleDTO = objPedidoDetDAO.ListarPorClave(Convert.ToInt32(dKey[0]));
                            PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(objPedidoDetalleDTO.IdPedido);
                            //objArticuloDAO.Stock(

                            Decimal stock = objArticuloDAO.Stock(objPedidoDetalleDTO.IdArticuloInventario, objPedidoDTO.IdProyecto);
                            hayDepacho = true;

                            if (cantidad <= stock)
                            {
                                objPedidoDetalleDTO.CantidadDespacho = cantidad;
                                objPedidoDetalleDTO.FechaModificacion = DateTime.Now;
                                objPedidoDetalleDTO.IdUsuarioModificacion = objUsuarioDTO.IdUsuario;
                                objPedidoDetDAO.Actualizar(objPedidoDetalleDTO);
                            }

                        }
                    }
                } //foreach (GridViewRow row in this.gvPedidoLinea.Rows)

                //------------------------------------------------------------------------------------------------
                DespachoDTO objDespachoDTO = new DespachoDTO();

                objDespachoDTO.TipoOrigen = "PED";
                objDespachoDTO.FechaDespacho = DateTime.Now;
                objDespachoDTO.Estado = "1";
                objDespachoDTO.IdUsuarioCreacion = objUsuarioDTO.IdUsuario;
                objDespachoDTO.FechaCreacion = DateTime.Now;
                objDespachoDTO.IdOrigen = Convert.ToInt32(this.txtIdPedido.Text);
                int IdDespacho = objDespachoDAO.Agregar(objDespachoDTO);

                this.lblmensaje.Text = "Se ha realizado el despacho correctamente. Favor de imprimir la guía";
                this.btnDespacho.Enabled = false;

            } //if (hayDepacho)
            
            //---------------------------------------


        }
           
    
    }
}