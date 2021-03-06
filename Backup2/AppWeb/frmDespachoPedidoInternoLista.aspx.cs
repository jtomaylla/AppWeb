﻿using System;
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
    public partial class frmDespachoPedidoInternoLista : System.Web.UI.Page
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

            string LoginUsuario = HttpContext.Current.User.Identity.Name;
            UsuarioDTO objUsuario = objUsuarioDAO.ListarPorLogin(LoginUsuario);

            if (objUsuario != null)
                this.txtIdUsuario.Text = objUsuario.IdUsuario.ToString();

            //listar lineas
            List<PedidoDTO> objPedidoLista = objPedidoDAO.ListarPorDespachoInventario();
            this.gvPedidoLista.DataSource = objPedidoLista;
            this.gvPedidoLista.DataBind();

        }

        protected void gvPedidoLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdPedido = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Seleccionar")
            {
                Session.Add("ID_PEDIDO_INTERNO", IdPedido);
                Response.Redirect("frmDespachoPedidoInterno.aspx");
            }
        }
        

    }
}