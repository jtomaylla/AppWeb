<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMovimientoInventario.aspx.cs" Inherits="AppWeb.frmMovimientoInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script language=javascript src="Scripts/popcalendar.js"></script>

<script type="text/javascript">
    function js_validar() {
        var frm = document.getElementById("formmain");
        var ddlProyecto = document.getElementById("<%= ddlProyecto.ClientID%>");
        var tipoTransaccion = document.getElementById("<%= ddlTipoTransaccion.ClientID%>");



        if (!JS_hasValue(ddlProyecto, "SELECT")) {
            if (!JS_onError(frm, ddlProyecto, "SELECT", "Seleccione proyecto"))
                return false;
        }

        if (!JS_hasValue(tipoTransaccion, "SELECT")) {
            if (!JS_onError(frm, tipoTransaccion, "SELECT", "Seleccione tipo de transacción"))
                return false;
        }

        return confirm('Desea Ud. Ejecutar la transacción de inventario?');

    }

    function js_validar_busqueda() {
        var frm = document.getElementById("formmain");
        var descripcion = document.getElementById("<%= txtArticuloDesc.ClientID%>");
        if (!JS_hasValue(descripcion, "TEXT")) {
            if (!JS_onError(frm, descripcion, "TEXT", "Ingrese texto a buscar"))
                return false;
        }
        return true;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Movimiento de Inventarios</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="pnlBusqueda" runat="server">
    <div class="cssTituloPagina">Búsqueda de Artículos</div>
    <div>
        <asp:gridview id="gvLista" runat="server" 
            autogeneratecolumns="False"
            OnSelectedIndexChanged="gvLista_SelectedIndexChanged"
            CssClass="gridview"
            PagerStyle-CssClass="gridview_pager" 
            AlternatingRowStyle-CssClass="gridview_alter"
        >
        <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
        <PagerStyle CssClass="gridview_pager"></PagerStyle>
        <Columns>
            <asp:BoundField ReadOnly="True" DataField="IdArticulo" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Codigo" ItemStyle-Width="100px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="IdUnidadMedida" HeaderText="Unidad" ItemStyle-Width="100px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="200px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Codigo" HeaderText="Codigo" ItemStyle-Width="120px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="120px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="120px"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:imagebutton runat="server" Text="Select" CommandName="Select" CausesValidation="False" 
                        id="ImageButton1" ToolTip="Editar" 
                        imageurl="~/Images/Grilla.Flecha.gif"></asp:imagebutton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:gridview>
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" 
            Text="Cancelar" onclick="btnCancelar_Click" />
    </div>
</asp:Panel>
<asp:Panel ID="pnlRegistro" runat="server">
    <div class="cssTablaCabeceraRegistro">Registro</div>
    <div class="cssTablaRegistro">
        <table >
        <tr>
            <td>Id</td>
            <td>:</td>
            <td><asp:TextBox ID="txtId" runat="server" Width="40px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Proyecto</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlProyecto" runat="server"/></td>
        </tr>
        <tr>
            <td>Tipo de Transacción</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlTipoTransaccion" runat="server" Width="300px"/></td>
        </tr>
        <tr>
            <td>Fecha de Transacción</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFechaTransaccion" Width="100px" runat="server"></asp:TextBox>

                <script language="javascript">
		        <!--
                    if (!document.layers) {
                        document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaTransaccion, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                    }
		        //-->
		        </script>

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
            <td><asp:TextBox ID="txtArticulo" runat="server" Width="100px"></asp:TextBox>
                <asp:TextBox ID="txtArticuloDesc" runat="server" Width="600px"></asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar Artículo" 
                    onclick="btnBuscar_Click" CssClass="cssButton" /></td>
        </tr>
        <tr>
            <td>Cantidad</td>
            <td>:</td>
            <td><asp:TextBox ID="txtCantidad" runat="server" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Lote</td>
            <td>:</td>
            <td><asp:TextBox ID="txtlote" runat="server" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>F. Vence.</td>
            <td>:</td>
            <td><asp:TextBox ID="txtfechavencimiento" runat="server" Width="100px"></asp:TextBox>
            <script type="text/javascript">
                if (!document.layers) {
                    document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtfechavencimiento, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                }
            </script>            
            </td>
        </tr>
        </table>
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />
        <asp:TextBox ID="txtPrecio" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtIdArticulo" runat="server" Visible="false"></asp:TextBox>
    </div>
</asp:Panel>

</asp:Content>
