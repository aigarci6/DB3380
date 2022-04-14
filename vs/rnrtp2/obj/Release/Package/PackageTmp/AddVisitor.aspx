<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="rnrtp2.AddVisitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>add a new visitor</title>
</head>
<body id="Visitor">
    <h1><font color="white">new visitor form</font></h1>
    <form id="form1" class="form" runat="server">
        <div>
            <fieldset>
                <label for="date">Date:</label><br />
                <input type="date" name="date" id="date" runat="server" value="" style="width:200px;" required="required"/> <br /><br />
                <label id="box1" for="ticket" >Ticket Type:</label><br />
                <select name="ticket" style="width:205px;" id="ticket" runat="server" required="required">
                    <option value="general">General</option>
                    <option value="seasonal">Seasonal</option>
                </select> <br /><br />
                <label for="email" >Email:</label><br />
                <input type="email" name="email" value="" runat="server" id="email" style="width:197px;" required="required"/> <br /><br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="buttonClick"  /> 
                <br /><br /><br />
            <a href="Index.aspx" style="font-size: medium; font-family: FreeMono, monospace; color: white;">GO BACK TO HOME</a>
           </fieldset>
            
        </div>
    </form>

</body>
</html>

