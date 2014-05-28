<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMantProveedor.aspx.cs" Inherits="AppWeb.frmMantProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var razonsocial = document.getElementById("<%= txtRazonSocial.ClientID%>");
        var ruc = document.getElementById("<%= txtRuc.ClientID%>");
        var tipo = document.getElementById("<%= ddlTipo.ClientID%>");
        var direccion = document.getElementById("<%= txtDireccion.ClientID%>");
        var email = document.getElementById("<%= txtEmail.ClientID%>");
        var telefono = document.getElementById("<%= txtTelefono.ClientID%>");
        var contacto = document.getElementById("<%= txtContacto.ClientID%>");

        if (!JS_hasValue(razonsocial, "TEXT")) {
            if (!JS_onError(frm, razonsocial, "TEXT", "Ingrese Razon Social"))
                return false;
        }
        if (!JS_hasValue(ruc, "TEXT")) {
            if (!JS_onError(frm, ruc, "TEXT", "Ingrese RUC"))
                return false;
        }
        if (!JS_hasValue(tipo, "SELECT")) {
            if (!JS_onError(frm, tipo, "SELECT", "Seleccione Tipo Persona"))
                return false;
        }

        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Mantenimiento de Proveedores</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="panLista" runat="server">

    Buscar:<asp:TextBox ID="txtBusqueda" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnBuscar" CssClass="cssButton" runat="server" Text="Buscar" onclick="btnBuscar_Click" />

    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />

    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        PageSize="20" 
        AllowPaging="true" 
        OnRowCommand="gvLista_RowCommand"  
        OnPageIndexChanging="gvLista_PageIndexChanging"

    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdProveedor" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Razon Social" ItemStyle-Width="600px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Ruc" HeaderText="RUC" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Contacto" HeaderText="Contacto" ItemStyle-Width="250px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerProveedor" runat="server" Text="Editar" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdProveedor") %>'
                    CssClass="cssButton" />

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
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
            <td>Razon Social</td>
            <td>:</td>
            <td><asp:TextBox ID="txtRazonSocial" runat="server" Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>RUC</td>
            <td>:</td>
            <td><asp:TextBox ID="txtRuc" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Tipo Persona</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlTipo" runat="server" Width="200px"/></td>
        </tr>
        <tr>
            <td>Dirección</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email</td>
            <td>:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td>:</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Contacto</td>
            <td>:</td>
            <td><asp:TextBox ID="txtContacto" runat="server" Width="800px"></asp:TextBox></td>
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
