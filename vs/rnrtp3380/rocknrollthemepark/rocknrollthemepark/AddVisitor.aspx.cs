using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rocknrollthemepark
{
    public partial class AddVisitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Button1.Text = "Submitted!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitor(@ticketID, @visitDate, @month, @day, @year, @ticketType, @ticketCost);", dbcon);
            insert.Parameters.AddWithValue("@ticketID", id_textbox.Text);
            insert.Parameters.AddWithValue("@visitDate", date_textbox.Text);
            insert.Parameters.AddWithValue("@ticketType", type_textbox.Text);

            //get ticket cost (have to add cost to function)
            if (type_textbox.Text == "General" || type_textbox.Text == "general")
            {
                insert.Parameters.AddWithValue("@ticketCost", 150);
            }

            if (type_textbox.Text == "Seasonal" || type_textbox.Text == "seasonal")
            {
                insert.Parameters.AddWithValue("@ticketCost", 350);
            }

            //parse date
            string str = date_textbox.Text;
            string[] date = str.Split('-');

            insert.Parameters.AddWithValue("@year", date[0]);
            insert.Parameters.AddWithValue("@month", date[1]);
            insert.Parameters.AddWithValue("@day", date[2]);

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                date_textbox.Text = "";
                type_textbox.Text = "";
            }
        }
    }
}