using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchRestaurant : System.Web.UI.Page
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
            MySqlCommand updateLocation = new MySqlCommand("UPDATE restaurant SET location = @location WHERE restaurantID = @id AND name = @name;", dbcon);
            if (location_textbox.Text.Length > 0)
            {
                updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
            }

            //numVisitors
            MySqlCommand updateVisitors = new MySqlCommand("UPDATE restaurant SET numVisitors = @visitors WHERE restaurantID = @id AND name = @name;", dbcon);
            if (visitors_textbox.Text.Length > 0)
            {
                updateVisitors.Parameters.AddWithValue("@id", id_textbox.Text);
                updateVisitors.Parameters.AddWithValue("@name", name_textbox.Text);
                updateVisitors.Parameters.AddWithValue("@visitors", visitors_textbox.Text);
            }

            //capacity
            MySqlCommand updateCapacity = new MySqlCommand("UPDATE restaurant SET capacity = @capacity WHERE restaurantID = @id AND name = @name;", dbcon);
            if (capacity_textbox.Text.Length > 0)
            {
                updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
            }

            dbcon.Open();
            if (location_textbox.Text.Length > 0)
            {
                updateLocation.ExecuteNonQuery();
            }
            if (visitors_textbox.Text.Length > 0)
            {
                updateVisitors.ExecuteNonQuery();
            }
            if (capacity_textbox.Text.Length > 0)
            {
                updateCapacity.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                name_textbox.Text = "";
                location_textbox.Text = "";
                visitors_textbox.Text = "";
                capacity_textbox.Text = "";
            }
        }
    }
}