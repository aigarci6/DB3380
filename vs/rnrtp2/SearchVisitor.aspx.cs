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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && date_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                //location
                MySqlCommand updateTicketType = new MySqlCommand("UPDATE visitor SET ticketType = @type, ticketCost = @cost WHERE ticketID = @id AND visitDate = @date;", dbcon);
                if (type_textbox.Text.Length > 0)
                {
                    updateTicketType.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateTicketType.Parameters.AddWithValue("@date", date_textbox.Text);

                    if (type_textbox.Text == "Seasonal" || type_textbox.Text == "seasonal")
                    {
                        updateTicketType.Parameters.AddWithValue("@type", "seasonal");
                        updateTicketType.Parameters.AddWithValue("@cost", 350);
                    }

                    if (type_textbox.Text == "General" || type_textbox.Text == "general")
                    {
                        updateTicketType.Parameters.AddWithValue("@type", "general");
                        updateTicketType.Parameters.AddWithValue("@cost", 150);
                    }
                }

                //email
                MySqlCommand updateEmail = new MySqlCommand("UPDATE visitor SET email = @email WHERE ticketID = @id AND visitDate = @date;", dbcon);
                if (email_textbox.Text.Length > 0)
                {
                    updateEmail.Parameters.AddWithValue("@id", id_textbox.Text);
                    updateEmail.Parameters.AddWithValue("@date", date_textbox.Text);
                    updateEmail.Parameters.AddWithValue("@email", email_textbox.Text);
                }

                dbcon.Open();
                if (type_textbox.Text.Length > 0)
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
                    date_textbox.Text = "";
                    type_textbox.Text = "";
                    email_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Button1.Text = "Updated!";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int id;
            DateTime getdate;
            string date;
            string type;
            double cost;
            string email;
            string htmlStr = "";

            dbcon.Open();

            //auto (all)
            if (search.Value == "none")
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
    }
}