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
    public partial class frmRecepcionInventarioTransaccion : System.Web.UI.Page
    {

        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        RecepcionDAO objRecepcionDAO = new RecepcionDAO();
        RecepcionLineaDAO objRecepcionLineaDAO = new RecepcionLineaDAO();
        OrdenCompraDAO objOrdenCompraDAO = new OrdenCompraDAO();
        OrdenCompraLineaDAO objOrdenCompraLineaDAO = new OrdenCompraLineaDAO();
        InvTransaccionDAO objInvTransaccionDAO = new InvTransaccionDAO();

        InvTipoTransaccionDAO objTipoTransaccionDAO = new InvTipoTransaccionDAO();
        InvAlmacenDAO objAlmacenDAO = new InvAlmacenDAO();
        ArticuloDAO objArticuloDAO = new ArticuloDAO();
        ParametroDAO objParametroDAO = new ParametroDAO();
        SedeDAO objSedeDAO = new SedeDAO();
        ProyectoDAO objProyectoDAO = new ProyectoDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
            
            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");


        }

        protected void InicializaPagina()
        {

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);
            ParametroDTO objParametroDTO = objParametroDAO.ListarPorClave(AppConstantes.ID_PARAMETRO);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            if (Session["ID_RECEPCION_LINEA"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            int IdRecepcionLinea = Convert.ToInt32(Session["ID_RECEPCION_LINEA"]);

            RecepcionLineaDTO objRecepcionLineaDTO;
            RecepcionDTO objRecepcionDTO;
            OrdenCompraDTO objOrdenCompraDTO;
            OrdenCompraLineaDTO objOrdenCompraLineaDTO;
            ArticuloDTO objArticuloDTO;

            objRecepcionLineaDTO = objRecepcionLineaDAO.ListarPorClave(IdRecepcionLinea);
            objRecepcionDTO = objRecepcionDAO.ListarPorClave(objRecepcionLineaDTO.IdRecepcion);
            objOrdenCompraDTO = objOrdenCompraDAO.ListarPorClave(objRecepcionLineaDTO.IdOrdenCompra);
            objOrdenCompraLineaDTO = objOrdenCompraLineaDAO.ListarPorClave(objRecepcionLineaDTO.IdOrdenCompra, objRecepcionLineaDTO.IdOrdenCompraLinea);
            objArticuloDTO = objArticuloDAO.ListarPorClave(objOrdenCompraLineaDTO.IdArticulo);

            this.lblIdRecepcion.Text = objRecepcionLineaDTO.IdRecepcion.ToString();
            this.lblFechaRecepcion.Text = objRecepcionDTO.FechaRecepcion.ToString("dd/MM/yyyy");
            this.lblIdOrdenCompra.Text = objRecepcionLineaDTO.IdOrdenCompra.ToString();
            this.lblNumeroLineaOC.Text = objOrdenCompraLineaDTO.NumeroLinea.ToString();
            this.lblRazonSocial.Text = objOrdenCompraDTO.RazonSocial;

            
            SedeDTO objSedeDTO =  objSedeDAO.ListarPorClave(objRecepcionDTO.IdSede);
            ProyectoDTO objProyectoDTO = objProyectoDAO.ListarPorClave(objRecepcionDTO.IdProyecto);
            
            if (objSedeDTO!=null)
                this.lblSede.Text = objSedeDTO.NombreSede;

            if (objProyectoDTO!=null)
                this.lblProyecto.Text = objProyectoDTO.NombreProyecto;

            this.txtFechaTransaccion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.lblArticulo.Text = objArticuloDTO.CodigoArticulo + " - " + objOrdenCompraLineaDTO.DescripcionArticulo;
            this.lblCantidadRecibo.Text = objRecepcionLineaDTO.CantidadRecepcionada.ToString();

            List<InvTipoTransaccionDTO> objTipoTransaccionLista =  objTipoTransaccionDAO.Listar();
            this.ddlTipoTransaccion.DataSource = objTipoTransaccionLista;
            this.ddlTipoTransaccion.DataTextField = "NombreTransaccion";
            this.ddlTipoTransaccion.DataValueField = "IdTipoTransaccion";
            this.ddlTipoTransaccion.DataBind();

            foreach (ListItem li_item in this.ddlTipoTransaccion.Items)
            {
                if (Convert.ToString(li_item.Value) == AppConstantes.TRXINV_INGRESO_RECEPCION_OC)
                    li_item.Selected = true;
            }


            this.ddlTipoTransaccion.Enabled = false;

            List<InvAlmacenDTO> objAlmacenLista = objAlmacenDAO.Listar();
            this.ddlAlmacen.DataSource = objAlmacenLista;
            this.ddlAlmacen.DataTextField = "NombreAlmacen";
            this.ddlAlmacen.DataValueField = "IdAlmacen";
            this.ddlAlmacen.DataBind();
            this.ddlAlmacen.Items.Insert(0, new ListItem("- Seleccione -", "0"));


            if (objParametroDTO.IdAlmacen > 0)
            {
                foreach (ListItem li_item in this.ddlAlmacen.Items)
                {
                    if (Convert.ToString(li_item.Value) == objParametroDTO.IdAlmacen.ToString())
                        li_item.Selected = true;
                }

            }

            this.txtFechaTransaccion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtIdRecepcion.Text = objRecepcionLineaDTO.IdRecepcion.ToString();
            this.txtIdRecepcionLinea.Text = objRecepcionLineaDTO.IdRecepcionLinea.ToString();
            this.txtIdArticulo.Text = objRecepcionLineaDTO.IdArticulo.ToString();
            this.txtDescripcion.Text = "Ingreso por recepción de O/C " + objRecepcionLineaDTO.IdOrdenCompra.ToString();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            InvTransaccionDTO objInvTransaccionDTO = new InvTransaccionDTO();
 
            RecepcionLineaDTO objRecepcionLineaDTO = new RecepcionLineaDTO();

            RecepcionDTO objRecepcionDTO = objRecepcionDAO.ListarPorClave( Convert.ToInt32(this.lblIdRecepcion.Text));

            objInvTransaccionDTO.IdArticulo = Convert.ToInt32(this.txtIdArticulo.Text);
            objInvTransaccionDTO.IdAlmacen = Convert.ToInt32(this.ddlAlmacen.SelectedValue);
            objInvTransaccionDTO.IdTipoTransaccion = Convert.ToInt32(this.ddlTipoTransaccion.SelectedValue);
            objInvTransaccionDTO.Fecha = DateTime.Now; //AppUtilidad.stringToDateTime( this.txtFechaTransaccion.Text, "DD/MM/YYYY");
            objInvTransaccionDTO.Cantidad = Convert.ToDecimal(this.lblCantidadRecibo.Text);
            objInvTransaccionDTO.TipoOrigen = "REC";
            objInvTransaccionDTO.IdTransaccionOrigen = Convert.ToInt32(this.txtIdRecepcion.Text);
            objInvTransaccionDTO.IdLineaOrigen = Convert.ToInt32(this.txtIdRecepcionLinea.Text);
            objInvTransaccionDTO.Descripcion = this.txtDescripcion.Text;

            objInvTransaccionDTO.IdSede = objRecepcionDTO.IdSede;
            objInvTransaccionDTO.IdProyecto = objRecepcionDTO.IdProyecto;
            objInvTransaccionDTO.Ubicacion = this.txtUbicacion.Text;
            objInvTransaccionDTO.FechaVencimiento = AppUtilidad.stringToDateTime(this.txtFechaVencimiento.Text, "DD/MM/YYYY");
            objInvTransaccionDTO.Lote = this.txtLote.Text;

            objInvTransaccionDTO.Marca = this.txtMarca.Text;
            objInvTransaccionDTO.Modelo = this.txtModelo.Text;
            objInvTransaccionDTO.Serie = this.txtSerie.Text;
            objInvTransaccionDTO.ObservacionesAlmacenamiento = this.txtObsAlmacenamiento.Text;

            objInvTransaccionDTO.IdUsuarioCreacion = Convert.ToInt32(this.txtIdUsuario.Text);
            objInvTransaccionDTO.FechaCreacion = DateTime.Now;

            objInvTransaccionDAO.Agregar(objInvTransaccionDTO);

            objRecepcionLineaDTO = objRecepcionLineaDAO.ListarPorClave( Convert.ToInt32( this.txtIdRecepcionLinea.Text));

            objRecepcionLineaDTO.Estado = "2"; // Transferido

            objRecepcionLineaDAO.Actualizar(objRecepcionLineaDTO);
            
            Response.Redirect("frmRecepcionInventario.aspx");
                
        }

    }
}