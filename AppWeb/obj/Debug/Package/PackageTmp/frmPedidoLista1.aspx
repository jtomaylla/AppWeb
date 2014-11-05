<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPedidoLista1.aspx.cs" Inherits="AppWeb.frmPedidoLista1" %>
<%@ Register Assembly="GroupGridViewCtrl" 
    Namespace="GroupGridViewCtrl" TagPrefix="gsoft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript" 
    src="Scripts/jquery-1.4.2.min.js"></script>
<div class="cssTituloPagina">Solicitud de Pedido de Compra</div>

<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Pedido" CssClass="cssButton" 
        onclick="btnNuevo_Click"  />
<%--
<asp:gridview id="gvPedidoLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvPedidoLista_RowCommand"  
        PageSize="10" 
        AllowPaging="true" 
        OnPageIndexChanging="gvPedidoLista_PageIndexChanging"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreTipoPedido" HeaderText="Tipo" ItemStyle-Width="60px" />
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSolicitante" HeaderText="Solicitante" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Moneda" ItemStyle-Width="20px" />
        <asp:BoundField ReadOnly="True" DataField="Descripcion" HeaderText="Descripción" ItemStyle-Width="450px" />
        <asp:BoundField ReadOnly="True" DataField="FechaPedido" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="FechaAprobacionTexto" HeaderText="FechaAprob" ItemStyle-Width="80px" />
        <asp:BoundField ReadOnly="True" DataField="NombreEstadoControl" HeaderText="EstadoControl" ItemStyle-Width="200px" />
        <asp:BoundField ReadOnly="True" DataField="OrdenCompra" HeaderText="O/C" ItemStyle-Width="50px" />

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerPedido" runat="server" Text="Ver Pedido" 
                    CommandName="Seleccionar" 
                    CausesValidation="False" 
                    CommandArgument = '<%# Bind("IdPedido") %>'
                    CssClass="cssButton" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
     <PagerStyle CssClass="gridview_pager"></PagerStyle>
    </asp:gridview>
    --%>


    <div style="width:900px;">
        <table style="width:100%;">
            <tr>
                <td align="left">
                    Group Column: <asp:DropDownList ID="ddlGroupColumn" runat="server" AutoPostBack="true" Width="250" 
                        OnSelectedIndexChanged="ddlGroupColumn_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td align="right">
                    Animation Speed: <asp:DropDownList ID="ddlAnimationSpeed" runat="server"  AutoPostBack="true"
                        Width="150" OnSelectedIndexChanged="ddlAnimationSpeed_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <gsoft:GroupGridView AllowGrouping="true" AllowPaging="false" PageSize="20" DefaultState="Collapsed"
            GroupColumnName="ID_PEDIDO" ID="grdRawData" runat="server" BackColor="White" AutoGenerateColumns="false"
            CssClass="grid" Width="900" GridLines="None"
            OnPageIndexChanging="grdRawData_PageIndexChanging">
            <GroupHeaderTemplate>
                <div style="background-color:#ccddff;">
                    <table style="width:100%;">
                        <tr>
                            <td style="width:50%; font-weight:bold;"><%# Container.GroupColumnName + ": " + Container.GroupColumnData.ToString() %> </td>
                            <td style="width:50%;">Total Orders: <%# Container.Count("ID_PEDIDO")%></td>
                        </tr>
                    </table>
                </div>
            </GroupHeaderTemplate>
            <Columns>
                <asp:TemplateField HeaderText="S. No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>.
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ReadOnly="True" DataField="ID_PEDIDO" HeaderText="Pedido" ItemStyle-Width="60px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_TIPO_PEDIDO" HeaderText="Tipo" ItemStyle-Width="60px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_PROYECTO" HeaderText="Proyecto" ItemStyle-Width="350px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_SEDE" HeaderText="Sede" ItemStyle-Width="150px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_SOLICITANTE" HeaderText="Solicitante" ItemStyle-Width="150px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_MONEDA" HeaderText="Moneda" ItemStyle-Width="20px" />
                <asp:BoundField ReadOnly="True" DataField="DESCRIPCION" HeaderText="Descripción" ItemStyle-Width="450px" />
                <asp:BoundField ReadOnly="True" DataField="FECHA_PEDIDO" HeaderText="Fecha" dataformatstring="{0:dd/MM/yyyy}"  ItemStyle-Width="80px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_ESTADO" HeaderText="Estado" ItemStyle-Width="200px" />
                <asp:BoundField ReadOnly="True" DataField="FECHA_APROBACION" HeaderText="FechaAprob" ItemStyle-Width="80px" />
                <asp:BoundField ReadOnly="True" DataField="NOMBRE_ESTADO_CONTROL" HeaderText="EstadoControl" ItemStyle-Width="200px" />
                <asp:BoundField ReadOnly="True" DataField="ORDEN_COMPRA" HeaderText="O/C" ItemStyle-Width="50px" />

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnVerPedido" runat="server" Text="Ver Pedido" 
                            CommandName="Seleccionar" 
                            CausesValidation="False" 
                            CommandArgument = '<%# Bind("ID_PEDIDO") %>'
                            CssClass="cssButton" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <RowStyle BackColor="#FFFFFF" />
            <FooterStyle BackColor="#CCCC99" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5B598B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#e8e8ff" />
            <PagerStyle BackColor="#ffcccc" />
        </gsoft:GroupGridView>
    
</asp:Content>
