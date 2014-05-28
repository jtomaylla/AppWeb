<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacionEnProceso.aspx.cs" Inherits="AppWeb.frmCotizacionEnProceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Cotizaciones en Proceso</div>

<asp:gridview id="gvCotizaciones" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvCotizaciones_RowCommand" 

>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdCotizacion" HeaderText="Cotización" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaCotizacion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionCotizacion" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Mon" ItemStyle-Width="30px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="60px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreUsuarioSolicitante" HeaderText="Solicitante" ItemStyle-Width="200px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerCotizacion" runat="server" Text="Ver Cotización" CssClass="cssButton" 
                    CausesValidation="False" 
                    CommandName="Seleccionar" 
                    CommandArgument = '<%# Bind("IdCotizacion") %>'
                />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 

<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtIdCotizacion" runat="server" Visible="false"></asp:TextBox>

</asp:Content>
