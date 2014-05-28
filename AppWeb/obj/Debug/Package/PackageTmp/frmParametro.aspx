<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmParametro.aspx.cs" Inherits="AppWeb.frmParametro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function js_validar() {
            var frm = document.getElementById("formmain");
            var descripcion = document.getElementById("<%= txtRazonSocial.ClientID%>");

            if (!JS_hasValue(descripcion, "TEXT")) {
                if (!JS_onError(frm, descripcion, "TEXT", "Ingrese Razón Social"))
                    return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Mantenimiento de Parámetros</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>
<asp:Panel ID="panRegistro" runat="server">
<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
    <table >
    <tr>
        <td>Id</td>
        <td>:</td>
        <td><asp:TextBox ID="txtId" runat="server" Width="40px" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Razón Social</td>
        <td>:</td>
        <td><asp:TextBox ID="txtRazonSocial" runat="server" Width="500px" MaxLength="150"></asp:TextBox></td>
    </tr>
    <tr>
        <td>RUC</td>
        <td>:</td>
        <td><asp:TextBox ID="txtRuc" runat="server" Width="100px" MaxLength="20"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Dirección</td>
        <td>:</td>
        <td><asp:TextBox ID="txtDireccion" runat="server" Width="500px" MaxLength="150"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Teléfono</td>
        <td>:</td>
        <td><asp:TextBox ID="txtTelefono" runat="server" Width="100px" MaxLength="20"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Contacto</td>
        <td>:</td>
        <td><asp:TextBox ID="txtContacto" runat="server" Width="500px" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Teléfono Contacto</td>
        <td>:</td>
        <td><asp:TextBox ID="txtTelefonoContacto" runat="server" Width="100px" MaxLength="20"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email Contacto</td>
        <td>:</td>
        <td><asp:TextBox ID="txtEmail" runat="server" Width="297px" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Web</td>
        <td>:</td>
        <td><asp:TextBox ID="txtWeb" runat="server" Width="400px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Logo</td>
        <td>:</td>
        <td><asp:FileUpload ID="fuLogo" runat="server" />  <asp:Label ID="lblNombreLogo" runat="server" Width="200px" ReadOnly="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Almacen por Defecto</td>
        <td>:</td>
        <td>
            <asp:DropDownList ID="ddlAlmacen" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    </table>

    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton" onclick="btnActualizar_Click" />

</div>
</asp:Panel>
</asp:Content>
