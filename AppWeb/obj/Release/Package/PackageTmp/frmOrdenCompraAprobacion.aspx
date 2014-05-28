<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompraAprobacion.aspx.cs" Inherits="AppWeb.frmOrdenCompraAprobacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language="javascript" type="text/javascript" src="Scripts/popcalendar.js"></script>

<script type="text/javascript" language="javascript">
      function js_validar_aprobar() {
         var frm = document.getElementById("formmain");
         return confirm('Desea Ud. Aprobar la Orden de Compra');
     }
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Aprobar Orden de Compra</div>

 <asp:Label ID="lblError" runat="server" Text="" CssClass="cssError"></asp:Label>

<div class="cssTablaCabeceraRegistro">Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Id Orden Compra</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtIdOrdenCompra" Visible="true" Width="80"  ReadOnly="true" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Tipo Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblTipoOrdenCompra" runat="server" Text=""></asp:Label></td>
</tr>

<tr>
    <td>Nombre Proyecto</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreProyecto" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Nombre Sede</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreSede" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Proveedor</td>
    <td>:</td>
    <td><asp:Label ID="lblRazonSocial" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Fecha Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblFechaOrdenCompra" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Moneda</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreMoneda" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Importe</td>
    <td>:</td>
    <td><asp:Label ID="lblImporte" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td><asp:Label ID="lblEstadoAprobacion" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Descripción</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblDescripcionOC" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Fecha Entrega</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaEntrega" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Forma de Pago</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFormaPago" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>Afecto al IGV</td>
    <td>:</td>
    <td>
        <asp:CheckBox ID="chkIGV" runat="server" Enabled="false" />
    </td>
</tr>

</table>

</div>
<div class="cssTablaCabeceraRegistro">Lineas Orden de Compra</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DescripciónLinea" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="PrecioUnitario" DataFormatString="{0:N5}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

    <asp:Button ID="btnAprobar" runat="server" Text="Aprobar" CssClass="cssButton" 
        onclick="btnAprobar_Click" />

</div>


</asp:Content>
