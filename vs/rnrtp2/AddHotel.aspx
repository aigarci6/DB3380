<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="rnrtp2.AddHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css">
    <title></title>
</head>
<body id="hotel">
    <h1>add new hotel form</h1>
    <form id="form1" runat="server">

         <h1 class="row">Add Hotel</h1>
        <form action="">
            <fieldset>
                <label for="id">ID:</label>
                <input type="number" name="id" id="id" required class="row"><br>
                <label for="name">Name:</label>
                <input type="text" name="name" id="name" required class="row"><br>
                <label for="location">Location:</label>
                <input type="text" name="location" id="location" required class="row"><br>
                <label for="capacity">Capacity:</label>
                <input type="number" name="capacity" id="capacity" required class="row"><br>
                <button class="row">Submit</button><br>
                <a href="index.html" class="row">Back to Index Page</a>
            </fieldset>
        </form>








        <div>
            <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
            <asp:TextBox ID="id_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="name_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label3" runat="server" Text="Capacity: "></asp:Label>
            <asp:TextBox ID="capacity_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label4" runat="server" Text="Location: "></asp:Label>
            <asp:TextBox ID="location_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label5" runat="server" Text="Rating: "></asp:Label>
            <asp:TextBox ID="rating_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label6" runat="server" Text="Pets allowed? "></asp:Label>
            <asp:TextBox ID="pets_textbox" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
