<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacion.aspx.cs" Inherits="AppWeb.frmCotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript">

    function js_validar_proveedor() {
        var frm = document.getElementById("formmain");
        var proveedor = document.getElementById("<%= ddlProveedor.ClientID%>");
        var precio = document.getElementById("<%= txtPrecio.ClientID%>");
        var diasEntrega = document.getElementById("<%= txtDiasEntrega.ClientID%>");

        if (!JS_hasValue(proveedor, "SELECT")) {
            if (!JS_onError(frm, proveedor, "SELECT", "Seleccione proveedor"))
                return false;
        }
        
        if (!JS_hasValue(precio, "TEXT")) {
            if (!JS_onError(frm, precio, "TEXT", "Ingrese precio"))
                return false;
        }

        if (!JS_checknumber(precio.value)) {
            if (!JS_onError(frm, precio, "TEXT", "Ingrese valor numérico"))
                return false;
        }

        if (!JS_checknumberpositivo(precio.value)) {
            if (!JS_onError(frm, precio, "TEXT", "Ingrese valor numérico positivo"))
                return false;
        }


        if (!JS_hasValue(diasEntrega, "TEXT")) {
            if (!JS_onError(frm, diasEntrega, "TEXT", "Ingrese días de entrega"))
                return false;
        }

        if (!JS_checkinteger(diasEntrega.value)) {
            if (!JS_onError(frm, diasEntrega, "TEXT", "Ingrese valor entero para días de entrega"))
                return false;
            
        }

        return true;
    }

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="cssTituloPagina">Cotización <asp:Literal ID="litIdCotizacion" runat="server"></asp:Literal></div>

    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td>Cotización</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblIdCotizacion" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Pedido de Compra</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblIdPedido" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Fecha de Solicitud de Compra</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaSolicitudCompra" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>Solicitud Por</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblNombreSolicitante" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>Fecha Cotización</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaCotizacion" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Descripcion de Cotización</td>
    <td>:</td>
    <td><asp:TextBox ID="txtDescripcionCotizacion" runat="server" Width="600px" MaxLength="150"></asp:TextBox></td>
</tr>
<tr>
    <td class="style1">Moneda</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblMoneda" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
        CssClass="cssButton" onclick="btnActualizar_Click"  />

    <asp:Button ID="btnGenerarOrdenCompra" runat="server" 
        Text="Generar Orden de Compra" CssClass="cssButton" 
        onclick="btnGenerarOrdenCompra_Click" />

</div>

<div class="cssTablaCabeceraRegistro">Líneas</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLineas" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnSelectedIndexChanged="gvLineas_SelectedIndexChanged"
        OnRowCommand="gvLineas_RowCommand" 
        OnRowDataBound = "gvLineas_RowDataBound" 
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Lin" ItemStyle-Width="30px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Articulo" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="350px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Proveedor Seleccionado" ItemStyle-Width="300px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnSelProveedor" runat="server" Text="Proveedores" CssClass="cssButton" 
                    CausesValidation="False" 
                    CommandName="Select" 
                    CommandArgument = '<%# Bind("IdCotizacionLinea") %>'
                />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 

    <asp:Button ID="btnSeleccionarProveedor" runat="server" 
        Text="Recomendar Proveedor"  
        CssClass="cssButton" 
        onclick="btnSeleccionarProveedor_Click"  />

</div>

<asp:Panel ID="panProveedor" runat="server">

<div class="cssTablaCabeceraRegistro">Proveedores 
    <asp:Label ID="lblLinea" runat="server" Text="Label"></asp:Label></div>
<div class="cssTablaRegistro">

<asp:Panel ID="panSeleccionProveedor" runat="server">

<table>
<tr>
    <td>Proveedor</td>
    <td>Precio</td>
    <td>Días de Entrega</td>
    <td>Incluye IGV</td>
    <td></td>
</tr>
<tr>
    <td><asp:DropDownList ID="ddlProveedor" runat="server"></asp:DropDownList></td>
    <td><asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></td>
    <td><asp:TextBox ID="txtDiasEntrega" runat="server" Width="40px" MaxLength="3"></asp:TextBox></td>
    <td>
        <asp:CheckBox ID="chkIGV" runat="server" />
    </td>

    <td><asp:Button ID="btnAgregarProceedor" runat="server" Text="Agregar" CssClass="cssButton"
        onclick="btnAgregarProceedor_Click" /></td>
</tr>
</table>

</asp:Panel>


<asp:gridview id="gvProveedores" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvProveedores_RowCommand" 
        OnRowDataBound="gvProveedores_RowDataBound" 
        DataKeyNames="IdCotizacion, IdCotizacionLinea, IdProveedor"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="Ruc" HeaderText="RUC" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="RazonSocial" HeaderText="Razón Social" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Precio" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DiasEntrega" HeaderText="Dias Entrega" ItemStyle-Width="100px"></asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" 
                    CommandName="Seleccionar"
                    CausesValidation="False" 
                    CssClass="cssButton"
                 />

            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:imagebutton runat="server" Text="Select" 
                    CommandName="Eliminar" 
                    CausesValidation="False" 
                    id="imgEliminar"  ToolTip="Eliminar"
                    CommandArgument = '<%# Bind("IdCotizacion") %>, <%# Bind("IdCotizacionLinea") %>'
                    imageurl="~/Images/GrillaEliminar.gif"></asp:imagebutton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 



</div>

</asp:Panel>

<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtIdCotizacion" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtIdCotizacionLinea" runat="server" Visible="false"></asp:TextBox>

</asp:Content>
