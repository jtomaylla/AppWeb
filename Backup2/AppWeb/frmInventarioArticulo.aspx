<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInventarioArticulo.aspx.cs" Inherits="AppWeb.frmInventarioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function js_validar_busqueda() {
        var frm = document.getElementById("formmain");
        var ddlProyecto = document.getElementById("<%= ddlProyecto.ClientID%>");
        var descripcion = document.getElementById("<%= txtArticuloDesc.ClientID%>");


        if (!JS_hasValue(ddlProyecto, "SELECT")) {
            if (!JS_onError(frm, ddlProyecto, "SELECT", "Seleccione Proyecto"))
                return false;
        }

        if (!JS_hasValue(descripcion, "TEXT")) {
            if (!JS_onError(frm, descripcion, "TEXT", "Ingrese texto a buscar"))
                return false;
        }
        return true;
    }


    function js_imprimir_kardex() {

        var txtIdArticulo = document.getElementById("<%= txtIdArticulo.ClientID%>");
        var ddlProyecto = document.getElementById("<%= ddlProyecto.ClientID%>");


        if (!JS_hasValue(ddlProyecto, "SELECT")) {
            if (!JS_onError(frm, ddlProyecto, "SELECT", "Seleccione Proyecto"))
                return false;
        }

        if (!JS_hasValue(txtIdArticulo, "TEXT")) {
            alert("Seleccione un articulo");
            return false;
        }

        var proy = ddlProyecto.options[ddlProyecto.selectedIndex].value;

        JS_openWindow("KardexArticulo.aspx?id=" + txtIdArticulo.value + "&id2=" + proy, "Kardex", "600", "300", "yes", "yes", "yes", "no", "no");
        
        return false;
        
    }

    function js_imprimir_listado() {
        JS_openWindow("ListadoArticulos.aspx");

        return false;
    }

</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Transacciones de Artículo</div>
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
            <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="200px"></asp:BoundField>
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
<asp:Panel ID="pnlPrincipal" runat="server">
    <div class="cssTablaCabeceraRegistro">Transacciones</div>
    <div class="cssTablaRegistro">
        <table >
        <tr>
            <td>
            Proyecto
            </td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="ddlProyecto" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Artículo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtArticulo" runat="server" Width="100px" Enabled="False">
                </asp:TextBox><asp:TextBox ID="txtArticuloDesc" runat="server" Width="400px">
                </asp:TextBox><asp:Button ID="btnBuscar" runat="server" Text="Buscar Artículo" 
                    onclick="btnBuscar_Click" CssClass="cssButton" /></td>
        </tr>
        <tr>
            <td>Descripción</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server" Width="800px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Unidad</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlUnidad" runat="server" Width="200px"/></td>
        </tr>
        <tr>
            <td>Stock Actual</td>
            <td>:</td>
            <td><asp:TextBox ID="txtStockActual" runat="server" Width="200px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Id</td>
            <td>:</td>
            <td><asp:TextBox ID="txtIdArticulo" runat="server" ReadOnly="true"></asp:TextBox></td>
        </tr>

        </table>
        <div><span>
            <asp:Button ID="btnKardex" runat="server" Text="Kardex" CssClass="cssButton" 
            onclick="btnKardex_Click" />
             </span><span style="margin-left:10px;">
                 <asp:Button ID="btnlistadoart" runat="server" Text="Ver Todos" CssClass="cssButton" OnClick="btnlistadoart_Click" />
                    </span></div>
        
        <br />
        <div>
            <asp:gridview id="gvTransaccion" runat="server" 
            autogeneratecolumns="False"
            CssClass="gridview"
            PagerStyle-CssClass="gridview_pager" 
            AlternatingRowStyle-CssClass="gridview_alter" onrowdatabound="gvTransaccion_RowDataBound"
            >
            <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
            <PagerStyle CssClass="gridview_pager"></PagerStyle>
            <Columns>
                <asp:BoundField ReadOnly="True" DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField ReadOnly="True" DataField="IdTipoTransaccion" HeaderText="Tipo de Trx" ItemStyle-Width="100px">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblTransaccion" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="200px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" 
                    ItemStyle-Width="400px" ReadOnly="True">
                <ItemStyle Width="400px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ingreso">
                    <ItemTemplate>
                        <asp:Label ID="lblIngreso" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salida">
                    <ItemTemplate>
                        <asp:Label ID="lblSalida" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
            </Columns>
            </asp:gridview>
        </div>
    </div>

      

</asp:Panel>
</asp:Content>
