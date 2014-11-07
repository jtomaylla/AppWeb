<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecepcionServicio.aspx.cs" Inherits="AppWeb.frmRecepcionServicio" %>
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
            if (!JS_onError(frm, guiaRemision, "TEXT", "Ingrese número de documento"))
                return false;
        }

        if (!JS_hasValue(fechaRecepcion, "TEXT")) {
            if (!JS_onError(frm, fechaRecepcion, "TEXT", "Ingrese fecha de conformidad"))
                return false;
        }

        if (!JS_checkeurodate(fechaRecepcion.value)) {
            if (!JS_onError(frm, fechaRecepcion, "TEXT", "Ingrese fecha de conformidad valida (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(factura, "TEXT")) {
            if (!JS_onError(frm, factura, "TEXT", "Ingrese factura"))
                return false;
        }


        return confirm("Desea Ud. realizar al conformidad de servicio");
    }
    
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Confirmación de Atención de Servicio</div>

<div class="cssTablaCabeceraRegistro">Buscar Orden de Compra Servicio</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Número de Orden de Compra</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtNumOrdenCompra" runat="server"></asp:TextBox></td>
    <td>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="cssButton" 
            onclick="btnBuscar_Click" />
    </td>
</tr>
</table>

    <asp:Label ID="lblMensajeRecepcion" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

</div>

<asp:Panel ID="panRecepcion" runat="server">


<div class="cssTablaCabeceraRegistro">Datos de la Recepción de Servicio</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Documento</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtGuiaRemision" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <td>Fecha de Recepción/Conformidad</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaRecepcion" runat="server"></asp:TextBox>

        <script language="javascript" type="text/javascript">
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
                <asp:CheckBox ID="chkSeleccion" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DescripciónLinea" ItemStyle-Width="250px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

        <asp:Button ID="btnRecepcionar" runat="server" Text="Atención" 
        CssClass="cssButton" onclick="btnRecepcionar_Click" 
          />
          <br />
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

</div>

</asp:Panel>


<asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdOrdenCompra" Visible="false" runat="server"></asp:TextBox>

</asp:Content>
