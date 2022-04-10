﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddRide : System.Web.UI.Page
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
            MySqlCommand insert = new MySqlCommand("CALL InsertRide(@rideID, @capacity, @name, @maxWeight, @minHeight, @minAge, @rlocID);", dbcon);
            insert.Parameters.AddWithValue("@rideID", id_textbox.Text);
            insert.Parameters.AddWithValue("@capacity", capacity_textbox.Text);
            insert.Parameters.AddWithValue("@name", name_textbox.Text);
            insert.Parameters.AddWithValue("@maxWeight", maxweight_textbox.Text);
            insert.Parameters.AddWithValue("@minHeight", minheight_textbox.Text);
            insert.Parameters.AddWithValue("@minAge", minage_textbox.Text);
            insert.Parameters.AddWithValue("@rlocID", location_textbox.Text);

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                capacity_textbox.Text = "";
                name_textbox.Text = "";
                maxweight_textbox.Text = "";
                minheight_textbox.Text = "";
                minage_textbox.Text = "";
                location_textbox.Text = "";
            }
        }
    }
}