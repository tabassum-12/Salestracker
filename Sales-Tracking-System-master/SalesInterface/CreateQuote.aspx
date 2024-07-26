<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateQuote.aspx.cs" Inherits="CreateQuote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Tracking System</title>
    <link rel="stylesheet" type="text/css" href="Stylesheets/Main.css" />
    <link rel="stylesheet" type="text/css" href="Stylesheets/CreateQuote.css" />
</head>

<body>
    <div class="header">
        <h1><i>Sales Tracking System</i></h1>
    </div>
    <form id="form1" runat="server">
        <div id="main">
            <div id="custTableDiv">
                <asp:Table ID="custInfoTable" runat="server">
                    <asp:TableRow>
                        <asp:TableCell cssclass="tableData"><b>
                            <asp:Label ID="custNameHeader" runat="server" Text="Customer Name"></asp:Label></b>
                        </asp:TableCell>
                        <asp:TableCell cssclass="tableData"><b>
                            <asp:Label ID="custAddressHeader" runat="server" Text="Customer Address"></asp:Label></b>
                        </asp:TableCell>
                        <asp:TableCell cssclass="tableData"><b>
                            <asp:Label ID="custContactHeader" runat="server" Text="Customer Contact"></asp:Label></b>
                        </asp:TableCell>
                    </asp:TableRow> 
                    <asp:TableRow> 
                        <asp:TableCell cssclass="tableData">
                            <asp:Label ID="custNameLabel" runat="server" Text=""></asp:Label>&emsp;&emsp;
                        </asp:TableCell>
                        <asp:TableCell cssclass="tableData">
                            <asp:Label ID="custStreetLabel" runat="server" Text=""></asp:Label>
                            , 
                            <asp:Label ID="custCityLabel" runat="server" Text=""></asp:Label>&emsp;&emsp;
                        </asp:TableCell>
                        <asp:TableCell cssclass="tableData">
                            <asp:Label ID="custContactLabel" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow> 
                </asp:Table>
            </div>
            <br /><br />

            <div id="quoteForm">
                <div id="infoEntry">
                    <asp:Label ID="quoteNameLabel" runat="server" Text="Quote Name"></asp:Label><br />
                    <asp:RequiredFieldValidator ID="quoteNameValidator" runat="server" ErrorMessage="" ControlToValidate="quoteNameBox" ValidationGroup="submitQuote"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="quoteNameBox" class="infoBox" runat="server" ValidationGroup="submitQuote"></asp:TextBox><br /><br />
                    <asp:Label ID="emailLabel" runat="server" Text="Customer Email"></asp:Label><br />
                    <asp:RequiredFieldValidator ID="emailValidator" runat="server" ErrorMessage="" ControlToValidate="emailBox" ValidationGroup="submitQuote"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="emailBox" class="infoBox" runat="server" ValidationGroup="submitQuote"></asp:TextBox><br /><br />
                    <asp:Label ID="discountLabel" runat="server" Text="Discount"></asp:Label><br />
                    <asp:TextBox ID="discountBox" class="infoBox" runat="server"></asp:TextBox><br /><br />
                    <br />
                    <asp:Label ID="noteLabel" runat="server" Text="Notes"></asp:Label><br />
                    <asp:TextBox ID="noteBox1" class="noteBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="noteBox2" class="noteBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="noteBox3" class="noteBox" runat="server"></asp:TextBox><br /><br />
                    &emsp;
                    
                </div>

                <div id="priceEntry">
                    <asp:Label ID="priceLabel" runat="server" Text="Price"></asp:Label><br />
                    <asp:TextBox ID="priceBox1" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox2" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox3" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox4" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox5" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox6" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox7" class="priceBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="priceBox8" class="priceBox" runat="server"></asp:TextBox><br /><br />
                </div>

                <div id="itemEntry">
                    <asp:Label ID="itemLabel" runat="server" Text="Quote Items"></asp:Label><br />
                    <asp:TextBox ID="itemBox1" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox2" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox3" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox4" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox5" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox6" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox7" class="itemBox" runat="server"></asp:TextBox><br /><br />
                    <asp:TextBox ID="itemBox8" class="itemBox" runat="server"></asp:TextBox><br /><br />
                </div>
            
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />
                <br /><br /><br />

                <div id="menuDiv">
                    <asp:Button ID="logoutButton" runat="server" Text="Log out" onclick="logoutButton_Click"/>&emsp;
                    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
                    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" ValidationGroup="submitQuote"/>
                    <asp:Label ID="errorLabel" runat="server" Text="" CssClass="error"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
