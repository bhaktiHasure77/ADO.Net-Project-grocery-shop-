<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroceryInventory.aspx.cs" Inherits="GroceryInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
           margin-left:350px;
        }
        .auto-style1 {
            align-items:center;
            width: 47%;
            border:black solid 2px;
        }
        
        .auto-style2 {
            width: 128px;
        }
        </style>
</head>
<body style="width: 705px; height: 706px;">

    <form id="form1" runat="server">
        <div>
   <center>
        <div>
    
            <br />
            <h1>Grocery Inventory</h1>
            <p>&nbsp;</p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Assignment5Login.aspx">LogOut</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/CustomerDetails.aspx">Customer Details</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Billing.aspx">Billing</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Reports.aspx">Reports</asp:HyperLink>
            <br />
            <br />
            <h2>Manage Inventory</h2>
        
            <br />
      
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Product ID "></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:DropDownList ID="ProductIDdrop" runat="server" OnSelectedIndexChanged="ProductIDdrop_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtPName" runat="server" Width="112px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Product Price "></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtProdPrice" runat="server" Width="111px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Quantity "></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:TextBox ID="txtQnty" runat="server" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <br />
                    <asp:Label ID="lblInv" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="101px" OnClick="btnAdd_Click" />
                </td>
                <td>
                    &nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="105px" OnClick="btnSave_Click" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <br />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="100px" OnClick="btnEdit_Click" />
                </td>
                <td>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="102px" OnClick="btnUpdate_Click" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" Width="101px" OnClick="btnRemove_Click" />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    
    </div>
   </center>
            </div>
    </form>
</body>
</html>
