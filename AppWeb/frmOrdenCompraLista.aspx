<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompraLista.aspx.cs" Inherits="AppWeb.frmOrdenCompraLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <script type="text/javascript">
     function js_imprimir_oc(id) {
         //JS_openWindow("frmOrdenCompraImpresion.aspx?id=" + id, "FormatoOC", "600", "300", "yes", "yes", "yes", "no", "no");
         JS_openWindow("OrdenCompra.aspx?id=" + id, "FormatoOC", "600", "300", "yes", "yes", "yes", "no", "no");
         return false;
     }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Resumen de Orden de Compra</div>

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvLista_RowCommand" 
        OnRowDataBound ="gvLista_RowDataBound"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdOrdenCompra" HeaderText="O/C" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreTipoOrdenCompra" HeaderText="Tipo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Proveedor" ItemStyle-Width="450px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaOrdenCompra" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionOrdenCompra" HeaderText="Descripción" ItemStyle-Width="300px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Mon" ItemStyle-Width="30px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="ImporteOrdenCompra" HeaderText="Importe"  DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreEstadoControl" HeaderText="Estado" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreEstadoAprobacion" HeaderText="EstadoAprob" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="EnviadoProveedor" HeaderText="EnvProv" ItemStyle-Width="50px"></asp:BoundField>


        <asp:TemplateField ShowHeader="True" HeaderText="">
            <ItemTemplate>
                <asp:Button ID="btnLineas" runat="server" Text="Ver O/C" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdOrdenCompra") %>'
                    CssClass="cssButton"/>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField ShowHeader="True" HeaderText="PDF">
            <ItemTemplate>
                <asp:Button ID="btnPDF" runat="server" Text="Impresión de O/C" 
                    CommandName="VerPDF" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdOrdenCompra") %>'
                    CssClass="cssButton"/>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>


</asp:Content>
