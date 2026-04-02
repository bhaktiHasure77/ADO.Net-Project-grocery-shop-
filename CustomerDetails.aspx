<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        
        .auto-style1 {
            width: 382px;
            height: 281px;
            border:black solid 2px;
        }
        .auto-style2 {
            width: 164px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    
    <div>
        <br />
    <h1>Customer Details</h1>
        <br />
          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Assignment5Login.aspx">LogOut</asp:HyperLink>
&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
&nbsp;&nbsp; &nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GroceryInventory.aspx">Grocery Inventory</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Billing.aspx">Billing</asp:HyperLink>
&nbsp;&nbsp; &nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Reports.aspx">Reports</asp:HyperLink>
            <br />
        <br />
        <h2>Manage Customers</h2>
        <br />
      
            <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Customer ID"></asp:Label>
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="CustIdDrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CustIdDrop_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMob" runat="server" TextMode="Phone"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="lblCust" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="79px" OnClick="btnAdd_Click" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="78px" OnClick="btnSave_Click" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="80px" OnClick="btnEdit_Click" />
                    <br />
                    <br />
                </td>
                <td>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="81px" OnClick="btnUpdate_Click" style="height: 26px" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>

    
    </div>
    
    </center>
    </form>
</body>
</html>
