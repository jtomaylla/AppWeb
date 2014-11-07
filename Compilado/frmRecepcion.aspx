<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecepcion.aspx.cs" Inherits="AppWeb.frmRecepcion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language=javascript src="Scripts/popcalendar.js"></script>

<script type="text/javascript">

    function js_validar_buscar() {
        var frm = document.getElementById("formmain");
        var numOrdenCompra = document.getElementById("<%= txtNumOrdenCompra.ClientID%>");

        if (!JS_hasValue(numOrdenCompra, "TEXT")) {
            if (!JS_onError(frm, numOrdenCompra, "TEXT", "Ingrese Número de Orden de Compra"))
                return false;
        }

        if (!JS_checkinteger(numOrdenCompra.value)) {
            if (!JS_onError(frm, numOrdenCompra, "TEXT", "Ingrese Número de Orden de Compra valido"))
                return false;
        }

        return true;        

    }
    
    function js_validar() {

        var frm = document.getElementById("formmain");
        var guiaRemision = document.getElementById("<%= txtGuiaRemision.ClientID%>");
        var fechaRecepcion = document.getElementById("<%= txtFechaRecepcion.ClientID%>");
        var factura = document.getElementById("<%= txtNumeroFactura.ClientID%>");

        
        if (!JS_hasValue(guiaRemision, "TEXT")) {
            if (!JS_onError(frm, guiaRemision, "TEXT", "Ingrese Guia de Remisión"))
                return false;
        }

        if (!JS_hasValue(fechaRecepcion, "TEXT")) {
            if (!JS_onError(frm, fechaRecepcion, "TEXT", "Ingrese Fecha Remisión"))
                return false;
        }

        if (!JS_checkeurodate(fechaRecepcion.value)) {
            if (!JS_onError(frm, fechaRecepcion, "TEXT", "Ingrese Fecha Remisión valida (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(factura, "TEXT")) {
            if (!JS_onError(frm, factura, "TEXT", "Ingrese Factura"))
                return false;
        }

        return confirm("Desea Ud. realizar la recepción");

        return true;
    }

</script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="cssTituloPagina">Recepción de Orden de Compra</div>


<div class="cssTablaCabeceraRegistro">Buscar Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Número Orden de Compra</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtNumOrdenCompra" runat="server" Enabled="False"></asp:TextBox></td>
    <td>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="cssButton" 
            onclick="btnBuscar_Click" />
    </td>
</tr>
</table>

    <asp:Label ID="lblMensajeRecepcion" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

</div>
<div>
    <asp:GridView ID="gvlistaprevia" runat="server" AutoGenerateColumns="False" CssClass="gridview" PagerStyle-CssClass="gridview_pager" AlternatingRowStyle-CssClass="gridview_alter">
        <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:RadioButton ID="rbOcompra" runat="server" GroupName="seleccion" AutoPostBack="true" Checked="false" OnCheckedChanged="chkSeleccion1_CheckedChanged"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ReadOnly="True" DataField="IdOrdenCompra" HeaderText="O/C" ItemStyle-Width="80px">
                <ItemStyle Width="80px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="NombreTipoOrdenCompra" HeaderText="Tipo" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px">
                <ItemStyle Width="350px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Proveedor" ItemStyle-Width="450px">
                <ItemStyle Width="450px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="FechaOrdenCompra" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px">
                <ItemStyle Width="80px"></ItemStyle>
            </asp:BoundField>            
            <asp:BoundField ReadOnly="True" DataField="NombreEstadoControl" HeaderText="Estado" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Recepcionadoitems" HeaderText="Recepcionado" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Totalitems" HeaderText="TotalItems" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField ReadOnly="true"  DataField="faltante" HeaderText="Pendiente" ItemStyle-Width="80px">
            <ItemStyle ForeColor="Red" Width="80px" />
            </asp:BoundField>

        </Columns>

        <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:GridView>
</div>

<asp:Panel ID="panRecepcion" runat="server">


<div class="cssTablaCabeceraRegistro">Datos de la Recepción</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Guia de Remisión</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtGuiaRemision" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Fecha de Remisión</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaRecepcion" runat="server"></asp:TextBox>

        <script language="javascript">
		<!--
            if (!document.layers) {
                document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaRecepcion, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
            }
		//-->
		</script>
        
    </td>
</tr>

<tr>
    <td>Número de Factura</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtNumeroFactura" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Observaciones</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtObservaciones" runat="server" Width="500px"></asp:TextBox></td>
</tr>
</table>

</div>

<div class="cssTablaCabeceraRegistro">Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Número de Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblIdOrdenCompra" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Tipo de Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblTipoOrdenCompra" runat="server" Text=""></asp:Label></td>
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
</table>

</div>

<div class="cssTablaCabeceraRegistro">Lineas Orden de Compra</div>
<div class="cssTablaRegistro">

        <asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter" 
        DataKeyNames = "IdOrdenCompraLinea"
        
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:CheckBox ID="chkSeleccion" runat="server" AutoPostBack="true"  />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DescripciónLinea" ItemStyle-Width="250px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CantidadRecibida" HeaderText="CantRecibida" ItemStyle-Width="120px"></asp:BoundField>
        <asp:TemplateField ShowHeader="True" HeaderText="CantRecibo">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidadRecepcion" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

        <asp:Button ID="btnRecepcionar" runat="server" Text="Recepcionar" 
        CssClass="cssButton" onclick="btnRecepcionar_Click" 
          />
          <br />
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

</div>

</asp:Panel>


<asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdOrdenCompra" Visible="false" runat="server"></asp:TextBox>

</asp:Content>
