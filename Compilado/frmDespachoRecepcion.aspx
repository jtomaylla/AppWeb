<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDespachoRecepcion.aspx.cs" Inherits="AppWeb.frmDespachoRecepcion" %>
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

<div class="cssTituloPagina">Despacho de Recepción</div>

    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssError"></asp:Label>

<div class="cssTablaCabeceraRegistro">Datos de Guia de Remisión</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Recepción</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblIdRecepcion" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Número de O/C</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblNumOC" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>Punto Partida</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="ddlPuntoPartida" runat="server">
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td>Punto Llegada</td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="ddlPuntoLlegada" runat="server">
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td>Fecha Emisión</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaEmision" runat="server" Width="80px" MaxLength="10"></asp:TextBox>

        <script language="javascript">
		<!--
        if (!document.layers) {
          document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaEmision, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
        }
		//-->
		</script>
    </td>
</tr>
<tr>
    <td>Fecha Traslado</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaTraslado" runat="server" Width="80px" MaxLength="10"></asp:TextBox>
        <script language="javascript">
		<!--
            if (!document.layers) {
                document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaTraslado, \"dd/mm/yyyy\")'  name='select2' value='...' style='font-size:11px'>")
            }
		//-->
		</script>

    </td>
</tr>
<tr>
    <td>Número de Guia</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtSerie" runat="server" Width="40px" MaxLength="3"></asp:TextBox> - 
        <asp:TextBox ID="txtNumero" runat="server" Width="80px" MaxLength="6"></asp:TextBox>
    </td>
</tr>

</table>
</div>

<div class="cssTablaCabeceraRegistro">Destinatario</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Razon Social</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtDestinatario" runat="server" Width="400px" MaxLength="150"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>RUC</td>
    <td>:</td>
    <td>
     <asp:TextBox ID="txtRucDestinatario" runat="server" Width="120px" MaxLength="11"></asp:TextBox>
    </td>
</tr>
</table>
</div>

<div class="cssTablaCabeceraRegistro">Transportista</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Razon Social</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtTransportista" runat="server" Width="400px" MaxLength="150"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>RUC</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtRucTransportista" runat="server" Width="120px" MaxLength="11"></asp:TextBox>
    </td>
</tr>

<tr>
    <td>Marca</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Placa</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Certificado</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtCetificado" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Licencia</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtLicencia" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>Número de Comprobante de Pago</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtComprobante" runat="server"></asp:TextBox>
    </td>
</tr>

</table>
</div>

<br />
    <asp:Button ID="btnDepachar" runat="server" Text="Despachar" Width="150" 
        CssClass="cssButton" onclick="btnDepachar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="150" 
        CssClass="cssButton" onclick="btnCancelar_Click" />


<br />
    <asp:Label ID="lblIdDespacho" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblIdGuiaRemision" runat="server" Text=""></asp:Label>

</asp:Content>
