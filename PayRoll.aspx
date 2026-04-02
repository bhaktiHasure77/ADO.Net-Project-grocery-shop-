<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayRoll.aspx.cs" Inherits="PayRoll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblEmp" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblRes" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="Display" Width="151px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
