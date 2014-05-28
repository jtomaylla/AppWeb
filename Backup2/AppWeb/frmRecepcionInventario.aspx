<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecepcionInventario.aspx.cs" Inherits="AppWeb.frmRecepcionInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Recepciones pendientes de ingreso en Inventario</div>

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand = "gvLista_RowCommand"

>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdRecepcion" HeaderText="Recepcion" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="FechaRecepcion" HeaderText="Fch Recibo" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="100px" />
        <asp:BoundField ReadOnly="True" DataField="IdOrdenCompra" HeaderText="O/C" ItemStyle-Width="50px" />
        <asp:BoundField ReadOnly="True" DataField="NumeroLineaOC" HeaderText="Linea O/C" ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px" />
        <asp:BoundField ReadOnly="True" DataField="NombreArticulo" HeaderText="Nombre Articulo" ItemStyle-Width="450px" />
        <asp:BoundField ReadOnly="True" DataField="CantidadRecepcionada" HeaderText="Cant Recibo" ItemStyle-Width="100px" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                 <asp:Button ID="btnSeleccionar" runat="server" 
                    Text="Ingreso a Inventario"
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdRecepcionLinea") %>'                    
                    CssClass="cssButton"
                />

            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false" ></asp:TextBox>


</asp:Content>
