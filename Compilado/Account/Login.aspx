<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="AppWeb.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 94%;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<table width="100%" align="left">
<tr>
	<td align="left" class="style1">
   
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false" onauthenticate="LoginUser_Authenticate">
        <LayoutTemplate>

            <div class="accountInfo">
                <br /><br /><br /><br />
                    <div class="cssTablaCabeceraRegistro"><center>Ingreso</center></div>
                    <div class="cssTablaRegistro">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                             CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                    </td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                             CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            
                                    </td>
                                </tr>
                            </table>
                        <p>
                            <asp:CheckBox ID="RememberMe" runat="server"/>
                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantenerme conectado</asp:Label>
                        </p>
                        <asp:Button ID="LoginButton" runat="server" CssClass="cssButton" CommandName="Login" Text="Iniciar sesión" ValidationGroup="LoginUserValidationGroup"/>

                    </div>
            </div>

    <p>
        Especifique su nombre de usuario y contraseña.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" Visible="false" EnableViewState="false">Registrarse</asp:HyperLink>
    </p>

            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>

            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

        </LayoutTemplate>
    </asp:Login>


    </td>
</tr>
</table>

</asp:Content>
