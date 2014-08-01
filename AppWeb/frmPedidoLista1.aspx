<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedidoLista1.aspx.cs" Inherits="AppWeb.frmPedidoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Solicitud de Pedido de Compra</div>

<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Pedido" CssClass="cssButton" 
        onclick="btnNuevo_Click"  />

<asp:gridview id="gvPedidoLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvPedidoLista_RowCommand"  
        PageSize="10" 
        AllowPaging="true" 
        OnPageIndexChanging="gvPedidoLista_PageIndexChanging"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreTipoPedido" HeaderText="Tipo" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSolicitante" HeaderText="Solicitante" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Moneda" ItemStyle-Width="20px" />
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="450px" />
        <asp:BoundField ReadOnly="True" DataField="FechaPedido" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="FechaAprobacionTexto" HeaderText="FechaAprob" ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstadoControl" HeaderText="EstadoControl" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="OrdenCompra" HeaderText="O/C" ItemStyle-Width="50px" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerPedido" runat="server" Text="Ver Pedido" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdPedido") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
     <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
    
</asp:Content>
