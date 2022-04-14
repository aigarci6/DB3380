<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="rnrtp2.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CCSMAIN.css"/>
    <title></title>
</head>
<body id="employee">
    <h1><font color="black">new employee form</font></h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <asp:Label ID="Label1" runat="server" Text="First name: "></asp:Label><br />
                <asp:TextBox ID="first_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Last name: "></asp:Label><br />
                <asp:TextBox ID="last_textbox" runat="server" required="required"></asp:TextBox><br /><br />

                <asp:Label ID="Label3" runat="server" Text="Gender: "></asp:Label><br />
                <select name="gender" style="width:205px;" id="gender" runat="server" required="required">
                    <option value="u">Other</option>
                    <option value="m">Male</option>
                    <option value="f">Female</option>
                    
                </select> <br /><br />
                <!-- <asp:TextBox ID="gender_textbox" placeholder ="m/f/u" runat="server"></asp:TextBox><br /><br /> -->



                <asp:Label ID="Label4" runat="server" Text="ID: "></asp:Label><br />
                <asp:TextBox ID="id_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                
                <!--
                <asp:TextBox ID="jsite_textbox" runat="server"></asp:TextBox><br /><br />
                -->
                <asp:Label ID="Label5" runat="server" Text="Job Category: "></asp:Label><br />
                <select name="jsite" style="width:205px;" id="jsite" runat="server" required="required">
                    <option value="HR">HR</option>
                    <option value="hotel">Hotel</option>
                    <option value="restaurant">Restaurant</option>
                    <option value="ride">Ride</option>
                </select> <br /><br />


                <asp:Label ID="Label8" runat="server" Text="Job ID: "></asp:Label><br />
                <asp:TextBox ID="jid_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Label ID="Label7" runat="server" Text="Weekly salary: "></asp:Label><br />
                <asp:TextBox ID="salary_textbox" runat="server" required="required"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </fieldset>
        </div>
    </form>
</body>
</html>
