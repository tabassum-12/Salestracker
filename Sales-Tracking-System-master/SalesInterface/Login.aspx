<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link href="Stylesheets/Main.css" rel="stylesheet" />
    <link href="Stylesheets/Login.css" rel="stylesheet" />
</head>

<body>
    <div class="header">
        <h1><i>Sales Tracking System</i></h1>
    </div>

    <form id="form1" runat="server">
        <div id="main">
            <div id="loginForm">
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow>
                        <asp:TableCell CssClass ="loginCell">
                            <asp:Label ID="userNameLabel" runat="server" Text="Username "></asp:Label>
                            <asp:TextBox ID="userNameBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="userNameValidator" runat="server" ErrorMessage="" ControlToValidate="userNameBox"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="loginCell">
                            <asp:Label ID="passwordLabel" runat="server" Text="Password "></asp:Label>
                            <asp:TextBox TextMode="Password" ID="passwordBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="" ControlToValidate="passwordBox"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="loginCell">
                            <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" /><br /><br />
                            <asp:Label ID="errorLabel" runat="server" CssClass="error" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
    </form>
</body>
</html>
