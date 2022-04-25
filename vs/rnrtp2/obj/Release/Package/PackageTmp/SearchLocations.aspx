<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLocations.aspx.cs" Inherits="rnrtp2.SearchLocations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title>manage locations</title>

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
<body id="SearchLocations">
    <h1><font color="black">manage locations</font></h1>
    <form id="form1" runat="server">
        <div>
            
            <fieldset>
            <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:130px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="id">Location ID</option>
                <option value="name">Location Name</option>
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr>
                <td> location id </td>
                <td> location name </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h1>Update:</h1>
                <h3>location information</h3>
                <asp:Label ID="Label1" runat="server" Text="Location ID: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> <br />
                <asp:Label ID="errormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

                <h3>update</h3>
                <asp:Label ID="Label2" runat="server" Text="Location Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
                <br /><br /><br />
                <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
