<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPedidoCodigoPresupuesto.aspx.cs" Inherits="AppWeb.frmPedidoCodigoPresupuesto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="Scripts/rbtec.js" type="text/javascript"></script>

<script type="text/javascript">

    function js_validar() {
        var frm = document.getElementById("form1");
        var codigoPresupuesto = document.getElementById("<%= txtCodigoPresupuesto.ClientID%>");
        var descripcion = document.getElementById("<%= txtDescripcion.ClientID%>");

        if (!JS_hasValue(codigoPresupuesto, "TEXT")) {
            if (!JS_onError(frm, codigoPresupuesto, "TEXT", "Ingrese código de presupuesto"))
                return false;
        }

        if (!JS_hasValue(descripcion, "TEXT")) {
            if (!JS_onError(frm, descripcion, "TEXT", "Ingrese descripción"))
                return false;
        }

        return true;
    }


</script>


</head>
<body>
    <form id="form1" runat="server">
    <div class="page">
    
    <div class="cssTituloPagina">Codigos de Presupuesto</div>

        <asp:Panel ID="panRegistro" runat="server">
            <table>
                <tr>
                    <td>Código</td>
                    <td>Descripción</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCodigoPresupuesto" MaxLength="20" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" MaxLength="100" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="cssButton" 
                            onclick="btnAgregar_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>


<asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvLista_RowCommand" 
        OnRowDataBound ="gvLista_RowDataBound"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="CodigoPresupuesto" HeaderText="Código" ItemStyle-Width="100px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="300px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" 
                    Text="Eliminar" 
                    CommandName="Eliminar" 
                    CausesValidation="False" 
                    CssClass="cssButton" 
                    CommandArgument = '<%# Bind("IdPedidoPresupuesto") %>'
                    />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:gridview> 

        <asp:TextBox ID="txtIdPedido" runat="server" Visible="false"></asp:TextBox>
    </div>
    </form>
</body>
</html>
