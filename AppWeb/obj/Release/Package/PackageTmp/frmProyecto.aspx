<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProyecto.aspx.cs" Inherits="AppWeb.frmProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">

    function js_validar_asignacion() {
        var frm = document.getElementById("formmain");
        var usuario = document.getElementById("<%= ddlUsuario.ClientID%>");
        var tipo = document.getElementById("<%= ddlTipo.ClientID%>");

        if (!JS_hasValue(usuario, "SELECT")) {
            if (!JS_onError(frm, usuario, "SELECT", "Seleccione Usuario"))
                return false;
        }

        if (!JS_hasValue(tipo, "SELECT")) {
            if (!JS_onError(frm, tipo, "SELECT", "Seleccione Tipo"))
                return false;
        }

        return true;
    }


    function js_validar() {
        var frm = document.getElementById("formmain");
        var txtNombre = document.getElementById("<%= txtNombre.ClientID%>");
        var txtNombreCorto = document.getElementById("<%= txtNombreCorto.ClientID%>");
        
        if (!JS_hasValue(txtNombre, "TEXT")) {
            if (!JS_onError(frm, txtNombre, "TEXT", "Ingrese nombre del proyecto"))
                return false;
        }

        if (!JS_hasValue(txtNombreCorto, "TEXT")) {
            if (!JS_onError(frm, txtNombreCorto, "TEXT", "Ingrese nombre corto"))
                return false;
        }

        return true;
    }

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Mantenimiento de Proyectos</div>

<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

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
            <td>Nombre Proyecto <span class="cssError">(*)</span></td>
            <td>:</td>
            <td><asp:TextBox ID="txtNombre" runat="server" Width="800px" MaxLength="120" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Nombre Corto <span class="cssError">(*)</span></td>
            <td>:</td>
            <td><asp:TextBox ID="txtNombreCorto" runat="server" Width="100px" MaxLength="20" ></asp:TextBox></td>
        </tr>
        <tr>
            <td>Estado <span class="cssError">(*)</span></td>
            <td>:</td>
            <td><asp:CheckBox ID="chkEstado" runat="server" /> Activo</td>
        </tr>
	</table>

    <span class="cssError">(*)</span> Campo obligatorio
    <br />
    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton" onclick="btnActualizar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" onclick="btnEliminar_Click" />
    <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" onclick="btnCancelar_Click" Text="Cancelar" />
    
    <asp:Panel ID="panUsuario" runat="server">
    
<table class="gridview">
<tr>
	<th scope="col">Usuario</th>
    <th scope="col">Tipo</th>
    <th scope="col">Estado</th>
    <th scope="col">&nbsp;</th>
</tr>    
    <tr>
        <td>
            <asp:DropDownList ID="ddlUsuario" runat="server" Width="400" />
        </td>
        <td>
            <asp:DropDownList ID="ddlTipo" runat="server"/>
        </td>
        <td>
            <asp:CheckBox ID="chkEstadoAsignacion" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnAsignarUsuario" runat="server" CssClass="cssButton" 
                Text="Asignar" onclick="btnAsignarUsuario_Click" />
        </td>
    </tr>
    </table>

        <asp:gridview id="gvUsuario" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowDataBound="gvUsuario_RowDataBound" 
        DataKeyNames="IdProyecto, IdUsuario"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NombreUsuario" HeaderText="Nombre Usuario" ItemStyle-Width="400px" />
      
        <asp:TemplateField  HeaderText="Tipo">
            <ItemTemplate>
                   <asp:DropDownList id="ddlTipoGridView" runat="server"/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField  HeaderText="Estado">
            <ItemTemplate>
                      <asp:CheckBox ID="chkEstadoGridView" runat="server" Checked='<%# Eval("EstadoBool") %>' />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    </asp:gridview>

        <asp:Button ID="btnActualizarGridView" runat="server" Text="Actualizar" CssClass="cssButton"
            onclick="btnActualizarGridView_Click" />

    </asp:Panel>

</div>
</asp:Panel>

<asp:Panel ID="panLista" runat="server">
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" 
        onclick="btnNuevo_Click" />

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
        <asp:BoundField ReadOnly="True" DataField="IdProyecto" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Nombre del Proyecto" ItemStyle-Width="800px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreCorto" HeaderText="Nombre Corto" ItemStyle-Width="100px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"  ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"  />

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

</asp:Content>
