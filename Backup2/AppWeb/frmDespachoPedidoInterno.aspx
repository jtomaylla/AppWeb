<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDespachoPedidoInterno.aspx.cs" Inherits="AppWeb.frmDespachoPedidoInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language=javascript src="Scripts/popcalendar.js"></script>

<script type="text/javascript">

    function js_validar() {
        var frm = document.getElementById("formmain");

        var ddlPuntoPartida = document.getElementById("<%= ddlPuntoPartida.ClientID%>");
        var ddlPuntoLlegada = document.getElementById("<%= ddlPuntoLlegada.ClientID%>");

        var txtFechaEmision = document.getElementById("<%= txtFechaEmision.ClientID%>");
        var txtFechaTraslado = document.getElementById("<%= txtFechaTraslado.ClientID%>");

        var txtSerie = document.getElementById("<%= txtSerie.ClientID%>");
        var txtNumero = document.getElementById("<%= txtNumero.ClientID%>");

        var txtDestinatario = document.getElementById("<%= txtDestinatario.ClientID%>");
        var txtRucDestinatario = document.getElementById("<%= txtRucDestinatario.ClientID%>");

        var txtTransportista = document.getElementById("<%= txtTransportista.ClientID%>");
        var txtRucTransportista = document.getElementById("<%= txtRucTransportista.ClientID%>");

        var txtMarca = document.getElementById("<%= txtMarca.ClientID%>");
        var txtPlaca = document.getElementById("<%= txtPlaca.ClientID%>");
        var txtCetificado = document.getElementById("<%= txtCetificado.ClientID%>");
        var txtLicencia = document.getElementById("<%= txtLicencia.ClientID%>");
        var txtComprobante = document.getElementById("<%= txtComprobante.ClientID%>");

        if (!JS_hasValue(ddlPuntoPartida, "SELECT")) {
            if (!JS_onError(frm, ddlPuntoPartida, "SELECT", "Seleccione punto de partida"))
                return false;
        }

        if (!JS_hasValue(ddlPuntoLlegada, "SELECT")) {
            if (!JS_onError(frm, ddlPuntoLlegada, "SELECT", "Seleccione punto de llegada"))
                return false;
        }

        if (!JS_hasValue(txtFechaEmision, "TEXT")) {
            if (!JS_onError(frm, txtFechaEmision, "TEXT", "Ingrese fecha de emisión valido"))
                return false;
        }

        if (!JS_checkeurodate(txtFechaEmision.value)) {
            if (!JS_onError(frm, txtFechaEmision, "TEXT", "Ingrese fecha de emisión valido (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(txtFechaTraslado, "TEXT")) {
            if (!JS_onError(frm, txtFechaTraslado, "TEXT", "Ingrese fecha de inicio de traslado valido"))
                return false;
        }


        if (!JS_checkeurodate(txtFechaTraslado.value)) {
            if (!JS_onError(frm, txtFechaTraslado, "TEXT", "Ingrese fecha de inicio de traslado valido (DD/MM/YYYY)"))
                return false;
        }

        if (!JS_hasValue(txtSerie, "TEXT")) {
            if (!JS_onError(frm, txtSerie, "TEXT", "Ingrese serie de guia"))
                return false;
        }

        if (!JS_hasValue(txtNumero, "TEXT")) {
            if (!JS_onError(frm, txtNumero, "TEXT", "Ingrese número de guia"))
                return false;
        }

        if (!JS_hasValue(txtDestinatario, "TEXT")) {
            if (!JS_onError(frm, txtDestinatario, "TEXT", "Ingrese destinatario"))
                return false;
        }

        if (!JS_hasValue(txtRucDestinatario, "TEXT")) {
            if (!JS_onError(frm, txtRucDestinatario, "TEXT", "Ingrese RUC del destinatario"))
                return false;
        }

        if (!JS_hasValue(txtTransportista, "TEXT")) {
            if (!JS_onError(frm, txtTransportista, "TEXT", "Ingrese transportista"))
                return false;
        }

        if (!JS_hasValue(txtRucTransportista, "TEXT")) {
            if (!JS_onError(frm, txtRucTransportista, "TEXT", "Ingrese RUC del transportista"))
                return false;
        }

        //---
        if (!JS_hasValue(txtMarca, "SELECT")) {
            if (!JS_onError(frm, txtMarca, "SELECT", "Ingrese marca del vehiculo"))
                return false;
        }

        if (!JS_hasValue(txtPlaca, "TEXT")) {
            if (!JS_onError(frm, txtPlaca, "TEXT", "Ingrese placa del vehiculo"))
                return false;
        }

        if (!JS_hasValue(txtCetificado, "SELECT")) {
            if (!JS_onError(frm, txtCetificado, "SELECT", "Ingrese número de certificado"))
                return false;
        }


        if (!JS_hasValue(txtLicencia, "TEXT")) {
            if (!JS_onError(frm, txtLicencia, "TEXT", "Ingrese número de licencia"))
                return false;
        }


        if (!JS_hasValue(txtComprobante, "TEXT")) {
            if (!JS_onError(frm, txtComprobante, "TEXT", "Ingrese comprobante de pago"))
                return false;
        }

        return confirm('Deseas Ud. realizar el despacho?');

    }

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Despacho de Perdido Interno</div>

<div class="cssTablaCabeceraRegistro">Pedido</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Número de Pedido</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtIdPedido" runat="server" ReadOnly="true" Width="80px" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Tipo de Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblTipoPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Fecha de Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Proyecto</td>
    <td>:</td>
    <td><asp:Label ID="lblProyecto" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Sede</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblSede" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Solicitante</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreSolicitante" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Descripción del Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblDescripcionPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
</tr>

</table>

</div>

<asp:Panel ID="panPedidoDetalleLineas" runat="server">

<div class="cssTablaCabeceraRegistro">Lineas del Pedido</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvPedidoLinea" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter" 
        DataKeyNames = "IdPedidoDetalle"
        onselectedindexchanged="gvPedidoLinea_SelectedIndexChanged"
       
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:CheckBox ID="chkSeleccion" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UnidadMedida" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField ShowHeader="True" HeaderText="CantDespacho">
            <ItemTemplate>
                <asp:TextBox ID="txtCantidadDespacho" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>

    <asp:Button ID="btnDespacho" runat="server" Text="Despachar" 
        CssClass="cssButton" onclick="btnDespacho_Click" Visible="true" />

    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"   
        CssClass="cssButton" onclick="btnCancelar_Click"  />

</div>
</asp:Panel>




<br />


<asp:TextBox ID="txtIdPedidoDetalle" runat="server" Visible="false"></asp:TextBox>   
<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>

<br />

<asp:Label ID="lblIdPedido" runat="server" Text=""  ></asp:Label>
<asp:Label ID="lblIdDespacho" runat="server" Text=""></asp:Label>
<asp:Label ID="lblIdGuiaRemision" runat="server" Text=""></asp:Label>


</asp:Content>
