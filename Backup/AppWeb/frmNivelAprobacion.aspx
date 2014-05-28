<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNivelAprobacion.aspx.cs" Inherits="AppWeb.frmNivelAprobacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<br />
<div class="cssTituloPagina">Niveles de Aprobación de Orden de Compra</div>

<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="cssMensaje"></asp:Label>

    <asp:gridview id="gvLista" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowDataBound = "gvLista_OnRowDataBound"
        DataKeyNames = "IdNivelAprobacion"
    >
    <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <PagerStyle CssClass="gridview_pager"></PagerStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdNivelAprobacion" HeaderText="Id" ItemStyle-Width="50px"></asp:BoundField>
        <asp:TemplateField ShowHeader="true" HeaderText="Nombre">
            <ItemTemplate>
                <asp:TextBox ID="txtNombreNivelAprobacion" runat="server" Width="250px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="true" HeaderText="Límite Inferior">
            <ItemTemplate>
                <asp:TextBox ID="txtLimiteInferior" runat="server" Width="150px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="true" HeaderText="Límite Superior">
            <ItemTemplate>
                <asp:TextBox ID="txtLimiteSuperior" runat="server" Width="150px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Moneda" ItemStyle-Width="50px"></asp:BoundField>
        <asp:TemplateField ShowHeader="true" HeaderText="Aprobador">
            <ItemTemplate>
                <asp:DropDownList ID="ddlUsuarioAprobacion" runat="server" Width="300" ></asp:DropDownList>            
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:gridview>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="cssButton"
        onclick="btnActualizar_Click" />
</asp:Content>
