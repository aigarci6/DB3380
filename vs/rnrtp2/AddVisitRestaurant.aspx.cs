using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddVisitRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Restaurant visit added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitRestaurant(@ticketIDr, @restID, @amountSpent);", dbcon);
            insert.Parameters.AddWithValue("@ticketIDr", id_textbox.Text);
            insert.Parameters.AddWithValue("@restID", rid_textbox.Text);

            if (spent_textbox.Text.Length > 0)
            {
                insert.Parameters.AddWithValue("@amountSpent", spent_textbox.Text);
            }
            else
            {
                insert.Parameters.AddWithValue("@amountSpent", 0);
            }

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                rid_textbox.Text = "";
                spent_textbox.Text = "";
            }
        }
    }
}