<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuoteSubmit.aspx.cs" Inherits="QuoteSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Tracking System</title>
    <link href="Stylesheets/Main.css" rel="stylesheet" />
    <link href="Stylesheets/QuoteSubmit.css" rel="stylesheet" />
</head>
<body>
    <div class="header">
        <h1><i>Sales Tracking System</i></h1>
    </div>

    <form id="form1" runat="server">
    <div id="main">
        <div id="tableDiv">
            <asp:Table id="quoteSubmitTable" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        Your quote has been submitted.
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="logoutButton" runat="server" Text="Log out" onClick="logoutButton_Click"/>&emsp;
                        <asp:Button ID="homeButton" runat="server" Text="Create a new Quote" onClick="homeButton_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    </form>
</body>
</html>
