<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="rnrtp2.AddVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>add new visitor form</h1>
    <form id="form1" class="form" runat="server">
        <div>
<<<<<<< Updated upstream
            <asp:Label ID="Label1" runat="server" Text="Visit Date: "></asp:Label>
            <asp:TextBox ID="date_textbox" runat="server"></asp:TextBox> <br /><br />

            <asp:Label ID="Label5" runat="server" Text="Ticket Type: "></asp:Label>
            <asp:TextBox ID="type_textbox" runat="server"></asp:TextBox> <br /><br />

            <asp:Label ID="Label6" runat="server" Text="Customer Email: "></asp:Label>
            <asp:TextBox ID="email_textbox" runat="server"></asp:TextBox> <br /><br />

            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
=======
            <label for="date">Date:</label>
            <input type="date" name="date" id="date" runat="server" value="" required="required"/> <br />
            <label for="ticket">Ticket Type:</label>
            <select name="ticket" id="ticket" runat="server" required="required">
                <option value="general">General</option>
                <option value="seasonal">Seasonal</option>
            </select> <br />
            <label for="email">Email:</label>
            <input type="email" name="email" value="" runat="server" id="email" required="required"/> <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="buttonClick" />
            
>>>>>>> Stashed changes
        </div>
    </form>

    <script>
        /*const submit = document.querySelector('.form');
        submit.addEventListener('submit', (e) => {
            e.preventDefault();
            alert("in js right now");*/
    </script>
</body>
</html>