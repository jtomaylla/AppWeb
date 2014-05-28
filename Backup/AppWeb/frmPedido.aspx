<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedido.aspx.cs" Inherits="AppWeb.frmPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<script type="text/javascript">

    function js_validar() {
        var frm = document.getElementById("formmain");
        var tipoPedido = document.getElementById("<%= ddlTipoPedido.ClientID%>");
        var proyecto = document.getElementById("<%= ddlProyecto.ClientID%>");
        var sede = document.getElementById("<%= ddlSede.ClientID%>");
        var descripcionPedido = document.getElementById("<%= txtDescripcionPedido.ClientID%>");
        //var moneda = document.getElementById("<%= ddlMoneda.ClientID%>");

        if (!JS_hasValue(tipoPedido, "SELECT")) {
            if (!JS_onError(frm, tipoPedido, "SELECT", "Seleccione Tipo de Pedido"))
                return false;
        }

        if (!JS_hasValue(proyecto, "SELECT")) {
            if (!JS_onError(frm, proyecto, "SELECT", "Seleccione Proyecto"))
                return false;
        }

        if (!JS_hasValue(sede, "SELECT")) {
            if (!JS_onError(frm, sede, "SELECT", "Seleccione Sede"))
                return false;
        }

        if (!JS_hasValue(descripcionPedido, "TEXT")) {
            if (!JS_onError(frm, descripcionPedido, "TEXT", "Ingrese descripcion del pedido"))
                return false;
        }

        /*
        if (!JS_hasValue(moneda, "SELECT")) {
            if (!JS_onError(frm, moneda, "SELECT", "Seleccione Moneda"))
                return false;
        }
        */

        return true;
    }

    function js_validar_linea() {
        var frm = document.getElementById("formmain");

        var tipoPedido = document.getElementById("<%= ddlTipoPedido.ClientID%>");
        var codigoArticulo = document.getElementById("<%= txtCodArticulo.ClientID%>");
        var descripcionLinea = document.getElementById("<%= txtDescripcionLinea.ClientID%>");
        var cantidad = document.getElementById("<%= txtCantidad.ClientID%>");
        var precioReferencial = document.getElementById("<%= txtPrecioReferencial.ClientID%>");

        if (!JS_hasValue(codigoArticulo, "TEXT")) {
            if (!JS_onError(frm, codigoArticulo, "TEXT", "Seleccione un articulo"))
                return false;
        }


        if (!JS_hasValue(descripcionLinea, "TEXT")) {
            if (!JS_onError(frm, descripcionLinea, "TEXT", "Ingrese descripcion de la linea"))
                return false;
        }

        if (!JS_hasValue(cantidad, "TEXT")) {
            if (!JS_onError(frm, cantidad, "TEXT", "Ingrese cantidad"))
                return false;
        }

        if (!JS_checknumber(cantidad.value)) {
            if (!JS_onError(frm, cantidad, "TEXT", "Ingrese valor numerico"))
                return false;
        }

        if (!JS_checknumberpositivo(cantidad.value)) {
            if (!JS_onError(frm, cantidad, "TEXT", "Ingrese valor numerico positivo"))
                return false;
        }

        if (tipoPedido.value == "1" || tipoPedido.value == "3") {
            if (!JS_hasValue(precioReferencial, "TEXT")) {
                if (!JS_onError(frm, precioReferencial, "TEXT", "Ingrese precio referencial"))
                    return false;
            }

            if (!JS_checknumber(precioReferencial.value)) {
                if (!JS_onError(frm, precioReferencial, "TEXT", "Ingrese valor numerico"))
                    return false;
            }

            if (!JS_checknumberpositivo(precioReferencial.value)) {
                if (!JS_onError(frm, precioReferencial, "TEXT", "Ingrese valor numerico positivo"))
                    return false;
            }
        }


        return true;
    }

    function js_validar_busqueda() {
        var frm = document.getElementById("formmain");
        var descripcionLinea = document.getElementById("<%= txtDescripcionLinea.ClientID%>");
        if (!JS_hasValue(descripcionLinea, "TEXT")) {
            if (!JS_onError(frm, descripcionLinea, "TEXT", "Ingrese texto a buscar"))
                return false;
        }
        return true;
    }

    function js_codigo_presupuesto() {
        var IdPedido = document.getElementById("<%= txtIdPedido.ClientID%>");
        window.open("frmPedidoCodigoPresupuesto.aspx?id="+IdPedido.value , "ventana1", "width=600,height=300,scrollbars=1") 
        return false;
    }

