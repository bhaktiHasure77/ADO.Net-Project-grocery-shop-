<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillingReport.aspx.cs" Inherits="BillingReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
    <div>
    
        <br />
        <br />
        <h1>Bill Report</h1>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Assignment5Login.aspx">LogOut</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GroceryReport.aspx">Grocery Inventory Report</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CustomerReport.aspx">Customer Details Report</asp:HyperLink>
    
        &nbsp;&nbsp;
        <br />
    
        <br />
    
        <br />
    
        <br />
        <asp:GridView ID="gridBilling" runat="server">
        </asp:GridView>
    
    </div>
            </center>
    </form>
</body>
</html>
