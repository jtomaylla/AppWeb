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
    public partial class frmDespachoRecepcion : System.Web.UI.Page
    {

        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        RecepcionRemisionDAO objRecepcionRemisionDAO = new RecepcionRemisionDAO();

        DespachoDAO objDespachoDAO = new DespachoDAO();
        DespachoLineaDAO objDespachoLineaDAO = new DespachoLineaDAO();
        GuiaRemisionDAO objGuiaRemisionDAO = new GuiaRemisionDAO();
        SedeDAO objSedeDAO = new SedeDAO();
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        RecepcionDAO objRecepcionDAO = new RecepcionDAO();
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnDepachar.Attributes.Add("onclick", "return js_validar();");


            this.lblIdDespacho.ControlStyle.ForeColor = System.Drawing.Color.White;
            this.lblIdGuiaRemision.ControlStyle.ForeColor = System.Drawing.Color.White;
        }


        protected void InicializaPagina()
        {
            string LoginUsuario =  HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            int IdRecepcion = Convert.ToInt32(Session["ID_RECEPCION"]);

            this.lblIdRecepcion.Text = IdRecepcion.ToString();
            

            this.ddlPuntoPartida.Items.Clear();
            this.ddlPuntoLlegada.Items.Clear();

            RecepcionDTO objRecepcionDTO = objRecepcionDAO.ListarPorClave(IdRecepcion);
            OrdenCompraDTO objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(objRecepcionDTO.IdOrdenCompra);

            this.lblNumOC.Text = objOrdenCompraDTO.IdOrdenCompra.ToString();

            List<SedeDTO> obj;
            SedeDAO objDAO = new SedeDAO();

            try
            {
                obj = objDAO.Listar();
                this.ddlPuntoPartida.DataSource = obj;
                this.ddlPuntoPartida.DataTextField = "NombreSede";
                this.ddlPuntoPartida.DataValueField = "IdSede";
                this.ddlPuntoPartida.DataBind();
                this.ddlPuntoPartida.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }

            foreach (ListItem li_item in this.ddlPuntoPartida.Items)
            {
                if (Convert.ToString(li_item.Value) == AppConstantes.SEDE_PUNTO_PARTIDA_DEFECTO.ToString())
                    li_item.Selected = true;
                else
                    li_item.Selected = false;
            }

            try
            {
                obj = objDAO.Listar();
                this.ddlPuntoLlegada.DataSource = obj;
                this.ddlPuntoLlegada.DataTextField = "NombreSede";
                this.ddlPuntoLlegada.DataValueField = "IdSede";
                this.ddlPuntoLlegada.DataBind();
                this.ddlPuntoLlegada.Items.Insert(0, new ListItem("- Seleccione -", "0"));
            }
            catch (Exception err)
            {
                throw (err);
            }

            foreach (ListItem li_item in this.ddlPuntoLlegada.Items)
            {
                if (Convert.ToString(li_item.Value) == objOrdenCompraDTO.IdSede.ToString())
                    li_item.Selected = true;
            }

            this.txtFechaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtFechaTraslado.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnDepachar_Click(object sender, EventArgs e)
        {

            try
            {

                GuiaRemisionDTO objGuiaRemisionDTO = new GuiaRemisionDTO();
                DespachoDTO objDespachoDTO = new DespachoDTO();

                string LoginUsuario = HttpContext.Current.User.Identity.Name;
                UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

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
                    objDespachoDTO.TipoOrigen = "REC";
                    objDespachoDTO.IdOrigen = Convert.ToInt32(this.lblIdRecepcion.Text);
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
                }
                else
                {
                    objGuiaRemisionDTO = objGuiaRemisionDAO.ListarPorClave(Convert.ToInt32(this.lblIdGuiaRemision.Text));

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

                    objGuiaRemisionDTO.IdUsuarioModificacion = objUsuario.IdUsuario;
                    objGuiaRemisionDTO.FechaModificacion = DateTime.Now;

                    objGuiaRemisionDAO.Actualizar(objGuiaRemisionDTO);


                    //--------------------------------
                    SedeDTO objSedeDTO1 = objSedeDAO.ListarPorClave(objGuiaRemisionDTO.IdPuntoPartida);
                    SedeDTO objSedeDTO2 = objSedeDAO.ListarPorClave(objGuiaRemisionDTO.IdPuntoLlegada);

                    dsReportes dsReporte = new dsReportes();

                    dsReportes.GuiaRemisionRow drFilaGuiaRemision = dsReporte.GuiaRemision.NewGuiaRemisionRow();

                    drFilaGuiaRemision.id_guia_remision = Convert.ToInt32(this.lblIdGuiaRemision.Text);
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

                    List<DespachoLineaDTO> ListaDespachoLinea = objDespachoLineaDAO.ListarPorDespacho(Convert.ToInt32(this.lblIdDespacho.Text));

                    foreach (DespachoLineaDTO item in ListaDespachoLinea)
                    {
                        ArticuloDTO objArticuloDTO = objArticuloDAO.ListarPorClave(item.IdArticulo);
                        dsReportes.GuiaRemisionDetalleRow drFilaGuiaRemisionDetalle = dsReporte.GuiaRemisionDetalle.NewGuiaRemisionDetalleRow();

                        drFilaGuiaRemisionDetalle.id_guia_remision = Convert.ToInt32(this.lblIdGuiaRemision.Text);
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

                }

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDespachoRecepcionLista.aspx");
        }

    }
}