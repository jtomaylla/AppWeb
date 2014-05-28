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
    public partial class frmPedidoCodigoPresupuesto : System.Web.UI.Page
    {

        PedidoPresupuestoDAO objPedidoPresupuestoDAO = new PedidoPresupuestoDAO();
        PedidoDAO objPedidoDAO = new PedidoDAO();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack) 
            {
                int IdPedido = Convert.ToInt32(Request.QueryString["id"]);
                this.txtIdPedido.Text = IdPedido.ToString();

                PedidoDTO objPedidoDTO =  objPedidoDAO.ListarPorClave(IdPedido);
                
                if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_APROBADO)
                    this.panRegistro.Visible = false;
                else
                    this.panRegistro.Visible = true;

                Listar();

            }
            this.btnAgregar.Attributes.Add("onclick", "return js_validar();");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PedidoPresupuestoDTO obj = new PedidoPresupuestoDTO();

            obj.IdPedido = Convert.ToInt32(this.txtIdPedido.Text);
            obj.CodigoPresupuesto = this.txtCodigoPresupuesto.Text;
            obj.Descripcion = this.txtDescripcion.Text;
            
            objPedidoPresupuestoDAO.Agregar(obj);

            Listar();

        }

        protected void Listar()
        {
            List<PedidoPresupuestoDTO> Lista = objPedidoPresupuestoDAO.Listar(Convert.ToInt32(this.txtIdPedido.Text));
            this.gvLista.DataSource = Lista;
            this.DataBind();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdPedidoPresupuesto = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Eliminar")
            {
                objPedidoPresupuestoDAO.Eliminar(IdPedidoPresupuesto);
                Listar();

            }
        }

        protected void gvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdPedido = Convert.ToInt32(Request.QueryString["id"]);
                Button btnEliminar = (Button)e.Row.FindControl("btnEliminar");
                PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(IdPedido);
                if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_APROBADO)
                    btnEliminar.Visible = false;
                else
                    btnEliminar.Visible = true;
            }
        }

    }
}