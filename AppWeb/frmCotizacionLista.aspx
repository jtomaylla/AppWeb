<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacionLista.aspx.cs" Inherits="AppWeb.frmCotizacionLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Cotizacion</div>

Seleccione solicitud de pedido a cotizar.

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
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Num" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="450px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaPedido" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="200px"></asp:BoundField>

        <asp:TemplateField ShowHeader="True" HeaderText="S.C">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    id="ImageButton1" 
                    CommandArgument = '<%# Bind("IdPedido") %>'
                    imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>


</asp:Content>
