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
    public partial class frmPedidoLista : System.Web.UI.Page
    {

        PedidoDAO objPedidoDAO = new PedidoDAO();
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

            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

            //listar lineas
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);
            this.gvPedidoLista.DataSource = objPedidoLista;
            this.gvPedidoLista.DataBind();
           
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("ID_PEDIDO", "0");
            Response.Redirect("frmPedido.aspx?accion=new");
        }

        protected void gvPedidoLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdPedido = int.Parse(e.CommandArgument.ToString());
            PedidoDTO objPedidoDTO = objPedidoDAO.ListarPorClave(IdPedido);
    
            if (e.CommandName == "Seleccionar")
            {
                if (objPedidoDTO.Estado == AppConstantes.PEDIDO_ESTADO_APROBACION_BORRADOR)
                {

                    UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);

                    if (objUsuario.IdUsuario == objPedidoDTO.IdUsuarioCreacion)
                    {
                        Session.Add("ID_PEDIDO", IdPedido);
                        Response.Redirect("frmPedido.aspx?accion=edit");
                    }
                    else
                    {
                        Session.Add("ID_PEDIDO_CONSULTA", IdPedido);
                        Response.Redirect("frmPedidoConsulta.aspx");
                    }
                }
                else
                {
                    Session.Add("ID_PEDIDO_CONSULTA", IdPedido);
                    Response.Redirect("frmPedidoConsulta.aspx");
                }

            }
            else
                if (e.CommandName == "Eliminar")
                {

                }
        }

        protected void gvPedidoLista_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(HttpContext.Current.User.Identity.Name);
            this.gvPedidoLista.PageIndex = e.NewPageIndex;
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorSolicitante(objUsuario.IdUsuario);
            this.gvPedidoLista.DataSource = objPedidoLista;
            this.gvPedidoLista.DataBind();
        }
    }
}