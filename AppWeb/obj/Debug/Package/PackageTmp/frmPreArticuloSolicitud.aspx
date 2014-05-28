<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPreArticuloSolicitud.aspx.cs" Inherits="AppWeb.frmPreArticuloSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script language=javascript src="Scripts/popcalendar.js"></script>

    <script type="text/javascript">

        function js_validar() {
            var frm = document.getElementById("formmain");
            var codigoarticulo = document.getElementById("<%= txtCodigoArticulo.ClientID%>");
            var descripcion = document.getElementById("<%= txtDescripcion.ClientID%>");

            if (!JS_hasValue(codigoarticulo, "TEXT")) {
                if (!JS_onError(frm, codigoarticulo, "TEXT", "Ingrese Código de Artículo"))
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
    <div class="cssTituloPagina">Solicitud de Creacion de Artículos</div>
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

<asp:Panel ID="panLista" runat="server">
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
        <asp:BoundField ReadOnly="True" DataField="IdArticuloPre" HeaderText="ID" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodigoArticulo" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreUnidadMedida" HeaderText="Unidad" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="500px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreClase" HeaderText="Clase" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Modelo" HeaderText="Modelo" ItemStyle-Width="120px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Marca" HeaderText="Marca" ItemStyle-Width="120px"></asp:BoundField>
        <asp:CheckBoxField DataField="EstadoBool" HeaderText="Estado"   />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerArticulo" runat="server" Text="Editar" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdArticuloPre") %>'
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
        <table >
        <tr>
            <td>ID</td>
            <td>:</td>
            <td><asp:TextBox ID="txtId" runat="server" Width="60px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Codigo Artículo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtCodigoArticulo" runat="server" Width="150px" MaxLength="13"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Unidad Medida</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlUnidad" runat="server" Width="300px"/></td>
        </tr>
        <tr>
            <td>Descripción</td>
            <td>:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server" Width="600px" MaxLength="150"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Clase</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlClase" runat="server" Width="300px"/></td>
        </tr>
        <tr>
            <td>Familia</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlFamilia" runat="server" Width="300px"/></td>
        </tr>
        <tr>
            <td>Proyecto</td>
            <td>:</td>
            <td><asp:DropDownList ID="ddlProyecto" runat="server" Width="700px"/></td>
        </tr>
        <tr>
            <td>Precio ultima O/C</td>
            <td>:</td>
            <td><asp:TextBox ID="txtPrecio" runat="server" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Tiempo Util</td>
            <td>:</td>
            <td><asp:TextBox ID="txtTiempo" runat="server" Width="100px" Enabled="false" Text="0"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Modelo</td>
            <td>:</td>
            <td><asp:TextBox ID="txtModelo" runat="server" Width="200px" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Marca</td>
            <td>:</td>
            <td><asp:TextBox ID="txtMarca" runat="server" Width="200px" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Serie</td>
            <td>:</td>
            <td><asp:TextBox ID="txtSerie" runat="server" Width="200px" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Lote</td>
            <td>:</td>
            <td><asp:TextBox ID="txtLote" runat="server" Width="200px" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fecha Vencimiento</td>
            <td>:</td>
            <td><asp:TextBox ID="txtFechaVencimiento" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                    <script language="javascript">
		<!--
                        if (!document.layers) {
                            document.write("<input type=button onclick='popUpCalendar(this, MainContent_txtFechaVencimiento, \"dd/mm/yyyy\")'  name='select1' value='...' style='font-size:11px'>")
                        }
		//-->
		</script>

            
            </td>
        </tr>
        <tr>
            <td valign="top">Observaciones</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtObservaciones" runat="server" Width="500px" MaxLength="300" 
                    Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">Observaciones de Almacenamiento</td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtObservacionesAlmacenamiento" runat="server" Width="500px" 
                    MaxLength="300" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Estado</td>
            <td>:</td>
            <td><asp:CheckBox ID="chkEstado" runat="server" /> Activo</td>
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

