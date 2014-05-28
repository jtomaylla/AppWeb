<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarioCambioClave.aspx.cs" Inherits="AppWeb.Seguridad.frmUsuarioCambioClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var clave = document.getElementById("<%= txtClave.ClientID%>");
        var clave2 = document.getElementById("<%= txtClave2.ClientID%>");
        if (!JS_hasValue(clave, "TEXT")) {
            if (!JS_onError(frm, clave, "TEXT", "Ingrese clave"))
                return false;
        }
        if (!JS_hasValue(clave2, "TEXT")) {
            if (!JS_onError(frm, clave2, "TEXT", "Ingrese confirmación de clave"))
                return false;
        }
        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Cambio de Clave</div>
<asp:Panel ID="panRegistro" runat="server">
<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
<table>
        <tr>
            <td>
                Id
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtId" runat="server" Width="60px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Login
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtLoginUsuario" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Clave
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Confirmar Clave
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtClave2" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>

    </table>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
        CssClass="cssButton" onclick="btnActualizar_Click" />

    <asp:Button ID="btnCancelar" runat="server" Text="Volver" 
        CssClass="cssButton" onclick="btnCancelar_Click" />
    
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</div>
</asp:Panel>
</asp:Content>
