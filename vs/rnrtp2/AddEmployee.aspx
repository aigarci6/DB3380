<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="rnrtp2.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title>add a new employee</title>
</head>
<body id="employee">
    <h1><font color="black">new employee form</font></h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="First name: "></asp:Label>
                <asp:TextBox ID="first_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Last name: "></asp:Label>
                <asp:TextBox ID="last_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="email_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Gender: "></asp:Label>
                <select name="gender" style="width:130px;" id="gender" runat="server" required="required">
                    <option value="u">Other</option>
                    <option value="m">Male</option>
                    <option value="f">Female</option>
                    
                </select> <br /><br />



                <asp:Label ID="Label4" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                
                <asp:Label ID="Label5" runat="server" Text="Job Category: "></asp:Label>
                <select name="jsite" style="width:130px;" id="jsite" runat="server" required="required">
                    <option value="HR">HR</option>
                    <option value="hotel">Hotel</option>
                    <option value="restaurant">Restaurant</option>
                    <option value="ride">Ride</option>
                </select> <br /><br />


                <asp:Label ID="Label8" runat="server" Text="Job ID: "></asp:Label>
                <asp:TextBox ID="jid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="Weekly salary: "></asp:Label>
                <asp:TextBox ID="salary_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

                <br /><br /><br />
            <asp:LinkButton ID="linkGoSomewhere" style="font-size: medium; font-family: FreeMono, monospace; color: white;" runat="server" OnClick="HomeLink" Text="GO BACK TO HOME"/>
            </fieldset>
        </div>
    </form>
</body>
</html>
