<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="rnrtp2.AddVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="Visitor">
    <h1><font color="black">Add new visitor form</font></h1>
    <form id="form1" class="form" runat="server">
        <div>
            <fieldset>
                <label for="date">Date:</label>
                <input type="date" name="date" id="date" runat="server" value="" style="width:200px;" required="required"/> <br />
                <label id="box1" for="ticket" >Ticket Type:</label>
                <select name="ticket" style="width:205px;" id="ticket" runat="server" required="required">
                    <option value="general">General</option>
                    <option value="seasonal">Seasonal</option>
                </select> <br />
                <label for="email" >Email:</label>
                <input type="email" name="email" placeholder="Enter a valid Email" value="" runat="server" id="email" style="width:197px;" required="required"/> <br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="buttonClick"  /> 
           </fieldset>
            
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

