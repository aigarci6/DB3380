using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
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
                Response.Write("<script>alert('Restaurant added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertRestaurant(@restaurantID, @name, @restlocID, @capacity, @exp);", dbcon);
            insert.Parameters.AddWithValue("@restaurantID", id_textbox.Text);
            insert.Parameters.AddWithValue("@name", name_textbox.Text);
            insert.Parameters.AddWithValue("@restlocID", location_textbox.Text);
            insert.Parameters.AddWithValue("@capacity", capacity_textbox.Text);

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