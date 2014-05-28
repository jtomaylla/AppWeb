<%@ Page Title="Logis NET - Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AppWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<div class="cssTituloPagina">Menu Principal</div>

<table width="100%">
<tr>
<td style="width:350px" valign="top" >

<div class="cssTablaCabeceraRegistro">::Perfil/Función::</div>
<div class="cssTablaRegistro">

    <asp:TreeView ID="TreeView1" runat="server" 
        Width="345px" onselectednodechanged="TreeView1_SelectedNodeChanged" >
    </asp:TreeView>
  
</div>

</td>

<td valign="top" width="*">

<div class="cssTablaCabeceraRegistro">::Alertas::</div>
<div class="cssTablaRegistro">

<asp:gridview id="gvLista" 
        runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="FECHA_EVENTO" HeaderText="Fecha" ItemStyle-Width="80px" dataformatstring="{0:dd/MM/yyyy}" ></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NOMBRE_PROYECTO" HeaderText="Proyecto" ItemStyle-Width="200px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DE_LOGIN_USUARIO" HeaderText="De" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PARA_LOGIN_USUARIO" HeaderText="Para" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="ASUNTO" HeaderText="Asunto" ItemStyle-Width="350px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="PROCESO" HeaderText="Proceso" ItemStyle-Width="150px"></asp:BoundField>

    </Columns>
    </asp:gridview>

    
  
</div>

</td>
</tr>
</table>
    <asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
</asp:Content>
