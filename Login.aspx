<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            font-size: xx-large;
        }

        .auto-style3 {
            text-align: right;
            width: 117px;
        }

        #Reset1 {
            width: 70px;
        }
    </style>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style2">
            <strong>Login Page</strong>
        </p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Username:</td>
                <td>
                    <asp:TextBox ID="TextBoxloginUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxloginUserName" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Password:</td>
                <td>
                    <asp:TextBox ID="TextBoxloginPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxloginPassword" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <%--<div class="g-recaptcha" data-sitekey="6LdiPQcTAAAAADlqPnsuDx8Oco5Iu5GcAg-6bCpl"></div>
                    <asp:Label ID="Labelcaptcha" runat="server" ForeColor="Red"></asp:Label>--%>
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server"
                        PublicKey="6LdiPQcTAAAAADlqPnsuDx8Oco5Iu5GcAg-6bCpl"
                        PrivateKey="6LdiPQcTAAAAADXns-GlwhCViPy-f1fh8n8Uue5u" />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="height: 26px" Text="Submit" />
                    <input id="Reset1" type="reset" value="reset" /></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
