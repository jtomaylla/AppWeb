<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportePedidos1.aspx.cs" Inherits="AppWeb.frmReportePedidos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript" src="Scripts/popcalendar.js"></script>

    <script type="text/javascript" language="javascript">

        function js_validar() {
            var frm = document.getElementById("formmain");
            var txtFechaInicial = document.getElementById("<%= txtFechaInicial.ClientID%>");
            var txtFechaFinal = document.getElementById("<%= txtFechaFinal.ClientID%>");

            if (!JS_hasValue(txtFechaInicial, "TEXT")) {
                if (!JS_onError(frm, txtFechaInicial, "TEXT", "Seleccione fecha inicial"))
                    return false;
            }

            if (!JS_checkeurodate(txtFechaInicial.value)) {
                if (!JS_onError(frm, txtFechaInicial, "TEXT", "Seleccione fecha inicial valida (DD/MM/YYYY)"))
                    return false;
            }

            if (!JS_hasValue(txtFechaFinal, "TEXT")) {
                if (!JS_onError(frm, txtFechaFinal, "TEXT", "Seleccione fecha final"))
                    return false;
            }

            if (!JS_checkeurodate(txtFechaFinal.value)) {
                if (!JS_onError(frm, txtFechaFinal, "TEXT", "Seleccione fecha final valida (DD/MM/YYYY)"))
                    return false;
            }


            return true;
        }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<div class="cssTituloPagina">Reporte de Pedidos</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>
<div class="cssTablaCabeceraRegistro">Parametros</div>
<div class="cssTablaRegistro">

<table>
<tr>
    <td>Fecha Inicial</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaInicial" runat="server" MaxLength="10" Width="80px"></asp:TextBox>

        <script type="text/javascript" language="javascript">
		<!--
            if (!document.layers) {
                document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaInicial, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
            }
		//-->
		</script>
        
        </td>

</tr>
<tr>
    <td>Fecha Final</td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtFechaFinal" runat="server" MaxLength="10" Width="80px"></asp:TextBox>

        <script type="text/javascript" language="javascript">
		<!--
            if (!document.layers) {
                document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaFinal, \"dd/mm/yyyy\")'  name='select2' value='...' style='font-size:11px'>")
            }
		//-->
		</script>
        
    </td>
</tr>
<tr>
    <td>Sede</td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlSede" runat="server"></asp:DropDownList>
    </td>
</tr>
<tr>
    <td>Proyecto</td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlProyecto" runat="server"></asp:DropDownList>
    </td>
</tr>
<tr>
    <td>Estado del Pedido</td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlEstadoPedido" runat="server"></asp:DropDownList>
    </td>
</tr>
</table>

    <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="cssButton" Width="100px"
        onclick="btnReporte_Click" />
</div>
</asp:Content>
