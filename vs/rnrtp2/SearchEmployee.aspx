<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="rnrtp2.SearchEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="SearchEmployee">
    <h1>manage employees</h1>
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
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" /><br />
                <asp:CheckBox ID="archived" runat="server" Text ="include archived"/>
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
                <h1>Update:</h1>
                <h3>employee information</h3>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label><br />
                <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label><br />
                <asp:TextBox ID="sfirst_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Label ID="Label10" runat="server" Text="Job Category: "></asp:Label><br />
                <!-- <asp:TextBox ID="sjsite_textbox" runat="server"></asp:TextBox><br /><br /> -->
                <select name="sjsite" style="width:205px;" id="sjsite" runat="server" required="required">
                    <option value="HR">HR</option>
                    <option value="hotel">Hotel</option>
                    <option value="restaurant">Restaurant</option>
                    <option value="ride">Ride</option>
                </select> <br /><br />

            <h3>update</h3>
                <asp:Label ID="Label9" runat="server" Text="First Name: "></asp:Label><br />
                <asp:TextBox ID="first_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Last Name: "></asp:Label><br />
                <asp:TextBox ID="last_textbox" runat="server"></asp:TextBox><br /><br />
                
                <asp:Label ID="Label5" runat="server" Text="Gender: "></asp:Label><br />
                <!-- <asp:TextBox ID="gender_textbox" runat="server"></asp:TextBox><br /><br /> -->
                <select name="gender" style="width:205px;" id="gender" runat="server" required="required">
                    <option value="u">Other</option>
                    <option value="m">Male</option>
                    <option value="f">Female</option>
                </select> <br /><br />
                
                <asp:Label ID="Label6" runat="server" Text="Weekly Salary: "></asp:Label><br />
                <asp:TextBox ID="salary_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label8" runat="server" Text="Job ID: "></asp:Label><br />
                <asp:TextBox ID="jid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /><br />

                <!-- DELETE -->
            <h1>Delete:</h1>
                <asp:Label ID="Label4" runat="server" Text="Employee ID: "></asp:Label><br />
                <asp:TextBox ID="delete_id" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="First Name: "></asp:Label><br />
                <asp:TextBox ID="delete_fname" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label11" runat="server" Text="Last Name: "></asp:Label><br />
                <asp:TextBox ID="delete_lname" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label12" runat="server" Text="Job ID: "></asp:Label><br />
                <asp:TextBox ID="delete_jid" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button3" runat="server" Text="Delete Employee" OnClick="Button3_Click"/>
            </fieldset>

        </div>
    </form>
</body>
</html>
