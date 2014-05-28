<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecepcionInventarioTransaccion.aspx.cs" Inherits="AppWeb.frmRecepcionInventarioTransaccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language="javascript" type="text/javascript" src="Scripts/popcalendar.js"></script>

<script type="text/javascript">

    function js_validar() {
        var frm = document.getElementById("formmain");
        var almacen = document.getElementById("<%= ddlAlmacen.ClientID%>");
        var txtUbicacion = document.getElementById("<%= txtUbicacion.ClientID%>");
        var txtFechaVencimiento = document.getElementById("<%= txtFechaVencimiento.ClientID%>");

        var txtLote = document.getElementById("<%= txtLote.ClientID%>");
        var txtMarca = document.getElementById("<%= txtMarca.ClientID%>");
        var txtModelo = document.getElementById("<%= txtModelo.ClientID%>");
        var txtSerie = document.getElementById("<%= txtSerie.ClientID%>");
        
        if (!JS_hasValue(almacen, "SELECT")) {
            if (!JS_onError(frm, almacen, "SELECT", "Seleccione Almacen"))
                return false;
        }
        
        if (!JS_hasValue(txtUbicacion, "TEXT")) {
            if (!JS_onError(frm, txtUbicacion, "TEXT", "Ingrese ubicación"))
                return false;
        }

        if (!JS_hasValue(txtFechaVencimiento, "TEXT")) {
            if (!JS_onError(frm, txtFechaVencimiento, "TEXT", "Ingrese fecha de vencimiento"))
                return false;
        }

        if (!JS_checkeurodate(txtFechaVencimiento.value)) {
            if (!JS_onError(frm, txtFechaVencimiento, "TEXT", "Ingrese fecha de vencimiento valido - DD/MM/YYYY"))
                return false;
        }

        if (!JS_hasValue(txtLote, "TEXT")) {
            if (!JS_onError(frm, txtLote, "TEXT", "Ingrese lote"))
                return false;
        }

        if (!JS_hasValue(txtMarca, "TEXT")) {
            if (!JS_onError(frm, txtMarca, "TEXT", "Ingrese marca"))
                return false;
        }

        if (!JS_hasValue(txtModelo, "TEXT")) {
            if (!JS_onError(frm, txtModelo, "TEXT", "Ingrese modelo"))
                return false;
        }

        if (!JS_hasValue( txtSerie, "TEXT")) {
            if (!JS_onError(frm, txtSerie, "TEXT", "Ingrese serie"))
                return false;
        }


        return confirm('Desea Ud. Ejecutar la transaccion de ingreso al inventario?');
    }

</script>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Transacción de Inventario</div>


    <div class="cssTablaCabeceraRegistro">Datos de Recepción</div>
    <div class="cssTablaRegistro">
        <table >
        <tr>
            <td>Recepción</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblIdRecepcion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Fecha de Recepción</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblFechaRecepcion" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Número de O/C</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblIdOrdenCompra" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Linea de O/C</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblNumeroLineaOC" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Proveedor</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblRazonSocial" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        </table >
    </div>

    <div class="cssTablaCabeceraRegistro">Registro de Transacción de Inventario</div>
    <div class="cssTablaRegistro">
        <table >
        <tr>
            <td>Sede</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblSede" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Proyecto</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblProyecto" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Almacen (*)</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlAlmacen" runat="server" Width="200px"/></td>
        </tr>
        <tr>
            <td>Ubicación (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtUbicacion" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha de Vencimiento (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtFechaVencimiento" runat="server" Width="80" MaxLength="10"></asp:TextBox>
                
                <script language="javascript" type="text/javascript">
		        <!--
                    if (!document.layers) {
                        document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaVencimiento, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                    }
		        //-->
		        </script>
                
                
            </td>
        </tr>
        <tr>
            <td>Lote (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtLote" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Marca (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtMarca" runat="server" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Modelo (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtModelo" runat="server" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Serie (*)</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtSerie" runat="server" MaxLength="100"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Obs. de Almacenamiento</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtObsAlmacenamiento" runat="server" Width="400px" 
                    MaxLength="100"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Tipo de Transacción</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlTipoTransaccion" runat="server" Width="300px"/></td>
        </tr>
        <tr>
            <td>Fecha de Transacción</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtFechaTransaccion" Width="100px" runat="server" ReadOnly="true"></asp:TextBox>


            </td>
        </tr>
        <tr>
            <td>Descripción</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server" Width="800px" MaxLength="150"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Artículo</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblArticulo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cantidad</td>
            <td>:</td>
            <td>
                <asp:Label ID="lblCantidadRecibo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        </table>
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar Transacción" CssClass="cssButton" onclick="btnGrabar_Click" />
    </div>

    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false" ></asp:TextBox>
    <asp:TextBox ID="txtIdRecepcion" runat="server" Visible="false" ></asp:TextBox>
    <asp:TextBox ID="txtIdRecepcionLinea" runat="server" Visible="false" ></asp:TextBox>
    <asp:TextBox ID="txtIdArticulo" runat="server" Visible="false" ></asp:TextBox>


</asp:Content>
