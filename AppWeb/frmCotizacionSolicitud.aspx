﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacionSolicitud.aspx.cs" Inherits="AppWeb.frmCotizacionSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Pedido de Compra</div>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Número de Pedido</td>
    <td>:</td>
    <td><asp:Label ID="lblIdPedido" runat="server" Text=""></asp:Label></td>
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
        <asp:Label ID="lblCodigoPresupuesto" runat="server" Text=""></asp:Label>
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
        DataKeyNames="IdPedidoDetalle"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PrecioReferencial" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkpedido" runat="server" Text="" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview> 

</div>

</asp:Panel>

<br />

<asp:Button ID="btnCotizar" runat="server" 
    Text="Iniciar Cotización" 
    CssClass="cssButton" 
    onclick="btnCotizar_Click" />

<asp:TextBox ID="txtIdPedido" runat="server" Visible="false" ></asp:TextBox>
<asp:TextBox ID="txtIdPedidoDetalle" runat="server" Visible="false"></asp:TextBox>   
<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>

</asp:Content>
