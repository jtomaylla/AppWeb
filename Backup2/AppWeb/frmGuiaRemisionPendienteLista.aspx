<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGuiaRemisionPendienteLista.aspx.cs" Inherits="AppWeb.frmGuiaRemisionPendienteLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Guias pendientes de Emitir</div>

<asp:gridview id="gvLista" runat="server" 
            autogeneratecolumns="False" 
            OnRowCommand="gvLista_RowCommand"
            CssClass="gridview"
            PagerStyle-CssClass="gridview_pager" 
            AlternatingRowStyle-CssClass="gridview_alter"
        >
        <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
        <PagerStyle CssClass="gridview_pager"></PagerStyle>
        <Columns>
            <asp:BoundField ReadOnly="True" DataField="IdDespacho" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="TipoOrigen" HeaderText="TipoOrigen" ItemStyle-Width="100px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="IdOrigen" HeaderText="Id Origen" ItemStyle-Width="100px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="FechaDespacho" HeaderText="Fecha" ItemStyle-Width="200px"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnGuia" 
                        runat="server" 
                        Text="Guia" 
                        CommandName="Seleccionar" 
                        CausesValidation="False" 
                        CommandArgument = '<%# Bind("IdDespacho") %>'
                        CssClass="cssButton" />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:gridview>

</asp:Content>
