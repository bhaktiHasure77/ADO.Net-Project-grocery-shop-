<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerReport.aspx.cs" Inherits="CustomerReport" %>

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
        <div>
            <br />
            <h1>Customer Details Report</h1>
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Assignment5Login.aspx">LogOut</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GroceryReport.aspx">Grocery Inventory Report</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CustomerReport.aspx">Customer Details Report</asp:HyperLink>
            &nbsp;&nbsp; &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/BillingReport.aspx">Billing Report</asp:HyperLink>
            <br />
            <br />
            <br />
        </div>
        <br />
        <asp:GridView ID="gridCustomer" runat="server">
        </asp:GridView>
    
    </div>
   </center>
    </form>
</body>
</html>
