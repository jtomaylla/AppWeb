<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDespachoPedidoInternoLista.aspx.cs" Inherits="AppWeb.frmDespachoPedidoInternoLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Despacho de Pedidos Internos</div>

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
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreTipoPedido" HeaderText="Tipo" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSolicitante" HeaderText="Solicitante" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Mon" ItemStyle-Width="30px" />
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="450px" />
        <asp:BoundField ReadOnly="True" DataField="FechaPedido" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="200px" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                 <asp:Button ID="btnSeleccionar" runat="server" 
                    Text="Ver Pedido"
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdPedido") %>'                    
                    CssClass="cssButton"
                />

            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>


    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false" ></asp:TextBox>

</asp:Content>
