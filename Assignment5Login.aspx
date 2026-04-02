<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assignment5Login.aspx.cs" Inherits="Assignment5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 32%;
            border:black solid 2px;
            height: 195px;
        }
        .divstyle{
            align-items:center;
        }
        .auto-style2 {
            width: 163px;
        }
        .auto-style3 {
            width: 201px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
    <div class="divstyle">\
        <br />
        <br />
        <h1>Welcome To Sam's Grocery Shop</h1>
         <br />
         <br />
        <h3>Log In</h3>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                </td>
                <td class="auto-style3">
                    <br />
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="auto-style3">
                    <br />
                    <asp:TextBox ID="txtPW" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblLogin" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="88px" OnClick="btnLogin_Click" />
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
