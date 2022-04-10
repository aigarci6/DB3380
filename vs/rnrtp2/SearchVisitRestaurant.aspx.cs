using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Visit updated successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            //amount spent
            MySqlCommand updateSpending = new MySqlCommand("UPDATE visit_hotel SET amountSpent = @amountSpent WHERE tickID_h = @tickIDh AND hotID = @hotID;", dbcon);
            if (spent_textbox.Text.Length > 0)
            {
                updateSpending.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
                updateSpending.Parameters.AddWithValue("@tickIDh", rid_textbox.Text);
                updateSpending.Parameters.AddWithValue("@amountSpent", spent_textbox.Text);
            }

            dbcon.Open();
            if (spent_textbox.Text.Length > 0)
            {
                updateSpending.ExecuteNonQuery();
            }
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