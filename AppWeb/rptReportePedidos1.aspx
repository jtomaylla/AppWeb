<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptReportePedidos1.aspx.cs" Inherits="AppWeb.rptReportePedidos1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <CR:CrystalReportViewer ID="crvReporte" runat="server" OnUnload="crvReporte_Unload" 
            AutoDataBind="true" HasCrystalLogo="False" oninit="crvReporte_Init" />
    
    </form>
</body>
</html>
