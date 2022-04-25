<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchRide.aspx.cs" Inherits="rnrtp2.SearchRide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title>manage rides</title>

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
<body id="SearchRide">
    <h1><font color="black">manage rides</font></h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <!-- SEARCH -->
            <h1>Search By:</h1>
            <select name="search" style="width:130px;" id="search" runat="server">
                <option value="none"> </option>
                <option value="id">ID</option> 
                <option value="name">Name</option>
                <option value="location">Location ID</option>
                <option value="weight_greater">Max Weight Greater Than</option>
                <option value="weight_less">Max Weight Less Than</option>
                <option value="height_greater">Min Height Greater Than</option>
                <option value="height_less">Min Height Less Than</option>
                <option value="age_greater">Min Age Greater Than</option>
                <option value="age_less">Min Age Less Than</option>
                <option value="capacity_greater">Capacity Greater Than</option>
                <option value="capacity_less">Capacity Less Than</option>
                <option value="all">*</option>
            </select>
            <asp:TextBox ID="field_textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" /><br />
                <asp:CheckBox ID="archived" runat="server" Text ="include archived"/>
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#000" class="table">
            <tr>
                <td> ride id </td>
                <td> name </td>
                <td> capacity </td>
                <td> max weight </td>
                <td> min height </td>
                <td> min age </td>
                <td> location id </td>
                <td> location </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
            <h1>Update:</h1>
            <h3>ride information</h3>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList> <br /><br />
                <asp:Label ID="updateerrormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>

                <h3>update</h3>
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> <br /><br />

                <asp:Label ID="Label4" runat="server" Text="Capacity: "></asp:Label>
                <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Maximum Weight: "></asp:Label>
                <asp:TextBox ID="maxweight_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Minimum Height: "></asp:Label>
                <asp:TextBox ID="minheight_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="Minimum Age: "></asp:Label>
                <asp:TextBox ID="minage_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            <br />

            <!-- DELETE -->
            <h1>Delete:</h1>
                <asp:Label ID="Label8" runat="server" Text="Ride ID: "></asp:Label>
                <asp:TextBox ID="delete_id" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label9" runat="server" Text="Ride Name: "></asp:Label>
                <asp:TextBox ID="delete_name" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button3" runat="server" Text="Delete Ride" OnClick="Button3_Click"/><br />
                <asp:Label ID="deleteerrormessage" font-size="small" runat="server" Text="ERROR: Missing field(s)!" ForeColor="Red"></asp:Label>
                <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: black;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
