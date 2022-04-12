<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="rnrtp2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id ="Login">
    <form id="form1" runat="server">
        <div>
            
            <fieldset1>
            <table id="Table" >
                <h2><font color="black"> Member Login </font></h2>
                <tr>
                    
                    <td><asp:TextBox ID="username_textbox" runat="server" placeholder="USERNAME" BackColor="#f5f5f5" Height="25"  style="Font-Size:15px;" ></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td><asp:TextBox ID="pass_textbox" runat="server" TextMode="Password" placeholder="PASSWORD" BackColor="#f5f5f5" Height="25" style="Font-Size:15px;" ></asp:TextBox></td>
                </tr>
                <fieldset2>
                <tr>
                   
                    
                    <td><asp:Button ID="Button1" runat="server" Text="Login" ForeColor="White" Font-Size:15 BackColor="#00bb00"  Height="30" OnClick="Button1_Click" Width="200"  /></td>
                </tr>
                </fieldset2>
                </fieldset1>
                <tr>
                    <td></td>
                    <td><asp:Label ID="errormessage" runat="server" Text="Incorrect user credentials!" ForeColor="Red"></asp:Label></td>
                </tr>
                
            </table>
            
            
        </div>
    </form>
</body>
</html>
