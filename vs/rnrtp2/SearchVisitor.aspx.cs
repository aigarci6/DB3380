using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory != "HR" && jcategory != "hotel" && jcategory != "ride" && jcategory != "restaurant")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            

            errormessage.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && date.Value.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //type
                MySqlCommand updateTicketType = new MySqlCommand("UPDATE visitor SET ticketType = @type, ticketCost = @cost WHERE ticketID = @id AND visitDate = @date;", dbcon);
                if (ticket.Value != "select")
                {
                    updateTicketType.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateTicketType.Parameters.AddWithValue("@date", date.Value);

                    if (ticket.Value == "seasonal")
                    {
                        updateTicketType.Parameters.AddWithValue("@type", ticket.Value);
                        updateTicketType.Parameters.AddWithValue("@cost", 200);
                    }

                    if (ticket.Value == "general")
                    {
                        updateTicketType.Parameters.AddWithValue("@type", ticket.Value);
                        updateTicketType.Parameters.AddWithValue("@cost", 50);
                    }
                }

                //email
                MySqlCommand updateEmail = new MySqlCommand("UPDATE visitor SET email = @email WHERE ticketID = @id AND visitDate = @date;", dbcon);
                if (email_textbox.Text.Length > 0)
                {
                    updateEmail.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateEmail.Parameters.AddWithValue("@date", date.Value);
                    updateEmail.Parameters.AddWithValue("@email", email_textbox.Text);
                }

                dbcon.Open();
                if (ticket.Value != "select")
                {
                    updateTicketType.ExecuteNonQuery();
                }
                if (email_textbox.Text.Length > 0)
                {
                    updateEmail.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    email_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Visitor updated successfully!')</script>");
                }
            }

            else
            {
                errormessage.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            int id;
            DateTime getdate;
            string date;
            string type;
            double cost;
            string email;
            string htmlStr = "";

            dbcon.Open();

            // none
            if (search.Value == "none")
            {

            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email FROM visitor ORDER BY ticketID ASC;", dbcon);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    getdate = sReader.GetDateTime(1);
                    date = getdate.ToString("yyyy-MM-dd");
                    type = sReader.GetString(2);
                    cost = sReader.GetDouble(3);
                    email = sReader.GetString(4);

                    htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
                }
                sReader.Close();
            }

            //visitor id
            if (search.Value == "vid" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email FROM visitor WHERE ticketID = @id ORDER BY ticketID ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    getdate = sReader.GetDateTime(1);
                    date = getdate.ToString("yyyy-MM-dd");
                    type = sReader.GetString(2);
                    cost = sReader.GetDouble(3);
                    email = sReader.GetString(4);

                    htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
                }
                sReader.Close();
            }

            //visitor id
            if (search.Value == "type" && field_textbox.Text.Length > 0)
            {
                if (field_textbox.Text.ToLower() == "general" || field_textbox.Text.ToLower() == "seasonal")
                {
                    MySqlCommand search = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email FROM visitor WHERE ticketType = @type ORDER BY ticketID ASC;", dbcon);
                    search.Parameters.AddWithValue("@type", field_textbox.Text.ToLower());

                    MySqlDataReader sReader = search.ExecuteReader();
                    while (sReader.Read())
                    {
                        id = sReader.GetInt32(0);
                        getdate = sReader.GetDateTime(1);
                        date = getdate.ToString("yyyy-MM-dd");
                        type = sReader.GetString(2);
                        cost = sReader.GetDouble(3);
                        email = sReader.GetString(4);

                        htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
                    }
                    sReader.Close();
                }
                
                else
                {
                    if (IsPostBack)
                    {
                        field_textbox.Text = "INVALID";
                    }
                    
                }
            }

            //year
            if (search.Value == "year" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email, year FROM visitor WHERE year = @year ORDER BY ticketID ASC;", dbcon);
                search.Parameters.AddWithValue("@year", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    getdate = sReader.GetDateTime(1);
                    date = getdate.ToString("yyyy-MM-dd");
                    type = sReader.GetString(2);
                    cost = sReader.GetDouble(3);
                    email = sReader.GetString(4);

                    htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
                }
                sReader.Close();
            }

            //month
            if (search.Value == "month" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email, month FROM visitor WHERE month = @month ORDER BY ticketID ASC;", dbcon);
                search.Parameters.AddWithValue("@month", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    getdate = sReader.GetDateTime(1);
                    date = getdate.ToString("yyyy-MM-dd");
                    type = sReader.GetString(2);
                    cost = sReader.GetDouble(3);
                    email = sReader.GetString(4);

                    htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td> $" + cost + "</td><td>" + email + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
        }

        protected void HomeLink(object sender, EventArgs e)
        {
            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if (jcategory == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if (jcategory == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if (jcategory == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}