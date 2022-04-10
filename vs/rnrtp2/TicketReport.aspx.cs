using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace rnrtp2
{
    public partial class TicketReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand cmd = new MySqlCommand("SELECT ticketID, visitDate, ticketType, ticketCost, email FROM visitor WHERE ticketType = @ticketType;", dbcon);
            cmd.Parameters.AddWithValue("@ticketType", type_textbox.Text);

            string htmlStr = "";

            dbcon.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string date = reader.GetString(1);
                string type = reader.GetString(2);
                int cost = reader.GetInt32(3);
                string email = reader.GetString(4);

                htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + type + "</td><td>" + cost + "</td><td>" + email + "</td></tr>";
            }

            dbcon.Close();
            return htmlStr;
        }
    }
}