</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />
<div class="cssTituloPagina">Pedido</div>

<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<div class="cssTablaCabeceraRegistro">Registro</div>
<div class="cssTablaRegistro">
<table>
<tr>
    <td style="width:150px">Número de Pedido <span class="cssObligatorio">(*)</span>
    </td>
    <td>:</td>
    <td>
        <asp:TextBox ID="txtIdPedido" runat="server"  ReadOnly="true" Width="50px" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td style="width:150px">Tipo de Pedido <span class="cssObligatorio">(*)</span>
    </td>
    <td>:</td>
    <td>
        <asp:DropDownList ID="ddlTipoPedido" runat="server" Width="150px"  />
    </td>
</tr>

<tr>
    <td style="width:150px">Fecha de Pedido</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblFechaPedido" runat="server" Text="" ></asp:Label>
    </td>
</tr>
<tr>
    <td>Proyecto <span class="cssObligatorio">(*)</span></td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlProyecto" runat="server" Width="600px" /></td>
</tr>
<tr>
    <td>Sede <span class="cssObligatorio">(*)</span></td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlSede" runat="server" Width="200px" /></td>
</tr>
<tr>
    <td>Solicitante</td>
    <td>:</td>
    <td><asp:Label ID="lblNombreSolicitante" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>Código Presupuesto</td>
    <td>:</td>
    <td>
        <asp:Button ID="btnCodigoPresupuesto" runat="server" Text="Codigos Presupuesto..." CssClass="cssButton" />
    </td>
</tr>
<tr>
    <td>Descripción del Pedido <span class="cssObligatorio">(*)</span></td>
    <td>:</td>
    <td><asp:TextBox ID="txtDescripcionPedido" runat="server" Width="600px" MaxLength="150"></asp:TextBox></td>
</tr>
<tr>
    <td>Moneda <span class="cssObligatorio">(*)</span></td>
    <td>:</td>
    <td><asp:DropDownList ID="ddlMoneda" runat="server" /></td>
</tr>
<tr>
    <td>Estado</td>
    <td>:</td>
    <td>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>

<span class="cssObligatorio">(*) </span> Obligatorio
<br />

    <asp:Button ID="btnGrabarPedido" runat="server" Text="Registrar Pedido" 
        CssClass="cssButton" onclick="btnGrabarPedido_Click" />
    
    <asp:Button ID="btnActualizarPedido" runat="server" Text="Actualizar"  
        CssClass="cssButton" onclick="btnActualizarPedido_Click"/>

    <asp:Button ID="btnEliminarPedido" runat="server" CssClass="cssButton"  
        Text="Eliminar Pedido" onclick="btnEliminarPedido_Click" />

    <asp:Button ID="btnAgregarLinea" runat="server" Text="Nueva Linea" 
        CssClass="cssButton" onclick="btnAgregarLinea_Click" />

    <asp:Button ID="btnLineas" runat="server" Text="Ver Lineas del Pedido" 
        CssClass="cssButton" onclick="btnLineas_Click"  />

    <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" CssClass="cssButton" 
        onclick="btnRechazar_Click" />

    <asp:Button ID="btnEnviarAprobar" runat="server" Text="Enviar a Aprobar"  
        CssClass="cssButton" onclick="btnEnviarAprobar_Click"  />


</div>

