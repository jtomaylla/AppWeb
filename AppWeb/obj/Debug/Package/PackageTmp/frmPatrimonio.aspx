<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPatrimonio.aspx.cs" Inherits="AppWeb.frmPatrimonio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language=javascript src="Scripts/popcalendar.js"></script>

    <script type="text/javascript">
        function js_validar() {
            var frm = document.getElementById("formmain");
            var codigo = document.getElementById("<%= txtCodigo.ClientID%>");
            var descripcion = document.getElementById("<%= txtDescripcion.ClientID%>");

            if (!JS_hasValue(codigo, "TEXT")) {
                if (!JS_onError(frm, codigo, "TEXT", "Ingrese Código de Activo Fijo"))
                    return false;
            }
            if (!JS_hasValue(descripcion, "TEXT")) {
                if (!JS_onError(frm, descripcion, "TEXT", "Ingrese Descripcion"))
                    return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cssTituloPagina">Mantenimiento de Patrimonio</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="panLista" runat="server">
    Buscur:<asp:TextBox ID="txtBusqueda" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnBuscar" CssClass="cssButton" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="cssButton" onclick="btnNuevo_Click" />
    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        OnRowCommand="gvLista_RowCommand"  
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        PageSize="20" 
        AllowPaging="true" 
        OnPageIndexChanging="gvLista_PageIndexChanging"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdActivoFijo" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Codigo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaBaja" HeaderText="Fecha Baja" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Serie" HeaderText="Serie" ItemStyle-Width="120px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerActivoFijo" runat="server" Text="Editar" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdActivoFijo") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
</asp:Panel>
<asp:Panel ID="panRegistro" runat="server">
    <div class="cssTablaCabeceraRegistro">Registro</div>
    <div class="cssTablaRegistro">
        <table>
        <tr>
            <td>ID</td>
            <td>:</td>
            <td><asp:TextBox ID="txtId" runat="server" Width="60px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Codigo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtCodigo" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Observación 1</td>
            <td>:</td>
            <td><asp:TextBox ID="txtObservacion1" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha Baja</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFechaBaja" runat="server" Width="120px"></asp:TextBox>
                <script language="javascript">
		        <!--
                            if (!document.layers) {
                                document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaBaja, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                            }
		        //-->
		        </script>
            </td>
        </tr>
        <tr>
            <td>Descripción</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Marca</td>
            <td>:</td>
            <td><asp:TextBox ID="txtMarca" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Modelo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtModelo" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Serie</td>
            <td>:</td>
            <td><asp:TextBox ID="txtSerie" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Local Origen</td>
            <td>:</td>
            <td><asp:TextBox ID="txtLocalOrigen" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ubicación</td>
            <td>:</td>
            <td><asp:TextBox ID="txtUbicacion" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Area proyecto</td>
            <td>:</td>
            <td><asp:TextBox ID="txtAreaProyecto" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Usuario Asignación</td>
            <td>:</td>
            <td><asp:TextBox ID="txtUsuarioAsignacion" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>:</td>
            <td><asp:CheckBox ID="chkEstado" runat="server" /> Activo</td>
        </tr>
        <tr>
            <td>Factura</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFactura" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha Factura</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFechaFactura" runat="server" Width="200px"></asp:TextBox>
                <script language="javascript">
		        <!--
                if (!document.layers) {
                    document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaFactura, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                }
		        //-->
		        </script>
            </td>
        </tr>
        <tr>
            <td>Proveedor</td>
            <td>:</td>
            <td><asp:TextBox ID="txtProveedor" runat="server" Width="600px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>RUC</td>
            <td>:</td>
            <td><asp:TextBox ID="txtRuc" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Precio Soles</td>
            <td>:</td>
            <td><asp:TextBox ID="txtPrecioSoles" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Precio Dólares</td>
            <td>:</td>
            <td><asp:TextBox ID="txtPrecioDolares" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Observación 2</td>
            <td>:</td>
            <td><asp:TextBox ID="txtObservacion2" runat="server" Width="600px"></asp:TextBox></td>
        </tr>

        </table>

        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="cssButton" onclick="btnGrabar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton" onclick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="cssButton" onclick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="cssButton" onclick="btnCancelar_Click" Text="Cancelar" />
    </div>
    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
</asp:Panel>
</asp:Content>
