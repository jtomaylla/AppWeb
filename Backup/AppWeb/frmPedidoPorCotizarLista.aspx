<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedidoPorCotizarLista.aspx.cs" Inherits="AppWeb.frmPedidoPorCotizarLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Pedidos de Compra por Cotizar</div>

Seleccione pedido a cotizar.

<asp:gridview id="gvPedidoLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvPedidoLista_RowCommand" 
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="100px" />
        <asp:BoundField ReadOnly="True" DataField="NombreTipoPedido" HeaderText="TipoPedido" ItemStyle-Width="100px" />
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSolicitante" HeaderText="Solicitante" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Mon" ItemStyle-Width="20px" />
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="450px" />
        <asp:BoundField ReadOnly="True" DataField="FechaPedido" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstadoControl" HeaderText="EstadoControl" ItemStyle-Width="200px" />
        <asp:TemplateField ShowHeader="True" HeaderText="S.C">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Cotizar" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CssClass="cssButton"
                    CommandArgument = '<%# Bind("IdPedido") %>'
                />

            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>



</asp:Content>
