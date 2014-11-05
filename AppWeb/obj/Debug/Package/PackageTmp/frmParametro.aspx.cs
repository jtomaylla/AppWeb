using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using pe.com.rbtec.web;
using pe.com.sil.dal.dto;
using pe.com.sil.dal.dao;

using pe.com.seg.dal.dto;
using pe.com.seg.dal.dao;

namespace AppWeb
{
    public partial class frmParametro : System.Web.UI.Page
    {
        ParametroDAO objParametroDAO = new ParametroDAO();
        InvAlmacenDAO objInvAlmacenDAO = new InvAlmacenDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnActualizar.Attributes.Add("onclick", "return js_validar();");
            if (!Page.IsPostBack)
            {
                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            Listar();
        }

        protected void Listar()
        {
            
            this.lblMensaje.Text = "";
            ParametroDTO obj = null;

            try
            {
                obj = objParametroDAO.ListarPorClave(1);
                txtId.Text = obj.IdRegistro.ToString();
                txtRazonSocial.Text = obj.RazonSocial.ToString();
                txtRuc.Text = obj.Ruc.ToString();
                txtDireccion.Text = obj.Direccion.ToString();
                txtTelefono.Text = obj.Telefono1.ToString();
                txtContacto.Text = obj.Contacto.ToString();
                txtTelefonoContacto.Text = obj.TelefonoContacto.ToString();
                txtEmail.Text = obj.EmailContacto.ToString();
                txtWeb.Text = obj.WebSite.ToString();
                lblNombreLogo.Text = obj.Logo;
                
                List<InvAlmacenDTO> ListaAlmacenDTO = objInvAlmacenDAO.Listar();

                try
                {
                    this.ddlAlmacen.DataSource = ListaAlmacenDTO;
                    this.ddlAlmacen.DataTextField = "NombreAlmacen";
                    this.ddlAlmacen.DataValueField = "IdAlmacen";
                    this.ddlAlmacen.DataBind();
                    this.ddlAlmacen.Items.Insert(0, new ListItem("- Seleccione -", "0"));
                }
                catch (Exception err)
                {
                    this.lblMensaje.Text = err.ToString();
                }

            }
            catch (Exception err)
            {
                throw (err);
            }

        }
    
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            
            ParametroDTO objParametroDTO = new ParametroDTO();

            try 
            {
                objParametroDTO = objParametroDAO.ListarPorClave(Convert.ToInt32(this.txtId.Text));

                objParametroDTO.RazonSocial = txtRazonSocial.Text;
                objParametroDTO.Ruc = txtRuc.Text;
                objParametroDTO.Direccion = txtDireccion.Text;
                objParametroDTO.Telefono1 = txtTelefono.Text;
                objParametroDTO.Contacto = txtContacto.Text;
                objParametroDTO.TelefonoContacto = txtTelefonoContacto.Text;
                objParametroDTO.EmailContacto = txtEmail.Text;
                objParametroDTO.WebSite = txtWeb.Text;

                if (fuLogo.HasFile)
                {
                    string strNombreLogo = "logo" + Path.GetExtension(fuLogo.FileName);
                    objParametroDTO.Logo = strNombreLogo;
                    fuLogo.PostedFile.SaveAs(Path.GetDirectoryName(Request.PhysicalPath) + "/Images/" + strNombreLogo);

                    this.lblNombreLogo.Text = strNombreLogo;

                }
            
                objParametroDTO.IdAlmacen = Convert.ToInt32(this.ddlAlmacen.SelectedValue);

                objParametroDAO.Actualizar(objParametroDTO);
            
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.ToString();
            }

        }
 
    }
}