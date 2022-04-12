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
            
            <fieldset>
            <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="id">ID</option>
                <option value="first">First Name</option>
                <option value="last">Last Name</option>
                <option value="gender">Gender</option>
                <option value="sal_more">Salary: More Than</option>
                <option value="sal_less">Salary: Less Than</option>
                <option value="category">Job Category</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="50%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> employee id </td>
                <td> first name </td>
                <td> last name </td>
                <td> gender </td>
                <td> weekly salary </td>
                <td> job category </td>
                <td> job id </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h2>Employee information</h2>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="sfirst_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label10" runat="server" Text="Job Category: "></asp:Label>
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
