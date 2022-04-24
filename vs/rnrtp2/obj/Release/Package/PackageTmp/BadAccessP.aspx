<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BadAccessP.aspx.cs" Inherits="rnrtp2.BadAccessP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title>BAD ACCESS</title>
</head>
<body>
    <div class="badaccess">
        <div class="badaccesstext">
            <h1 style="color: red;">BAD ACCESS:</h1><h2>You do not have access to this page.</h2>
            <h2><a href="Index.aspx" style="font-size: medium; color: black;">GO BACK TO HOME</a></h2>
        </div>
    </div>
    <form id="form1" runat="server">
    <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
    </form>
</body>
</html>
