<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="rnrtp2.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>add new employee form</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="First name: "></asp:Label>
            <asp:TextBox ID="first_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Last name: "></asp:Label>
            <asp:TextBox ID="last_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Gender: "></asp:Label>
            <asp:TextBox ID="gender_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label5" runat="server" Text="Job category: "></asp:Label>
            <asp:TextBox ID="jcategory_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label6" runat="server" Text="Job Description: "></asp:Label>
            <asp:TextBox ID="jdesc_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label8" runat="server" Text="Job ID: "></asp:Label>
            <asp:TextBox ID="jid_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label7" runat="server" Text="Weekly salary: "></asp:Label>
            <asp:TextBox ID="salary_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
