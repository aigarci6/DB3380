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

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM visitor;", dbcon);

            string htmlStr = "";

            dbcon.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string date = reader.GetString(1);
                string month = reader.GetString(2);
                string day = reader.GetString(3);
                string year = reader.GetString(4);
                string type = reader.GetString(5);
                int cost = reader.GetInt32(6);
                string email = reader.GetString(7);

                htmlStr += "<tr><td>" + id + "</td><td>" + date + "</td><td>" + month + "</td><td>" + day + "</td><td>" + year + "</td><td>" + type + "</td><td>" + cost + "</td><td>" + email + "</td></tr>";
            }

            dbcon.Close();
            return htmlStr;
        }
    }
}