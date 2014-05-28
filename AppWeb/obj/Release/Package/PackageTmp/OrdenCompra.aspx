<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenCompra.aspx.cs" Inherits="AppWeb.OrdenCompra" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orden de Compra</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        
        <CR:CrystalReportViewer ID="crvReporte" runat="server" 
            AutoDataBind="true" HasCrystalLogo="False" />
   
    </form>
</body>
</html>
