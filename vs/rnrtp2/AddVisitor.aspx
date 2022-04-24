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
                <label for="date">Date:</label>
                <input type="date" name="date" id="date" runat="server" value="" style="width:130px;" required="required"/> <br /><br />
                <label id="box1" for="ticket" >Ticket Type:</label>
                <select name="ticket" style="width:130px;" id="ticket" runat="server" required="required">
                    <option value="general">General</option>
                    <option value="seasonal">Seasonal</option>
                </select> <br /><br />
                <label for="email" >Email:</label>
                <input type="email" name="email" value="" runat="server" id="email" style="width:130px;" required="required"/>
                <br />
                <asp:Label ID="errormessage" font-size="small" runat="server" Text="ERROR SENDING EMAIL. TRY AGAIN." ForeColor="Red"></asp:Label> <br /><br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="buttonClick"  /> 
                <br /><br /><br />
           <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: white;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
           </fieldset>
            
        </div>
    </form>

</body>
</html>

