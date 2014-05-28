<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacionLinea.aspx.cs" Inherits="AppWeb.frmCotizacionLinea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Cotización <asp:Literal ID="litIdCotizacion" runat="server"></asp:Literal></div>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Cotización</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Solicitud de Compra</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Solicitud Por</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>Fecha Cotización</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Descripcion de Cotización</td>
    <td>:</td>
    <td><asp:TextBox ID="TextBox1" runat="server" Width="600px"></asp:TextBox></td>
</tr>
<tr>
    <td class="style1">Moneda</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>


</div>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLineas" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreCortoUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="350px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="50px"></asp:BoundField>
    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 


</div>

<div class="cssTablaCabeceraRegistro">Proveedores</div>
<div class="cssTablaRegistro">

<table>
<tr>
<td>
    Proveedor
</td>
<td>Cantidad</td>
<td></td>
</tr>
<tr>
<td>
    <asp:DropDownList ID="ddlProveedor" runat="server"></asp:DropDownList>
</td>
<td>
    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Button ID="btnAgregarProceedor" runat="server" Text="Agregar" />
</td>
</tr>
</table>

<asp:gridview id="gvProveedores" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
     
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="Ruc" HeaderText="RUC" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Razon Social" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="50px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    id="ImageButton1" 
                    CommandArgument = '<%# Bind("IdCotizacionLinea") %>'
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 



</div>
</asp:Content>
