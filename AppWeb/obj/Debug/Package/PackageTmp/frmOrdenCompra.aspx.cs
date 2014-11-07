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
    
namespace AppWeb
{
    public partial class frmOrdenCompra : System.Web.UI.Page
    {
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        FormaPagoDAO objFormaPagoDAO = new FormaPagoDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            if (objUsuarioDTO.AnulaDescarta != "X")//coordinador de logistica, puede anular
            {
                lnkanular.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (objUsuarioDTO.AnulaDescarta != "C")//auxiliar de logistica, puede descartar
            {
                //lnkdescartar.Style.Add(HtmlTextWriterStyle.Display, "none");
            }


            int IdOrdenCompra;

            if (Session["ID_ORDEN_COMPRA"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            IdOrdenCompra = Convert.ToInt32(Session["ID_ORDEN_COMPRA"]);

            OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

            this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
            this.lblNombreProyecto.Text = obj.NombreProyecto;
            this.lblNombreSede.Text = obj.NombreSede;
            this.lblRazonSocial.Text = obj.RazonSocial;
            this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
            this.lblNombreMoneda.Text = obj.NombreMoneda;
            //this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            this.lblEstadoAprobacion.Text = obj.NombreEstadoAprobacion;
            this.lblDescripcionOC.Text = obj.DescripcionOrdenCompra;
            decimal total = 0;
            if (obj.FlagIGV == "1")
            {
                this.lblflagigv.Text = "SI";
                total = obj.ImporteOrdenCompra * System.Convert.ToDecimal(1.18);
                this.lblImporte.Text = Math.Round(total, 2).ToString(); 
            }
            else
            {
                this.lblflagigv.Text = "NO";
                this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
            }

            if (obj.EstadoControl == "2")
            {
                lnkanular.Style.Add(HtmlTextWriterStyle.Display, "none");
                lnkdescartar.Style.Add(HtmlTextWriterStyle.Display, "none");
            }


            if (obj.FechaEntrega.Year == 1)
                this.lblFechaEntrega.Text = "";
            else
                this.lblFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");

            FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(obj.IdFormaPago);

            if (objFormaPagoDTO!=null)
                this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;

            List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(IdOrdenCompra);
            this.gvLista.DataSource = objLista;
            this.gvLista.DataBind();

            this.btnanular.Attributes.Add("onclick", "return confirm('Está seguro de anular la OC/OS Nro. " + this.lblIdOrdenCompra.Text + "?');");
            this.btndescartar.Attributes.Add("onclick", "return confirm('Está seguro de descartar la OC/OS Nro. " + this.lblIdOrdenCompra.Text + "?');");
        }

        protected void lnkanular_Click(object sender, EventArgs e)
        {
            if (pnlanular.Visible)
            {
                pnlanular.Visible = false;
            }
            else
            {
                pnlanular.Visible = true;
            }

            
        }

        protected void btnanular_Click(object sender, EventArgs e)
        {
            try {
                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                int retorno = objOrdenCompraDAO.Anular(Convert.ToInt32(lblIdOrdenCompra.Text), txtanular.Text,objUsuarioDTO.IdUsuario);
                //string script = @"<script type='text/javascript'>alert('Se ha anulado el documento');</script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                if (retorno > 0)
                {
                    Response.Redirect("frmOrdenCompraLista.aspx");
                }
                
            }
            catch (Exception ex) {
                string script = @"<script type='text/javascript'>alert('Error: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }

        }

        protected void lnkdescartar_Click(object sender, EventArgs e)
        {
            if (pan_descarte.Visible)
            {
                pan_descarte.Visible = false;
            }
            else
            {
                pan_descarte.Visible = true;
            }
        }

        protected void btndescartar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO objUsuarioDTO = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
                int retorno = objOrdenCompraDAO.Descartar(Convert.ToInt32(lblIdOrdenCompra.Text), txtdescarte.Text, objUsuarioDTO.IdUsuario);
                //string script = @"<script type='text/javascript'>alert('Se ha anulado el documento');</script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                if (retorno > 0)
                {
                    Response.Redirect("frmOrdenCompraLista.aspx");
                }

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>alert('Error: " + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int LineaOrdenCompra = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Editar")
            {
                pnleditar.Visible = true;
                this.txtIdLinOrdenCompra.Text = LineaOrdenCompra.ToString();
            }
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (pnleditar.Visible && !(string.IsNullOrEmpty(txtIdLinOrdenCompra.Text)))
            {
                OrdenCompraLineaDAO objOrdenCompraLinea = new OrdenCompraLineaDAO();
                try 
                {
                    int retorno = objOrdenCompraLinea.EditarPU(int.Parse(txtIdLinOrdenCompra.Text), decimal.Parse(txteditar.Text));
                    if (retorno > 0)
                    {
                        int IdOrdenCompra;

                        IdOrdenCompra = Convert.ToInt32(Session["ID_ORDEN_COMPRA"]);

                        OrdenCompraDTO obj = objOrdenCompraDAO.ListarPorClave(IdOrdenCompra);

                        this.txtIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
                        this.lblIdOrdenCompra.Text = obj.IdOrdenCompra.ToString();
                        this.lblNombreProyecto.Text = obj.NombreProyecto;
                        this.lblNombreSede.Text = obj.NombreSede;
                        this.lblRazonSocial.Text = obj.RazonSocial;
                        this.lblFechaOrdenCompra.Text = obj.FechaOrdenCompra.ToString("dd/MM/yyyy");
                        this.lblNombreMoneda.Text = obj.NombreMoneda;
                        //this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
                        this.lblEstadoAprobacion.Text = obj.NombreEstadoAprobacion;
                        this.lblDescripcionOC.Text = obj.DescripcionOrdenCompra;
                        decimal total = 0;
                        if (obj.FlagIGV == "1")
                        {
                            this.lblflagigv.Text = "SI";
                            total = obj.ImporteOrdenCompra * System.Convert.ToDecimal(1.18);
                            this.lblImporte.Text = Math.Round(total, 2).ToString();
                        }
                        else
                        {
                            this.lblflagigv.Text = "NO";
                            this.lblImporte.Text = obj.ImporteOrdenCompra.ToString();
                        }

                        if (obj.EstadoControl == "2")
                        {
                            lnkanular.Style.Add(HtmlTextWriterStyle.Display, "none");
                            lnkdescartar.Style.Add(HtmlTextWriterStyle.Display, "none");
                        }


                        if (obj.FechaEntrega.Year == 1)
                            this.lblFechaEntrega.Text = "";
                        else
                            this.lblFechaEntrega.Text = obj.FechaEntrega.ToString("dd/MM/yyyy");

                        FormaPagoDTO objFormaPagoDTO = objFormaPagoDAO.ListarPorClave(obj.IdFormaPago);

                        if (objFormaPagoDTO != null)
                            this.lblFormaPago.Text = objFormaPagoDTO.NombreFormaPago;



                        List<OrdenCompraLineaDTO> objLista = objOrdenCompraLineaDAO.Listar(int.Parse(lblIdOrdenCompra.Text));
                        this.gvLista.DataSource = objLista;
                        this.gvLista.DataBind();

                        pnleditar.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    string script = @"<script type='text/javascript'>alert('Error: " + ex.Message + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                
                
            }
            
        }
  
    }
}