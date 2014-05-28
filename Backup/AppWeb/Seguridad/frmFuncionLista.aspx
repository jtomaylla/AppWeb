<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFuncionLista.aspx.cs" Inherits="AppWeb.Seguridad.frmFuncionLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var nombre = document.getElementById("<%= txtNombre.ClientID%>");
        if (!JS_hasValue(nombre, "TEXT")) {
            if (!JS_onError(frm, nombre, "TEXT", "Ingrese nombre de función"))
                return false;
        }
        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="cssTituloPagina">Funciones</div>

<asp:Panel ID="panRegistro" runat="server">

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
      <table >
        <tr>
            <td>
                Id
            </td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtId" runat="server" Width="40px"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                Nombre Función
            </td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                Función
            </td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtFuncion" runat="server" Width="400px"></asp:TextBox>                
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

    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" onclick="btnEliminar_Click" />

    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="cssButton" onclick="btnCancelar_Click" />

</div>

</asp:Panel>

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

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
        <asp:BoundField ReadOnly="True" DataField="IdFuncion" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreFuncion" HeaderText="Nombre Función" ItemStyle-Width="250px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Funcion" HeaderText="Función" ItemStyle-Width="400px"></asp:BoundField>
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

</asp:Content>
