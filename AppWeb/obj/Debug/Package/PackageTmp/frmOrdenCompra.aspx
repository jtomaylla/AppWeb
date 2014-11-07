<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompra.aspx.cs" Inherits="AppWeb.frmOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    .ocultar {display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
<div class="cssTituloPagina">Orden de Compra</div>

<div class="cssTablaCabeceraRegistro">Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Id Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblIdOrdenCompra" runat="server" Text=""></asp:Label></td>
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
    <td>Incluye IGV</td>
    <td>:</td>
    <td><asp:Label ID="lblflagigv" runat="server" Text=""></asp:Label></td>
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
<tr>
    <td colspan="3">
        &nbsp;
    </td>
</tr>
<tr>
    <td colspan="3">
        <asp:LinkButton ID="lnkanular" runat="server" onclick="lnkanular_Click" >Quiero anular la orden de compra</asp:LinkButton>
    </td>
</tr>
<tr>
    <td colspan="3">
    <asp:UpdatePanel ID="updanular" runat="server" >
    <ContentTemplate>
    <asp:Panel ID="pnlanular" runat="server" Visible="false">
        <table>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td valign="top">Indique motivo de anulacion</td>
                <td valign="top">:</td>
                <td><asp:TextBox ID="txtanular" runat="server" TextMode="MultiLine" Height="50px" Width="350px" MaxLength="500" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnanular" runat="server" Text="Anular" 
                        onclick="btnanular_Click"  />                 
                </td>
            </tr>
        </table>
        </asp:Panel>
    </ContentTemplate>
     
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkanular" EventName="Click" />
        </Triggers>
     
    </asp:UpdatePanel>
    </td>
</tr>
<tr>
    <td colspan="3">
        <asp:LinkButton ID="lnkdescartar" runat="server" onclick="lnkdescartar_Click">Quiero descartar esta orden de compra</asp:LinkButton>
    </td>
</tr>
<tr>
    <td colspan="3">
        <asp:UpdatePanel ID="upddescartar" runat="server" >
    <ContentTemplate>
    <asp:Panel ID="pan_descarte" runat="server" Visible="false">
        <table>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td valign="top">Indique motivo de descarte</td>
                <td valign="top">:</td>
                <td><asp:TextBox ID="txtdescarte" runat="server" TextMode="MultiLine" Height="50px" Width="350px" MaxLength="500" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btndescartar" runat="server" Text="Descartar" onclick="btndescartar_Click" 
                          />                 
                </td>
            </tr>
        </table>
        </asp:Panel>
    </ContentTemplate>
     
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkdescartar" EventName="Click" />
        </Triggers>
     
    </asp:UpdatePanel>
    </td>
</tr>


</table>

<div class="cssTablaCabeceraRegistro">Lineas Orden de Compra</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter" 
        DataKeyNames="IdOrdenCompraLinea" onrowcommand="gvLista_RowCommand"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="50px">
<ItemStyle Width="50px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px">
<ItemStyle Width="50px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DescripciónLinea" ItemStyle-Width="400px">
<ItemStyle Width="400px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="PrecioUnitario" DataFormatString="{0:N5}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="SubTotal" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btneditarPU" runat="server" Text="Editar PU." CssClass="cssButton" CausesValidation="false" CommandName="Editar" CommandArgument='<%# Bind("IdOrdenCompraLinea") %>'
                 Width="80px" />
            </ItemTemplate>
            <HeaderStyle CssClass="ocultar" />
            <ItemStyle CssClass="ocultar" />
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
</div>
<asp:Panel ID="pnleditar" runat="server" Visible="false">
    <table>
        <tr>
            <td>Precio Unitario</td>
            <td>:</td>
            <td><asp:TextBox ID="txteditar" runat="server" Width="80px"></asp:TextBox></td>
            <td><asp:Button ID="btneditar" runat="server" Text="Cambiar" CssClass="cssButton" 
                    onclick="btneditar_Click" /></td>
        </tr>
    </table>
</asp:Panel>

<asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdOrdenCompra" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdLinOrdenCompra" Visible="false" runat="server"></asp:TextBox>

</asp:Content>
