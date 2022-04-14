using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Hotel added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertHotel(@hotelID, @name, @h_locID, @capacity, @rating, @exp);", dbcon);
            insert.Parameters.AddWithValue("@hotelID", id_textbox.Text);
            insert.Parameters.AddWithValue("@name", name_textbox.Text);
            insert.Parameters.AddWithValue("@h_locID", location_textbox.Text);
            insert.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
            insert.Parameters.AddWithValue("@rating", rating_textbox.Text);

            if (exp_textbox.Text.Length > 0)
            {
                insert.Parameters.AddWithValue("@exp", exp_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@exp", 0);
            }
            
            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                name_textbox.Text = "";
                location_textbox.Text = "";
                capacity_textbox.Text = "";
                rating_textbox.Text = "";
                exp_textbox.Text = "";
            }
        }
    }
}