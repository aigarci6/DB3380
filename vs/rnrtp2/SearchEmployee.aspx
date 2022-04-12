<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="rnrtp2.SearchEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="SearchEmployee">
    <h1>Employee search </h1>
    <form id="form1" runat="server">
        <div>
            <h2>Employee information</h2>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="sfirst_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label10" runat="server" Text="Job Site Type: "></asp:Label>
                <asp:TextBox ID="sjsite_textbox" runat="server"></asp:TextBox><br /><br />

            <h2>Update information</h2>
                <asp:Label ID="Label9" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="first_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Last Name: "></asp:Label>
                <asp:TextBox ID="last_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Gender: "></asp:Label>
                <asp:TextBox ID="gender_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Weekly Salary: "></asp:Label>
                <asp:TextBox ID="salary_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label8" runat="server" Text="Job ID: "></asp:Label>
                <asp:TextBox ID="jid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />

            </fieldset>

        </div>
    </form>
</body>
</html>
