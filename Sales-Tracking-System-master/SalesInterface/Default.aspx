<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Tracking System</title>
    <link rel="stylesheet" type="text/css" href="Stylesheets/Main.css" />
    <link rel="stylesheet" type="text/css" href="Stylesheets/Default.css" />
</head>
<body>
    <div class="header">
        <h1><i>Sales Tracking System</i></h1>
    </div>

    <form id="form1" runat="server">
        <div id="main">
            <div id="selectCustomerForm">
                <asp:Label ID="selectCustomerLabel" runat="server" Text="Select a customer"></asp:Label>
                <br />
                <asp:DropDownList ID="custNameBox" runat="server" DataValueField="id" DataTextField="name" AppendDataBoundItems="true" ValidationGroup="customerSelect">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:button ID="selectCustomerButton" runat="server" text="Select" onclick="selectCustomerButton_Click"  ValidationGroup="customerSelect"/>
                <br />
                <br />
                <asp:RequiredFieldValidator ID="selectCustomerValidator" runat="server" ErrorMessage="" ControlToValidate="custNameBox" ValidationGroup="customerSelect"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="logoutButton" runat="server" Text="Log out" onclick="logoutButton_Click"/>
                <br />
            </div>
        </div>
    </form>
</body>
</html>

