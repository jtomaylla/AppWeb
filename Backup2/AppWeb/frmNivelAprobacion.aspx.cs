using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using pe.com.sil.dal.dao;
using pe.com.sil.dal.dto;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;

namespace AppWeb
{
    public partial class frmNivelAprobacion : System.Web.UI.Page
    {
        OrdenCompraNivelAprobacionDAO objOrdenCompraNivelAprobacionDAO = new OrdenCompraNivelAprobacionDAO();
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnActualizar.Attributes.Add("onclick", "return confirm('Desea Ud. Actualizar los registros?')");
        }

        protected void InicializaPagina()
        {
            this.lblMensaje.Text = "";

            try{
                List<OrdenCompraNivelAprobacionDTO> Lista = objOrdenCompraNivelAprobacionDAO.Listar();
                this.gvLista.DataSource = Lista;
                this.gvLista.DataBind();
            }
            catch(Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }

        protected void gvLista_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nombreNivelAprobacion = (string)DataBinder.Eval(e.Row.DataItem, "NombreNivelAprobacion");
                Decimal limiteInferior = (Decimal)DataBinder.Eval(e.Row.DataItem, "LimiteInferior");
                Decimal limiteSuperior = (Decimal)DataBinder.Eval(e.Row.DataItem, "LimiteSuperior");
                int IdUsuarioAprobacion = (int)DataBinder.Eval(e.Row.DataItem, "IdUsuarioAprobacion");
                string estado = (string)DataBinder.Eval(e.Row.DataItem, "Estado");

                TextBox txtNombreNivelAprobacion = (TextBox)e.Row.FindControl("txtNombreNivelAprobacion");
                TextBox txtLimiteInferior = (TextBox)e.Row.FindControl("txtLimiteInferior");
                TextBox txtLimiteSuperior = (TextBox)e.Row.FindControl("txtLimiteSuperior");
                DropDownList ddlUsuarioAprobacion = (DropDownList)e.Row.FindControl("ddlUsuarioAprobacion");
                CheckBox chkEstado = (CheckBox)e.Row.FindControl("chkEstado");

                txtNombreNivelAprobacion.Text = nombreNivelAprobacion;
                txtLimiteInferior.Text = limiteInferior.ToString();
                txtLimiteSuperior.Text = limiteSuperior.ToString();

                List<UsuarioDTO> ListaUsuarioDTO = objUsuarioDAO.ListarOrdenadoPorNombreUsuario();
                ddlUsuarioAprobacion.DataSource = ListaUsuarioDTO;
                ddlUsuarioAprobacion.DataTextField = "NombreUsuario";
                ddlUsuarioAprobacion.DataValueField = "IdUsuario";
                ddlUsuarioAprobacion.DataBind();
                ddlUsuarioAprobacion.Items.Insert(0, new ListItem("- Seleccione -", "0"));

                foreach (ListItem li_item in ddlUsuarioAprobacion.Items)
                {
                    if (Convert.ToString(li_item.Value) == IdUsuarioAprobacion.ToString())
                        li_item.Selected = true;
                }

                if (estado == "1")
                    chkEstado.Checked = true;
                else
                    chkEstado.Checked = false;

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            this.lblMensaje.Text = "";

            try
            {
                foreach (GridViewRow row in this.gvLista.Rows)
                {
                    int IdNivelAprobacion = Convert.ToInt32(row.Cells[0].Text);
                    TextBox txtNombreNivelAprobacion = (TextBox)row.Cells[1].FindControl("txtNombreNivelAprobacion");
                    TextBox txtLimiteInferior = (TextBox)row.Cells[2].FindControl("txtLimiteInferior");
                    TextBox txtLimiteSuperior = (TextBox)row.Cells[3].FindControl("txtLimiteSuperior");
                    DropDownList ddlUsuarioAprobacion = (DropDownList)row.Cells[4].FindControl("ddlUsuarioAprobacion");
                    CheckBox chkEstado = (CheckBox)row.Cells[5].FindControl("chkEstado");

                    OrdenCompraNivelAprobacionDTO objOrdenCompraNivelAprobacionDTO = objOrdenCompraNivelAprobacionDAO.ListarPorClave(IdNivelAprobacion);
                    objOrdenCompraNivelAprobacionDTO.NombreNivelAprobacion = txtNombreNivelAprobacion.Text;
                    objOrdenCompraNivelAprobacionDTO.LimiteInferior = Convert.ToDecimal(txtLimiteInferior.Text);
                    objOrdenCompraNivelAprobacionDTO.LimiteSuperior = Convert.ToDecimal(txtLimiteSuperior.Text);
                    objOrdenCompraNivelAprobacionDTO.IdUsuarioAprobacion = Convert.ToInt32(ddlUsuarioAprobacion.SelectedValue);

                    if (chkEstado.Checked)
                        objOrdenCompraNivelAprobacionDTO.Estado = "1";
                    else
                        objOrdenCompraNivelAprobacionDTO.Estado = "0";

                    objOrdenCompraNivelAprobacionDAO.Actualizar(objOrdenCompraNivelAprobacionDTO);

                }
            }
            catch(Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }  


    }
}