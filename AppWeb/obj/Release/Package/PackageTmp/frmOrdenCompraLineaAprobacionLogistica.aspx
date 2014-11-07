<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenCompraLineaAprobacionLogistica.aspx.cs" Inherits="AppWeb.frmOrdenCompraLineaAprobacionLogistica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript" language="javascript" src="Scripts/popcalendar.js"></script>

 <script type="text/javascript" language="javascript">

    function js_validar() {
        var frm = document.getElementById("formmain");
        var txtFechaEntrega = document.getElementById("<%= txtFechaEntrega.ClientID%>");
        var ddlFormaPago = document.getElementById("<%= ddlFormaPago.ClientID%>");


        if (!JS_hasValue(txtFechaEntrega, "TEXT")) {
            if (!JS_onError(frm, txtFechaEntrega, "TEXT", "Ingrese fecha de entrega"))
                return false;
        }

        if (!JS_checkeurodate(txtFechaEntrega.value, "DD/MM/YYYY"))  {
            if (!JS_onError(frm, txtFechaEntrega, "TEXT", "Ingrese fecha de entrega valida (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(ddlFormaPago, "SELECT")) {
            if (!JS_onError(frm, ddlFormaPago, "SELECT", "Seleccione forma de pago"))
                return false;
        }

        return true;
    }

    function js_validar_aprobar() {
        var frm = document.getElementById("formmain");
        var txtFechaEntrega = document.getElementById("<%= txtFechaEntrega.ClientID%>");
        var ddlFormaPago = document.getElementById("<%= ddlFormaPago.ClientID%>");


        if (!JS_hasValue(txtFechaEntrega, "TEXT")) {
            if (!JS_onError(frm, txtFechaEntrega, "TEXT", "Ingrese fecha de entrega"))
                return false;
        }

        if (!JS_checkeurodate(txtFechaEntrega.value, "DD/MM/YYYY")) {
            if (!JS_onError(frm, txtFechaEntrega, "TEXT", "Ingrese fecha de entrega valida (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(ddlFormaPago, "SELECT")) {
            if (!JS_onError(frm, ddlFormaPago, "SELECT", "Seleccione forma de pago"))
                return false;
        }

        return confirmacion();
    }

    function confirmacion() {
        var seleccion = confirm("Desea Ud. Aprobar la Orden de Compra?");

        if (seleccion)
            this.disabled = true;
        else
            this.disabled = false;

        return seleccion;
    }

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Aprobar Orden de Compra</div>

 <asp:Label ID="lblError" runat="server" Text="" CssClass="cssError"></asp:Label>

<div class="cssTablaCabeceraRegistro">Orden de Compra</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Id Orden Compra</td>
    <td>:</td>
    <td><asp:Label ID="lblIdOrdenCompra" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Tipo Compra</td>
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
<tr>
    <td>Estado</td>
    <td>:</td>
    <td><asp:Label ID="lblEstadoAprobacion" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Descripción</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtDescripcionOC" runat="server" MaxLength="150" Width="500px"></asp:TextBox>
    </td>
</tr>
    <tr>
    <td>Nro Cotizacion Proveedor</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtNroCotizacionP" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Fecha Entrega</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaEntrega" runat="server" MaxLength="10" Width="100px"></asp:TextBox>
        <script type="text/javascript" language="javascript">
		<!--
            if (!document.layers) {
                document.write("<input type='button' onclick='popUpCalendar(this, MainContent_txtFechaEntrega, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
            }
		//-->
		</script>

    </td>
</tr>
<tr>
    <td>Forma de Pago</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="ddlFormaPago" runat="server">
        </asp:DropDownList>
    </td>
</tr>

<tr>
    <td>Afecto al IGV</td>
    <td>:</td>
    <td>
        <asp:CheckBox ID="chkIGV" runat="server" />
    </td>
</tr>

</table>

    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
        CssClass="cssButton" onclick="btnActualizar_Click" />
</div>
<div class="cssTablaCabeceraRegistro">Lineas Orden de Compra</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UDM" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="DescripciónLinea" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="PrecioUnitario" DataFormatString="{0:N5}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" DataFormatString="{0:N2}"  ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

    <asp:Button ID="btnAprobar" runat="server" Text="Enviar a Aprobar" CssClass="cssButton" 
        onclick="btnAprobar_Click" />

</div>


<asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox>
<asp:TextBox ID="txtIdOrdenCompra" Visible="false" runat="server"></asp:TextBox>

</asp:Content>
