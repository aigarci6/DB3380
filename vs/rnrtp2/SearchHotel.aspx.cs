using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Button1.Text = "Updated!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            //location
            MySqlCommand updateLocation = new MySqlCommand("UPDATE hotel SET h_locID = @location WHERE hotelID = @id AND name = @name;", dbcon);
            if (location_textbox.Text.Length > 0)
            {
                updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
            }

            //capacity
            MySqlCommand updateCapacity = new MySqlCommand("UPDATE hotel SET capacity = @capacity WHERE hotelID = @id AND name = @name;", dbcon);
            if (capacity_textbox.Text.Length > 0)
            {
                updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
            }

            //rating
            MySqlCommand updateRating = new MySqlCommand("UPDATE hotel SET rating = @rating WHERE hotelID = @id AND name = @name;", dbcon);
            if (rating_textbox.Text.Length > 0)
            {
                updateRating.Parameters.AddWithValue("@id", id_textbox.Text);
                updateRating.Parameters.AddWithValue("@name", name_textbox.Text);
                updateRating.Parameters.AddWithValue("@rating", rating_textbox.Text);
            }


            dbcon.Open();
            if (location_textbox.Text.Length > 0)
            {
                updateLocation.ExecuteNonQuery();
            }
            if (capacity_textbox.Text.Length > 0)
            {
                updateCapacity.ExecuteNonQuery();
            }
            if (rating_textbox.Text.Length > 0)
            {
                updateRating.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                name_textbox.Text = "";
                location_textbox.Text = "";
                capacity_textbox.Text = "";
                rating_textbox.Text = "";
            }
        }
    }
}