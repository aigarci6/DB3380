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
            
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory != "HR" && jcategory != "restaurant")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            


            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Restaurant visit added successfully!')</script>");
            }


            //dropdownlist restaurant update info
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand restid = new MySqlCommand("SELECT restaurantID, name FROM restaurant ORDER BY name ASC;", dbconn);

            ListItem firstListItem = new ListItem("SELECT", "000");
            DropDownList3.Items.Add(firstListItem);

            dbconn.Open();
            MySqlDataReader restReader = restid.ExecuteReader();
            if (!IsPostBack)
            {
                while (restReader.Read())
                {
                    string name = restReader.GetString(1);
                    string id = restReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList3.Items.Add(newListItem);
                }
            }
            restReader.Close();
            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitRestaurant(@ticketIDr, @restID, @dateVisited, @amountSpent);", dbcon);
            insert.Parameters.AddWithValue("@ticketIDr", id_textbox.Text);
            insert.Parameters.AddWithValue("@restID", DropDownList3.SelectedValue);
            insert.Parameters.AddWithValue("@dateVisited", date.Value);

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
                spent_textbox.Text = "";
            }
        }

        protected void HomeLink(object sender, EventArgs e)
        {
            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while (sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();

            if (jcategory == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if (jcategory == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if (jcategory == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if (jcategory == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}