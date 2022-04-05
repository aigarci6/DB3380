using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchRide : System.Web.UI.Page
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
            MySqlCommand updateLocation = new MySqlCommand("UPDATE rides SET location = @location WHERE rideID = @id AND name = @name;", dbcon);
            if (location_textbox.Text.Length > 0)
            {
                updateLocation.Parameters.AddWithValue("@id", id_textbox.Text);
                updateLocation.Parameters.AddWithValue("@name", name_textbox.Text);
                updateLocation.Parameters.AddWithValue("@location", location_textbox.Text);
            }

            //capacity
            MySqlCommand updateCapacity = new MySqlCommand("UPDATE rides SET capacity = @capacity WHERE rideID = @id AND name = @name;", dbcon);
            if (capacity_textbox.Text.Length > 0)
            {
                updateCapacity.Parameters.AddWithValue("@id", id_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@name", name_textbox.Text);
                updateCapacity.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
            }

            //maxweight
            MySqlCommand updateWeight = new MySqlCommand("UPDATE rides SET maxWeight = @weight WHERE rideID = @id AND name = @name;", dbcon);
            if (maxweight_textbox.Text.Length > 0)
            {
                updateWeight.Parameters.AddWithValue("@id", id_textbox.Text);
                updateWeight.Parameters.AddWithValue("@name", name_textbox.Text);
                updateWeight.Parameters.AddWithValue("@weight", maxweight_textbox.Text);
            }

            //minheight
            MySqlCommand updateHeight = new MySqlCommand("UPDATE rides SET minHeight = @height WHERE rideID = @id AND name = @name;", dbcon);
            if (minheight_textbox.Text.Length > 0)
            {
                updateHeight.Parameters.AddWithValue("@id", id_textbox.Text);
                updateHeight.Parameters.AddWithValue("@name", name_textbox.Text);
                updateHeight.Parameters.AddWithValue("@height", minheight_textbox.Text);
            }

            //minage
            MySqlCommand updateAge = new MySqlCommand("UPDATE rides SET minAge = @age WHERE rideID = @id AND name = @name;", dbcon);
            if (minage_textbox.Text.Length > 0)
            {
                updateAge.Parameters.AddWithValue("@id", id_textbox.Text);
                updateAge.Parameters.AddWithValue("@name", name_textbox.Text);
                updateAge.Parameters.AddWithValue("@age", minage_textbox.Text);
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
            if (maxweight_textbox.Text.Length > 0)
            {
                updateWeight.ExecuteNonQuery();
            }
            if (minheight_textbox.Text.Length > 0)
            {
                updateHeight.ExecuteNonQuery();
            }
            if (minage_textbox.Text.Length > 0)
            {
                updateAge.ExecuteNonQuery();
            }
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                name_textbox.Text = "";
                location_textbox.Text = "";
                capacity_textbox.Text = "";
                maxweight_textbox.Text = "";
                minheight_textbox.Text = "";
                minage_textbox.Text = "";
            }
        }
    }
}