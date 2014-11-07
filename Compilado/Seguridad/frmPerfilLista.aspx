<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPerfilLista.aspx.cs" Inherits="AppWeb.Seguridad.frmPerfilLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var perfil = document.getElementById("<%= txtNombrePerfil.ClientID%>");
        if (!JS_hasValue(perfil, "TEXT")) {
            if (!JS_onError(frm, perfil, "TEXT", "Ingrese nombre de perfil"))
                return false;
        }
        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Mantenimiento de  Perfiles</div>

<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>


<asp:Panel ID="panLista" runat="server">
    <div class="cssTablaCabeceraRegistro">Perfiles</div>
    <div class="cssTablaRegistro">
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />

    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnSelectedIndexChanged="gvLista_SelectedIndexChanged"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"

     >
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdPerfil" HeaderText="Id"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombrePerfil" HeaderText="Nombre Perfil"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" CommandName="Select" CausesValidation="False" 
                    id="ImageButton1" 
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:gridview> 
    </div>
</asp:Panel>

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
				<asp:TextBox ID="txtIdPerfil" runat="server" Width="40px"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                Nombre Perfil
            </td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtNombrePerfil" runat="server" Width="200px"></asp:TextBox>                
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
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="cssButton"  onclick="btnEliminar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="cssButton" 
            onclick="btnCancelar_Click" />
    </div>
</asp:Panel>

<asp:Panel ID="panFunciones" runat="server">
    <div class="cssTablaCabeceraRegistro">Funciones</div>
    <div class="cssTablaRegistro">

  <table>
  <tr>
    <td valign="top" style="width:400px">
    
        <asp:TreeView ID="tvwFunciones" runat="server" imageset="Arrows" ShowCheckBoxes="All">
        </asp:TreeView>

        <asp:Button ID="btnGrabarFuncion" runat="server" Text="Grabar Funciones" 
            CssClass="cssButton" onclick="btnGrabarFuncion_Click" />

    </td>
    <td valign="top">
    
           
    <asp:gridview id="gvListaFuncion" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        OnRowDataBound="gvListaFuncion_OnRowDataBound" 
        AlternatingRowStyle-CssClass="gridview_alter"
        DataKeyNames = "IdFuncion"
     >
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdFuncion" HeaderText="Id">
            <ItemStyle Width="50px" />
        </asp:BoundField>
        <asp:TemplateField ShowHeader="true" HeaderText="Orden">
            <ItemTemplate>
                <asp:TextBox ID="txtOrden" runat="server" Width="50px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="NombreFuncion" HeaderText="Nombre Función">
            <ItemStyle Width="350px" />
        </asp:BoundField>

    </Columns>
    </asp:gridview> 
    
    <asp:Button ID="btnActualizarListaFuncion" runat="server" Text="Actualizar" 
            CssClass="cssButton" onclick="btnActualizarListaFuncion_Click" />

        </td>
  </tr>
  </table>

    </div>
</asp:Panel>

</asp:Content>
