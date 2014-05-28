<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIGV.aspx.cs" Inherits="AppWeb.frmIGV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language=javascript src="Scripts/popcalendar.js"></script>

<script type="text/javascript">

    function js_validar() {

        var frm = document.getElementById("formmain");
        var igv = document.getElementById("<%= txtIGV.ClientID%>");
        var descripcion = document.getElementById("<%= txtDescripcion.ClientID%>");
        var fechaInicial = document.getElementById("<%= txtFechaInicial.ClientID%>");
        
        if (!JS_hasValue(igv, "TEXT")) {
            if (!JS_onError(frm, igv, "TEXT", "Ingrese IGV"))
                return false;
        }

        if (!JS_hasValue(descripcion, "TEXT")) {
            if (!JS_onError(frm, descripcion, "TEXT", "Ingrese descripción"))
                return false;
        }

        if (!JS_hasValue(fechaInicial, "TEXT")) {
            if (!JS_onError(frm, fechaInicial, "TEXT", "Ingrese fecha inicial"))
                return false;
        }
        
        return true;
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Mantenimiento de IGV</div>

<asp:Panel ID="panRegistro" runat="server">

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
      <table >
        <tr>
            <td>Id</td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtId" runat="server" Width="40px"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                IGV</td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtIGV" runat="server" Width="50px"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                Descripción</td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtDescripcion" runat="server" Width="200px" MaxLength="100"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                Fecha Inicial</td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtFechaInicial" runat="server" Width="100px" MaxLength="10"></asp:TextBox>        
                <script language="javascript">
		        <!--
                    if (!document.layers) {
                        document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaInicial, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                    }
		        //-->
		        </script>
                        
            </td>
        </tr>
        <tr>
            <td>
                Fecha Final</td>
            <td>
                :
            </td>
            <td>
				<asp:TextBox ID="txtFechaFinal" runat="server" Width="100px" MaxLength="10"></asp:TextBox>                
                <script language="javascript">
		        <!--
                    if (!document.layers) {
                        document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaFinal, \"dd/mm/yyyy\")'  name='select2' value='...' style='font-size:11px'>")
                    }
		        //-->
		        </script>

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
        OnRowCommand="gvLista_RowCommand"  
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdRegistro" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="IGV" HeaderText="IGV" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaInicio" HeaderText="Fecha Inicial" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="FechaFin" HeaderText="Fecha Final" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdRegistro") %>'
                    id="ImageButton1" ToolTip="Editar" 
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:gridview> 

</asp:Panel>


</asp:Content>
