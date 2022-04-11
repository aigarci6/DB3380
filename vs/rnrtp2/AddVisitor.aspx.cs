using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddVisitor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Inserted successfully!')</script>");
            }
        }

        protected void buttonClick(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitor(@p_visitDate, @p_month, @p_day, @p_year, @p_ticketType, @p_ticketCost, @p_email);", dbcon);
            insert.Parameters.AddWithValue("@p_visitDate", date.Value);
            insert.Parameters.AddWithValue("@p_ticketType", ticket.Value);
            insert.Parameters.AddWithValue("@p_email", email.Value);//*/

            //get ticket cost
            if (ticket.Value == "general")
            {
                insert.Parameters.AddWithValue("@p_ticketCost", 150);
            }
            else if (ticket.Value == "seasonal")
            {
                insert.Parameters.AddWithValue("@p_ticketCost", 350);
            }

            //parse date
            string str = date.Value;
            string[] dates = str.Split('-');

            insert.Parameters.AddWithValue("@p_year", dates[0]);
            insert.Parameters.AddWithValue("@p_month", dates[1]);
            insert.Parameters.AddWithValue("@p_day", dates[2]);

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                date.Value = "";
                ticket.Value = "";
                email.Value = "";
            }
        }
    }
}