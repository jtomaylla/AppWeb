<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDespachoPedidoInterno.aspx.cs" Inherits="AppWeb.frmDespachoPedidoInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language=javascript src="Scripts/popcalendar.js"></script>

<script type="text/javascript">

    function js_validar() {
        var frm = document.getElementById("formmain");


        //---

        return confirm('Deseas Ud. realizar el despacho?');

    }

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Despacho de Perdido Interno</div>

<div><asp:Label ID="lblmensaje" runat="server"  Text="" CssClass="cssError"></asp:Label></div>
<div class="cssTablaCabeceraRegistro">Pedido</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Número de Pedido</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtIdPedido" runat="server" ReadOnly="true" Width="80px" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Tipo de Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblTipoPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Fecha de Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Proyecto</td>
    <td>:</td>
    <td><asp:Label ID="lblProyecto" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Sede</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblSede" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Solicitante</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreSolicitante" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Descripción del Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblDescripcionPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
</tr>

</table>

</div>

<asp:Panel ID="panPedidoDetalleLineas" runat="server">

<div class="cssTablaCabeceraRegistro">Lineas del Pedido</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvPedidoLinea" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter" 
        DataKeyNames = "IdPedidoDetalle"
        onselectedindexchanged="gvPedidoLinea_SelectedIndexChanged"
       
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:CheckBox ID="chkSeleccion" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UnidadMedida" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField ShowHeader="True" HeaderText="CantDespacho">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidadDespacho" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

    <asp:Button ID="btnDespacho" runat="server" Text="Despachar" 
        CssClass="cssButton" onclick="btnDespacho_Click" Visible="true" />

    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"   
        CssClass="cssButton" onclick="btnCancelar_Click"  />

</div>
</asp:Panel>




<br />


<asp:TextBox ID="txtIdPedidoDetalle" runat="server" Visible="false"></asp:TextBox>   
<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>

<br />

<asp:Label ID="lblIdPedido" runat="server" Text=""  ></asp:Label>
<asp:Label ID="lblIdDespacho" runat="server" Text=""></asp:Label>
<asp:Label ID="lblIdGuiaRemision" runat="server" Text=""></asp:Label>


</asp:Content>
