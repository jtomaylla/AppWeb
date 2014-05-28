<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOrdenCompraImpresion.aspx.cs" Inherits="AppWeb.frmOrdenCompraImpresion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style type="text/css">

body   
{
    font-size: .80em;
    font-family: "Arial, Helvetica Neue", "Lucida Grande", "Segoe UI", Helvetica, Verdana, sans-serif;
    margin: 0px;
    padding: 10px;
    font-size:9pt; 
}

.cssTitulo1 {
    font-size:14pt; 
    FONT-WEIGHT: bold;
}

.cssTitulo2 {
    font-size:12pt; 
    FONT-WEIGHT: bold;
}

.gridview 
{
    width: 100%; 
    margin: 5px 0 10px 0; 
    border: solid 1px #c1c1c1; 
    border-collapse:collapse; 
    font-size:9pt; 
}
.gridview td 
{ 
    padding: 2px; 
    border: solid 1px #c1c1c1; 
    color: #000000;
    font-size:9pt;  
}
.gridview th 
{ 
    height:19px;
    border:solid 1px #99BBE8;
    font-weight:normal;
    font-size:9pt; 

}

</style>


</head>

<body>

    <form id="form1" runat="server">
    <div>


<table width="100%">
<tr>
    <td align="center" class="cssTitulo1">
        <asp:Label ID="lblTitulo1" runat="server"></asp:Label> 
    </td>
</tr>
<tr>
    <td align="center" class="cssTitulo2">
        <asp:Label ID="lblTitulo2" runat="server"></asp:Label> 
    </td>
</tr>
</table>

<hr style="color: #c1c1c1; height: 1px;">

<table width="100%">
<tr>
<td style="width:100px">RAZON SOCIAL</td>
<td style="width:10px">:</td>
<td>
    <asp:Label ID="lblRazonSocial" runat="server" Text=""></asp:Label></td>
</tr>

<tr>
<td>RUC</td>
<td>:</td>
<td>
    <asp:Label ID="lblRuc" runat="server" Text=""></asp:Label></td>
</tr>

<tr>
<td>DIRECCION</td>
<td>:</td>
<td>
    <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
<td>CONTACTO</td>
<td>:</td>
<td>
    <asp:Label ID="lblContacto" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
<td>TELEFONO</td>
<td>:</td>
<td>
    <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label></td>
</tr>

</table>

<hr style="color: #c1c1c1; height: 1px;">


    <asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        ShowFooter="True" 
        onrowdatabound="gvLista_RowDataBound"
        CssClass="gridview" 
        
>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="LINEA" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="ARTICULO" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DESCRIPCION"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="CANTIDAD" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" >
            <ItemStyle HorizontalAlign="Right"  />
        </asp:BoundField>
        <asp:TemplateField HeaderText="PRECIO" ItemStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblPrecio" runat="server" Text="Label"></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <span>SUB TOTAL</span><br />
                <span>IGV</span><br />
                <span>TOTAL</span>
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Right"  />
            <FooterStyle  HorizontalAlign = "Right"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IMPORTE" ItemStyle-Width="120px">
            <ItemTemplate>
                <asp:Label ID="lblImporte" runat="server" Text="Label"></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="lblSubtotal" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblIGV" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Right" />
            <FooterStyle  HorizontalAlign = "Right"/>
        </asp:TemplateField>
    </Columns>
    </asp:gridview>

<hr style="color: #c1c1c1; height: 1px;">
    
</div>
    </form>
</body>
</html>
