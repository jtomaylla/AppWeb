<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMantClase.aspx.cs" Inherits="AppWeb.frmMantClase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var codigo = document.getElementById("<%= txtCodigo.ClientID%>");
        var descripcion = document.getElementById("<%= txtDescripcion.ClientID%>");

        if (!JS_hasValue(codigo, "TEXT")) {
            if (!JS_onError(frm, codigo, "TEXT", "Ingrese Codigo"))
                return false;
        }
        if (!JS_hasValue(descripcion, "TEXT")) {
            if (!JS_onError(frm, descripcion, "TEXT", "Ingrese Descripción"))
                return false;
        }

        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Mantenimiento de Clase</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="panLista" runat="server">
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />
    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnSelectedIndexChanged="gvLista_SelectedIndexChanged"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdClase" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodClase" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreClase" HeaderText="Descripción" ItemStyle-Width="500px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" CommandName="Select" CausesValidation="False" 
                    id="ImageButton1" ToolTip="Editar" 
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:gridview> 
</asp:Panel>
<asp:Panel ID="panRegistro" runat="server">
    <div class="cssTablaCabeceraRegistro">Registro</div>
    <div class="cssTablaRegistro">
        <table >
        <tr>
            <td>Id</td>
            <td>:</td>
            <td><asp:TextBox ID="txtId" runat="server" Width="40px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Codigo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtCodigo" runat="server" MaxLength="2" Width="30px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server" Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>:</td>
            <td><asp:CheckBox ID="chkEstado" runat="server" /> Activo</td>
        </tr>
	    </table>

        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton" onclick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" onclick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" onclick="btnCancelar_Click" Text="Cancelar" />
    </div>
</asp:Panel>
</asp:Content>
