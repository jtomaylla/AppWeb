<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompraLineaEnvioProveedor.aspx.cs" Inherits="AppWeb.frmOrdenCompraLineaEnvioProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Envio al Proveedor</div>

<div class="cssTablaCabeceraRegistro">Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Id Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblIdOrdenCompra" runat="server" Text=""></asp:Label></td>
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
    <td>Forma Pago</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFormaPago" runat="server" Text=""></asp:Label>
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


</div>
<br />
<div class="cssTablaCabeceraRegistro">Enviar Orden de Compra</div>
<div class="cssTablaRegistro">

    Comentarios:<br />
    <asp:TextBox ID="txtComentarios" runat="server" MaxLength="150" Rows="4" 
        TextMode="MultiLine" Width="545px"></asp:TextBox>
    <br />
    Direccion de Envio:<br />
    <asp:DropDownList ID="ddlDireccion" runat="server" Width="360px"></asp:DropDownList>
    <br />
    <asp:Button ID="btnAprobar" runat="server" Text="Registrar envío de O/C" CssClass="cssButton" 
        onclick="btnAprobar_Click" />

</div>

<asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdOrdenCompra" Visible="false" runat="server"></asp:TextBox>


</asp:Content>
