<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Billing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 31%;
            border:black solid 2px;
        }
        .auto-style2 {
            width: 410px;
        }
        .auto-style3 {
            width: 301px;
        }
        .auto-style4 {
            width: 25%;
            height: 196px;
             border:black solid 2px;
        }
        .auto-style7 {
            height: 22px;
            width: 109px;
        }
        .auto-style9 {
            height: 23px;
            width: 109px;
        }
        .auto-style12 {
            width: 109px;
        }
        .auto-style13 {
            width: 171px;
        }
        .auto-style14 {
            height: 23px;
            width: 171px;
        }
        .auto-style15 {
            height: 22px;
            width: 171px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <center>
    <div>
    
        <br />
        <h1>Billings</h1>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Assignment5Login.aspx">LogOut</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
&nbsp;&nbsp; &nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GroceryInventory.aspx">Grocery Inventory</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CustomerDetails.aspx">Customer Details</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Reports.aspx">Reports</asp:HyperLink>
        <br />
        <br />
        <h2>* Generate Your Bill *</h2>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <br />
                    <asp:DropDownList ID="CustDrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CustDrop_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <br />
                    <asp:DropDownList ID="ProdDrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProdDrop_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td class="auto-style2">
                    <br />
                    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <br />
                    <asp:Label ID="lblBillRes" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnGenerateBill" runat="server" Text="Generate Bill" OnClick="btnGenerateBill_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
    
        <br />
        <br />
        <br />
        <div id="bill" runat="server">
            <h2>* Bill Generated *</h2>
            <br />
            <table class="auto-style4">
                <tr>
                    <td class="auto-style13">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>
                        <asp:Label ID="Label5" runat="server" Text="Bill No"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblBillNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        &nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>
                        <asp:Label ID="Label7" runat="server" Text="Customer Name"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblCustName" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>
                        <asp:Label ID="Label10" runat="server" Text="Product Name"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblProdName" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>
                        <asp:Label ID="Label14" runat="server" Text="Quantity"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="lblQty" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                        <asp:Label ID="Label9" runat="server" Text="Price per item"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="lblPricepp" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <strong>
                        <asp:Label ID="Label13" runat="server" Text="Total Price"></asp:Label>
                        </strong>
                        <br />
                        <br />
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>

        </div>
    
    </div>
             </center>
    </form>
</body>
</html>
