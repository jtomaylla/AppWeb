<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedidoLineaAprobacionLogistica.aspx.cs" Inherits="AppWeb.frmPedidoLineaAprobacionLogistica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" language="javascript">
    function js_codigo_presupuesto() {
        var IdPedido = document.getElementById("<%= txtIdPedido.ClientID%>");
        window.open("frmPedidoCodigoPresupuesto.aspx?id=" + IdPedido.value + "&accion=consulta", "ventana1", "width=600,height=300,scrollbars=1")
        return false;
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Solicitud de Pedido de Compra</div>

<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssError"></asp:Label>

<div class="cssTablaCabeceraRegistro">Registro</div>
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
    <td>Código Presupuesto</td>
    <td>:</td>
    <td>
        <asp:Button ID="btnCodigoPresupuesto" runat="server" Text="Codigos Presupuesto..." CssClass="cssButton" />
        <asp:Label ID="lblCodigoPresupuesto" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Descripción del Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblDescripcionPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Moneda</td>
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

</table>

</div>

<asp:Panel ID="panPedidoDetalleLineas" runat="server">

<div class="cssTablaCabeceraRegistro">Linea de Pedido de Compra</div>
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
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UnidadMedida" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PrecioReferencial" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview> 

</div>
</asp:Panel>

<br />

<asp:Button ID="btnEnviarAprobar" runat="server" Text="Aprobar"  CssClass="cssButton" onclick="btnEnviarAprobar_Click"  />

<asp:Button ID="btnRechazar" runat="server" Text="Rechazar" CssClass="cssButton" onclick="btnRechazar_Click" />

<asp:Button ID="btnListaPedidos" runat="server" 
    Text="Resumen de Pedidos de Compra"  CssClass="cssButton" 
    onclick="btnListaPedidos_Click"  />


<asp:TextBox ID="txtIdPedidoDetalle" runat="server" Visible="false"></asp:TextBox>   
<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>

</asp:Content>
