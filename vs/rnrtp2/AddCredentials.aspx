<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCredentials.aspx.cs" Inherits="rnrtp2.AddCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>create credentials</title>

    <style>
        #addCred {
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
            text-align: center;
            padding-top: 5%;
            font-size: 23px;
            color: white;
        }   
    </style>
</head>
<body id ="addCred">
    <form id="form1" runat="server">
        <div>
            <h1 style="color:black;">create new credentials</h1>
            <fieldset>
            <asp:Label ID="Label1" runat="server" Text="Employee ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="user_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="pass_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />

            <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="color:black; font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
