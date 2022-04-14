<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLocations.aspx.cs" Inherits="rnrtp2.SearchLocations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="SearchLocations">
    <h1>manage locations</h1>
    <form id="form1" runat="server">
        <div>
            
            <fieldset>
                <!-- SEARCH -->
                <h1>Search By:</h1>
                <asp:Label ID="Label3" runat="server" Text="Location ID: "></asp:Label><br />
                <asp:TextBox ID="sid_textbox" runat="server"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Location Name: "></asp:Label><br />
                <asp:TextBox ID="sname_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" />
            <table width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA">
            <tr align="left" style="background-color: #004080; color: White;">
                <td> location id </td>
                <td> location name </td>
                </tr>

                <% Response.Write(getData()); %>
            </table>
            <br />

            <!-- UPDATE -->
                <h1>Update:</h1><br />
                <h3>location information</h3>
                <asp:Label ID="Label1" runat="server" Text="Location ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />

                <h3>update</h3>
                <asp:Label ID="Label2" runat="server" Text="Location Name: "></asp:Label>
                <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            </fieldset>
        </div>
    </form>
</body>
</html>
