<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacionEnProceso.aspx.cs" Inherits="AppWeb.frmCotizacionEnProceso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    .botoneslink
    {
        text-decoration:none;
        font-weight:bold;
        }
    .modalcss {
          background: black;
          opacity:0.7;
          
        }  
    .bordemodal 
        {
            padding:10px;
            border:2px solid Black;
            background-color:White;
            
        }    
                        
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ToolkitScriptManager ID="tool1" runat="server"></asp:ToolkitScriptManager>
<div class="cssTituloPagina">Cotizaciones en Proceso</div>

<div>
    <table width="100%">
        <tr>
            <td align="left">&nbsp;
            </td>
            <td align="right"><asp:LinkButton ID="linkfiltrar" runat="server" Text="FILTRAR" CssClass="botoneslink" ></asp:LinkButton></td>
        </tr>
    </table>
</div>

<div id="divfiltrar" class="bordemodal">
        <asp:UpdatePanel ID="updfiltrar2" runat="server" >
        <ContentTemplate>
        
            <table>
                <tr>
                    <td colspan="4" align="right"><asp:LinkButton ID="lnkfiltrocerrar" runat="server" 
                            CssClass="botoneslink" onclick="lnkfiltrocerrar_Click">[X]</asp:LinkButton></td>
                </tr>
                <tr>
                    <td>Columna</td>
                    <td>Condicion</td>
                    <td>Valor</td>
                    <td>&nbsp;</td>                    
                </tr>
                <tr>
                    <td><asp:DropDownList ID="ddlfiltrar" runat="server" Width="150px" 
                            AutoPostBack="True" onselectedindexchanged="ddlfiltrar_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlcondiciones" runat="server" Width="150px"></asp:DropDownList></td>
                    <td><asp:TextBox ID="txtfiltrar" runat="server" Width="100px"></asp:TextBox><asp:DropDownList ID="ddlfiltrarlistado" runat="server" Width="100px" Visible="false"></asp:DropDownList></td>
                    <td><asp:LinkButton ID="lnkfiltrar" runat="server" Text="Agregar" 
                            onclick="lnkfiltrar_Click" CssClass="botoneslink"></asp:LinkButton></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>                    
                    <td><asp:CheckBox ID="chkfiltromodal" runat="server" Text="Ver listado" 
                            AutoPostBack="True" oncheckedchanged="chkfiltromodal_CheckedChanged" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ListBox ID="lstfiltrar" runat="server" Width="500px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center"><asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:LinkButton ID="lnkaceptarfiltro" runat="server" Text="Aceptar" 
                            onclick="lnkaceptarfiltro_Click" CssClass="botoneslink"></asp:LinkButton></td>
                    <td colspan="2">&nbsp;</td>
                    <td><asp:LinkButton ID="lnkcancelarfiltro" runat="server" Text="Limpiar" 
                            CssClass="botoneslink" onclick="lnkcancelarfiltro_Click"></asp:LinkButton></td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkfiltrar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lnkcancelarfiltro" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ddlfiltrar" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="chkfiltromodal" 
                    EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
<asp:UpdatePanel ID="updfiltrar" runat="server">
    <ContentTemplate>
<asp:gridview id="gvCotizaciones" runat="server" 
        autogeneratecolumns="False"
        CssClass="gridview"
        PagerStyle-CssClass="gridview_pager" 
        AlternatingRowStyle-CssClass="gridview_alter"
        OnRowCommand="gvCotizaciones_RowCommand" 

>
     <AlternatingRowStyle CssClass="gridview_alter"></AlternatingRowStyle>
    <Columns>
        <asp:BoundField ReadOnly="True" DataField="IdCotizacion" HeaderText="Cotización" ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="FechaCotizacion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-Width="80px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="DescripcionCotizacion" HeaderText="Descripción" ItemStyle-Width="400px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="CodMoneda" HeaderText="Mon" ItemStyle-Width="30px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreEstado" HeaderText="Estado" ItemStyle-Width="50px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="IdPedido" HeaderText="Pedido" ItemStyle-Width="60px"></asp:BoundField>
        <asp:BoundField ReadOnly="True" DataField="NombreProyecto" HeaderText="Proyecto" ItemStyle-Width="350px" />
        <asp:BoundField ReadOnly="True" DataField="NombreSede" HeaderText="Sede" ItemStyle-Width="150px" />
        <asp:BoundField ReadOnly="True" DataField="NombreUsuarioSolicitante" HeaderText="Solicitante" ItemStyle-Width="200px"></asp:BoundField>

        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnVerCotizacion" runat="server" Text="Ver Cotización" CssClass="cssButton" 
                    CausesValidation="False" 
                    CommandName="Seleccionar" 
                    CommandArgument = '<%# Bind("IdCotizacion") %>'
                />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
<PagerStyle CssClass="gridview_pager"></PagerStyle>
</asp:gridview> 
</ContentTemplate>
    </asp:UpdatePanel>
<asp:TextBox ID="txtIdUsuario" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtIdCotizacion" runat="server" Visible="false"></asp:TextBox>
<asp:ModalPopupExtender ID="modalfiltrar" runat="server" TargetControlID="linkfiltrar" PopupControlID="divfiltrar" BackgroundCssClass="modalcss" CancelControlID="lnkfiltrocerrar"></asp:ModalPopupExtender>
</asp:Content>
