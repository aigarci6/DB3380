<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="rnrtp2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                    <td><asp:TextBox ID="username_textbox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="pass_textbox" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="errormessage" runat="server" Text="Incorrect user credentials!" ForeColor="Red"></asp:Label></td>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
