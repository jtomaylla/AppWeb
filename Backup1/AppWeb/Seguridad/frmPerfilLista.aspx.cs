using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;
using pe.com.rbtec.web;

namespace AppWeb.Seguridad
{
    public partial class frmPerfilLista : System.Web.UI.Page
    {
        FuncionDAO objFuncionDAO = new FuncionDAO();
        PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }

            this.btnGrabar.Attributes.Add("onclick", "return js_validar();");
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
        }


        protected void InicializaPagina()
        {
            Listar();
            this.txtIdPerfil.ReadOnly = true;
            this.txtIdPerfil.BackColor = System.Drawing.ColorTranslator.FromHtml(AppConstantes.TXT_BACKCOLOR_INACTIVO);

            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            this.panFunciones.Visible = false;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = true;
            this.btnCancelar.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtIdPerfil.Text = "";
            this.txtNombrePerfil.Text = "";
            this.chkEstado.Checked = true;

            this.panRegistro.Visible = true;
            this.panLista.Visible = false;

            this.btnGrabar.Visible = true;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            PerfilDTO obj = new PerfilDTO();
            PerfilDAO objDAO = new PerfilDAO();

            if (this.txtIdPerfil.Text == "")
            {
                obj.NombrePerfil = this.txtNombrePerfil.Text;
                if (this.chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";

                int id = objDAO.Agregar(obj);
                this.txtIdPerfil.Text = id.ToString();
                this.lblMensaje.Text = "Se registro el Perfil";
///////////////77
                obj = objDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text));

                this.txtNombrePerfil.Text = obj.NombrePerfil;
                if (obj.Estado == "1")
                    this.chkEstado.Checked = true;
                else
                    this.chkEstado.Checked = false;

                this.panRegistro.Visible = true;
                this.panLista.Visible = false;
                this.panFunciones.Visible = true;

                this.btnGrabar.Visible = false;
                this.btnActualizar.Visible = true;
                this.btnEliminar.Visible = true;
                this.btnCancelar.Visible = true;

                //LISTAR FUNCIONES
                ListarFunciones(obj.IdPerfil);



            }
            else
            {
                obj = objDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text));
                obj.NombrePerfil = this.txtNombrePerfil.Text;
                if (this.chkEstado.Checked)
                    obj.Estado = "1";
                else
                    obj.Estado = "0";

                objDAO.Actualizar(obj);
                this.lblMensaje.Text = "Se actualizo el registro";
            }

            Listar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            PerfilDTO obj = new PerfilDTO();
            PerfilDAO objDAO = new PerfilDAO();

            obj = objDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text));
            obj.NombrePerfil = this.txtNombrePerfil.Text;
            if (this.chkEstado.Checked)
                obj.Estado = "1";
            else
                obj.Estado = "0";

            objDAO.Actualizar(obj);
            this.lblMensaje.Text = "Se actualizo el registro";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            PerfilDTO obj = new PerfilDTO();
            PerfilDAO objDAO = new PerfilDAO();

            if (this.txtIdPerfil.Text != "")
            {
                objDAO.Eliminar(Convert.ToInt32(this.txtIdPerfil.Text)); 
            }
            Listar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.panRegistro.Visible = false;
            this.panLista.Visible = true;
            this.panFunciones.Visible = false;

            this.btnGrabar.Visible = false;
            this.btnActualizar.Visible = false;
            this.btnEliminar.Visible = false;
            this.btnCancelar.Visible = true;

            Listar();
        }

        protected void gvLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilDAO objDAO = new PerfilDAO();
            PerfilDTO obj;
            try
            {
                this.txtIdPerfil.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text));

                this.txtNombrePerfil.Text = obj.NombrePerfil;
                if (obj.Estado == "1")
                    this.chkEstado.Checked = true;
                else
                    this.chkEstado.Checked = false;

                this.panRegistro.Visible = true;
                this.panLista.Visible = false;
                this.panFunciones.Visible = true;

                this.btnGrabar.Visible = false;
                this.btnActualizar.Visible = true;
                this.btnEliminar.Visible = true;
                this.btnCancelar.Visible = true;

                List<PerfilFuncionDTO> ListaPerfilFuncionDTO = objPerfilFuncionDAO.ListarPorPerfil(Convert.ToInt32(this.txtIdPerfil.Text));
                this.gvListaFuncion.DataSource = ListaPerfilFuncionDTO;
                this.gvListaFuncion.DataBind();


                //LISTAR FUNCIONES
                ListarFunciones(obj.IdPerfil);
            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void Listar()
        {
            List<PerfilDTO> obj;
            PerfilDAO objDAO = new PerfilDAO();
            try
            {
                obj = objDAO.Listar();
                this.gvLista.DataSource = obj;
                this.gvLista.DataBind();
            }
            catch (Exception err)
            {
                throw (err);
            }

        }

        protected void ListarFunciones(int idPerfil)
        {
            List<FuncionDTO> objFuncion;
            PerfilFuncionDTO objPerfilFuncionDTO;

            FuncionDAO objFuncionDAO = new FuncionDAO();
            PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();

            try
            {
                //CARGAR PERFILES
                tvwFunciones.Nodes.Clear();
                objFuncion = objFuncionDAO.Listar();
                foreach (FuncionDTO funcion in objFuncion)
                {
                    if (funcion.Estado.Equals("1"))
                    {
                        TreeNode nodo1 = new TreeNode((string)funcion.NombreFuncion);
                        nodo1.Value = funcion.IdFuncion.ToString();
                        tvwFunciones.Nodes.Add(nodo1);
                        //VERIFICAR SI PERFIL TIENE FUNCION ASIGNADA
                        int idFuncion = funcion.IdFuncion;
                        objPerfilFuncionDTO = objPerfilFuncionDAO.ListarPorClave(idPerfil, idFuncion);
                        if (objPerfilFuncionDTO.IdPerfil > 0)
                            nodo1.Checked = true;
                    }
                }
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        protected void gvListaFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilDAO objDAO = new PerfilDAO();
            PerfilDTO obj;
            try
            {
                this.txtIdPerfil.Text = gvLista.SelectedRow.Cells[0].Text;
                obj = objDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text));

                this.txtNombrePerfil.Text = obj.NombrePerfil;
                if (obj.Estado == "1")
                    this.chkEstado.Checked = true;
                else
                    this.chkEstado.Checked = false;

            }
            catch (Exception err)
            {
                this.lblMensaje.Text = err.Message.ToString();
            }
        }

        protected void btnAgregarFuncion_Click(object sender, EventArgs e)
        {
            objPerfilFuncionDAO.ListarPorPerfil(1);
 
        }

      

        protected void btnGrabarFuncion_Click(object sender, EventArgs e)
        {
            PerfilFuncionDTO objPerfilFuncionDTO;
            PerfilFuncionDAO objPerfilFuncionDAO = new PerfilFuncionDAO();

            int idPerfil = Convert.ToInt32(this.txtIdPerfil.Text);
            for (int i = 0; i < tvwFunciones.Nodes.Count; i++)
            {
                TreeNode nodo1 = tvwFunciones.Nodes[i];
                int idFuncion = int.Parse(nodo1.Value);
                if (nodo1.Checked)
                {
                    objPerfilFuncionDTO = objPerfilFuncionDAO.ListarPorClave(idPerfil, idFuncion);
                    if (objPerfilFuncionDTO.IdFuncion == 0)
                    {
                        PerfilFuncionDTO objPerfilFuncion = new PerfilFuncionDTO();
                        objPerfilFuncion.IdPerfil = idPerfil;
                        objPerfilFuncion.IdFuncion = idFuncion;
                        objPerfilFuncion.Estado = "1";
                        objPerfilFuncion.Orden = 99;
                        objPerfilFuncionDAO.Agregar(objPerfilFuncion);
                    }
                }
                else
                {
                    PerfilFuncionDTO objPerfilFuncion = new PerfilFuncionDTO();
                    objPerfilFuncion.IdPerfil = idPerfil;
                    objPerfilFuncion.IdFuncion = idFuncion;
                    objPerfilFuncionDAO.Eliminar(objPerfilFuncion);
                }
            }
        }


        protected void gvListaFuncion_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int orden = (int)DataBinder.Eval(e.Row.DataItem, "Orden");
                string estado = (string)DataBinder.Eval(e.Row.DataItem, "Estado");

                TextBox txtOrden = (TextBox)e.Row.FindControl("txtOrden");

                txtOrden.Text = orden.ToString();

   
            }
        }

        protected void btnActualizarListaFuncion_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";

            try
            {
                foreach (GridViewRow row in this.gvListaFuncion.Rows)
                {
                    int IdFuncion = Convert.ToInt32(row.Cells[0].Text);
                    TextBox txtOrden = (TextBox)row.Cells[1].FindControl("txtOrden");

                    PerfilFuncionDTO objPerfilFuncionDTO = objPerfilFuncionDAO.ListarPorClave(Convert.ToInt32(this.txtIdPerfil.Text), IdFuncion);
                    objPerfilFuncionDTO.Orden = Convert.ToInt32(txtOrden.Text);
                    objPerfilFuncionDAO.Actualizar(objPerfilFuncionDTO);

                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }
        }  
        
    }
}