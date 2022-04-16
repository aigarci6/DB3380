﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   /*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "admin")
            {
                Response.Redirect("BadAccess.html");
            }
            */

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('New login added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("INSERT INTO credentials(userID, userName, password) VALUES (@userID, @userName, @password);", dbcon);
            insert.Parameters.AddWithValue("@userID", id_textbox.Text);
            insert.Parameters.AddWithValue("@userName", user_textbox.Text);
            insert.Parameters.AddWithValue("@password", pass_textbox.Text);

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                user_textbox.Text = "";
                pass_textbox.Text = "";
            }
        }

        protected void HomeLink(object sender, EventArgs e)
        {
            if ((string)Session["username"] == "admin")
            {
                Response.Redirect("Index.aspx");
            }

            if ((string)Session["username"] == "hotelstaff")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if ((string)Session["username"] == "reststaff")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if ((string)Session["username"] == "ridestaff")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}