<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchVisitor.aspx.cs" Inherits="rnrtp2.SearchVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>

    <style>
        table {
            border-collapse: collapse;
        }

        tr {
            background-color: lightgray;
            text-align: left;
            color: #333;
            font-size:small;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }

        td {
            padding: 5px;
        }

        tr:first-child {
            background-color: lightblue;
            font-weight: bold;
            text-transform: uppercase;
            color: #333;
        }

        tr:nth-child(even) {
            background-color: #efefef;
        }
    </style>
</head>
<body id ="SearchVisitor">
    <h1>manage visitors</h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:120px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="vid">Ticket ID</option> 
                <option value="type">Ticket Type</option> 
                <option value="year">Visit Year</option>
                <option value="month">Visit Month</option>
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr>
                <td> ticket id </td>
                <td> visit date </td>
                <td> ticket type </td>
                <td> ticket cost </td>
                <td> email </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h1>Update:</h1>
                <h2>visitor information</h2>
                <asp:Label ID="Label1" runat="server" Text="Ticket ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Visit Date: "></asp:Label><br />
                <asp:TextBox ID="date_textbox" runat="server"></asp:TextBox><br />
                <asp:Label ID="errormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

                <h2>update</h2>
                <asp:Label ID="Label3" runat="server" Text="Ticket Type: "></asp:Label><br />
                <asp:TextBox ID="type_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label><br />
                <asp:TextBox ID="email_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: white;">GO BACK TO HOME</a>
            </fieldset>
        </div>
    </form>
</body>
</html>
