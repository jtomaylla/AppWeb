<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedidoConsulta.aspx.cs" Inherits="AppWeb.frmPedidoConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" language="javascript">
    function js_codigo_presupuesto() {
        var IdPedido = document.getElementById("<%= txtIdPedido.ClientID%>");
        window.open("frmPedidoCodigoPresupuesto.aspx?id="+IdPedido.value+"&accion=consulta" , "ventana1", "width=600,height=300,scrollbars=1") 
        return false;
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Pedido</div>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Número de Pedido</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtIdPedido" runat="server" Width="50" ReadOnly="true"></asp:TextBox>
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
    <td>Tipo</td>
    <td>:</td>
    <td><asp:Label ID="lblTipoPedido" runat="server" Text=""></asp:Label></td>
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
    <td>Solicitud Por</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblNombreSolicitante" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Código Presupuesto</td>
    <td>:</td>
    <td>
        <asp:Button ID="btnCodigoPresupuesto" runat="server" Text="Codigos Presupuesto..." CssClass="cssButton" />
    </td>
</tr>
<tr>
    <td>Descripcion del Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblDescripcionPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td class="style1">Moneda</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblMoneda" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Estado de control</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstadoControl" runat="server" Text=""></asp:Label></td>
</tr>

</table>
</div>


<asp:Panel ID="panPedidoDetalleLineas" runat="server">

<div class="cssTablaCabeceraRegistro">Lineas de Pedido</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvPedidoLinea" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
       
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PrecioReferencial" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview> 

</div>

</asp:Panel>

<br />


</asp:Content>
