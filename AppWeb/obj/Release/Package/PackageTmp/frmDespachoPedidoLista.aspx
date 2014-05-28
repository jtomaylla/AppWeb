<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDespachoPedidoLista.aspx.cs" Inherits="AppWeb.frmDespachoPedidoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Despacho de Pedidos Internos</div>

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvPedidoLista_RowCommand" 
>
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdRecepcion" HeaderText="Recepcion" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Proveedor" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="FechaRecepcion" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="NumeroRecibo" HeaderText="Recibo" ItemStyle-Width="30px" />
        <asp:BoundField ReadOnly="True" DataField="IdOrdenCompra" HeaderText="O/C" ItemStyle-Width="30px" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                 <asp:Button ID="btnDespachar" runat="server" 
                    Text="Despachar Recepción"
                    CommandName="Despachar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdRecepcion") %>'                    
                    CssClass="cssButton"
                />

            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>


    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false" ></asp:TextBox>

</asp:Content>
