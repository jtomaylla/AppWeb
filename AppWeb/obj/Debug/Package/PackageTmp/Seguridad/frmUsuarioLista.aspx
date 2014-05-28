<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarioLista.aspx.cs" Inherits="AppWeb.Seguridad.frmUsuarioLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var login = document.getElementById("<%= txtLoginUsuario.ClientID%>");
        var nombre = document.getElementById("<%= txtNombre.ClientID%>");
        if (!JS_hasValue(login, "TEXT")) {
            if (!JS_onError(frm, login, "TEXT", "Ingrese Login"))
                return false;
        }
        if (!JS_hasValue(nombre, "TEXT")) {
            if (!JS_onError(frm, nombre, "TEXT", "Ingrese Nombre"))
                return false;
        }
        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Mantenimiento de  Usuarios</div>

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
                <asp:TextBox ID="txtLoginUsuario" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nombre
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="370px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="370px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Estado
            </td>
            <td>
                :
            </td>
            <td>
                <asp:CheckBox ID="chkEstado" runat="server" /> Activo
            </td>
        </tr>

    </table>

    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />

    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
        CssClass="cssButton" onclick="btnActualizar_Click" />

    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" />

    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
        CssClass="cssButton" onclick="btnCancelar_Click" />

</div>

</asp:Panel>

<asp:Panel ID="panLista" runat="server">

    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />
    
    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnSelectedIndexChanged="gvLista_SelectedIndexChanged"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter" 
        onrowcommand="gvLista_RowCommand" onrowdatabound="gvLista_RowDataBound"
     >
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdUsuario" HeaderText="Id" ItemStyle-Width="50px">
        <ItemStyle Width="50px" />
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="LoginUsuario" HeaderText="Usuario" ItemStyle-Width="120px">
        <ItemStyle Width="120px" />
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUsuario" HeaderText="Nombre" ItemStyle-Width="350px">
        <ItemStyle Width="350px" />
        </asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" CommandName="Select" CausesValidation="False" 
                    id="imgSelect" 
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:imagebutton ID="imgCambioClave" runat="server" Text="Cambiar Clave" CommandName="CambiarClave" CausesValidation="false" ImageUrl="~/Images/key.png"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview> 
</asp:Panel>
<asp:Panel ID="panPerfiles" runat="server">
    <div class="cssTablaCabeceraRegistro">Perfiles asociados</div>

    <div class="cssTablaRegistro">
        <asp:TreeView ID="tvwPerfiles" runat="server" imageset="Arrows" ShowCheckBoxes="All">
        </asp:TreeView>
        <asp:Button ID="btnGrabarPerfil" runat="server" Text="Grabar Perfiles" 
            CssClass="cssButton" onclick="btnGrabarPerfil_Click" />
    </div>
</asp:Panel>
    
    
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
