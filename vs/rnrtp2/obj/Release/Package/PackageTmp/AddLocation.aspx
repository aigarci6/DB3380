<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="rnrtp2.AddLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="AddLocation">
    <form id="form1" runat="server">
        <div>
            <h1><font color="black">new location form</font></h1>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Location Name: " ></asp:Label><br />
                <asp:TextBox ID="name_textbox" runat="server" required="required"></asp:TextBox><br /><br />
            
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            </fieldset>
        </div>
    </form>
</body>
</html>