<asp:Panel ID="pnlBusqueda" runat="server">

    <div class="cssTablaCabeceraRegistro">Búsqueda de Artículos</div>
    <div class="cssTablaRegistro">

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
            <asp:BoundField ReadOnly="True" DataField="IdArticulo" HeaderText="Id Articulo" ItemStyle-Width="100px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Codigo" ItemStyle-Width="120px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UnidadMedida" ItemStyle-Width="120px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="120px"></asp:BoundField>
            <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="120px"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnSeleccionarArticulo" runat="server" 
                        Text="Seleccionar" 
                        CommandName="Select" 
                        CausesValidation="False"  
                        CssClass="cssButton"  
                        CommandArgument = '<%# Bind("IdArticulo") %>'
                        />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:gridview>
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" 
            Text="Cancelar" onclick="btnCancelar_Click" />
    </div>
</asp:Panel>

<asp:Panel ID="panPedidoDetalle" runat="server">
    <div class="cssTablaCabeceraRegistro">Lineas de Pedido</div>
    <div class="cssTablaRegistro">
       <table>
        <tr>
            <td  style="width:150px">Linea</td>
            <td>:</td>
            <td><asp:TextBox ID="txtNumLinea" runat="server" Width="50px" ReadOnly="true"/></td>
        </tr>

        <tr>
            <td>
                Articulo</td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtCodArticulo" runat="server" Width="110px" ReadOnly="true"></asp:TextBox>
                <asp:TextBox ID="txtUnidadMedida" runat="server" Width="120px" ReadOnly="true"></asp:TextBox>
                <asp:TextBox ID="txtDescripcionLinea" runat="server" Width="600px"/>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Artículo" onclick="btnBuscar_Click" CssClass="cssButton"  />
                <asp:TextBox ID="txtIdArticulo" runat="server" Visible="false"/>

            </td>
        </tr>
        <tr>
            <td>
                Cantidad
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtCantidad" MaxLength="15" runat="server"/>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblPrecioReferencial1" runat="server" Text="Precio Referencial"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPrecioReferencial2" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrecioReferencial" MaxLength="15" runat="server"/>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblImporte1" runat="server" Text="Importe"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblImporte2" runat="server" Text=":"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtImporte" runat="server" MaxLength="15" ReadOnly="true"/>
            </td>
        </tr>

</table>
    <asp:Button ID="btnActualizarLinea" runat="server" Text="Actualizar" 
            CssClass="cssButton" onclick="btnActualizarLinea_Click" />

    <asp:Button ID="btnGrabarLinea" runat="server" Text="Agregar a Pedido" 
            CssClass="cssButton" onclick="btnGrabarLinea_Click" />

    <asp:Button ID="btnEliminarLinea" runat="server" Text="Eliminar Linea" CssClass="cssButton" 
            onclick="btnEliminarLinea_Click" />

  

    
</div>

</asp:Panel>

<asp:Panel ID="panPedidoDetalleLineas" runat="server">

    <div class="cssTablaCabeceraRegistro">Lineas de Pedido</div>
    <div class="cssTablaRegistro">

<asp:gridview id="gvPedidoLinea" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvPedidoLinea_RowCommand" 
        OnRowDataBound= "gvPedidoLinea_RowDataBound"
          
        
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="NumeroLinea" HeaderText="Linea" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="UnidadMedida" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionLinea" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PrecioReferencial" HeaderText="Precio" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Importe" HeaderText="Importe" ItemStyle-Width="100px"></asp:BoundField>

        <asp:BoundField ReadOnly="True" DataField="OrdenCompra" HeaderText="O/C" ItemStyle-Width="50px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" 
                    Text="Editar" 
                    CommandName="Select" 
                    CausesValidation="False" 
                    CssClass="cssButton" 
                    CommandArgument = '<%# Bind("IdPedidoDetalle") %>'
                    />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview> 

    </div>
</asp:Panel>

<br />


<asp:TextBox ID="txtIdPedidoDetalle" runat="server" Visible="false"></asp:TextBox>   
<asp:TextBox ID="txtIdUsuario2" runat="server" Visible="false"></asp:TextBox>

    
    </asp:Content>
