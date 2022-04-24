using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddVisitHotel : System.Web.UI.Page
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

            if (jcategory != "HR" && jcategory != "hotel")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Hotel Visit added successfully!')</script>");
            }

            //dropdownlist
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand hotid = new MySqlCommand("SELECT hotelID, name FROM hotel ORDER BY name ASC;", dbconn);
            dbconn.Open();
            ListItem firstListItem = new ListItem("SELECT", "000");
            DropDownList2.Items.Add(firstListItem);
            MySqlDataReader hotReader = hotid.ExecuteReader();
            if (!IsPostBack)
            {
                while (hotReader.Read())
                {
                    string name = hotReader.GetString(1);
                    string id = hotReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList2.Items.Add(newListItem);
                }
            }
            hotReader.Close();
            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitHotel(@tickIDh, @hotID, @dateVisited, @amountSpent, @daysStayed, @roomNumber);", dbcon);
            insert.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
            insert.Parameters.AddWithValue("@hotID", DropDownList2.SelectedValue);
            insert.Parameters.AddWithValue("@roomNumber", room_textbox.Text);
            insert.Parameters.AddWithValue("@dateVisited", date.Value);

            if (spent_textbox.Text.Length > 0)
            {
                insert.Parameters.AddWithValue("@amountSpent", spent_textbox.Text);
            }
            else
            {
                insert.Parameters.AddWithValue("@amountSpent", 0);
            }
            
            if (days_textbox.Text.Length > 0)
            {
                insert.Parameters.AddWithValue("@daysStayed", days_textbox.Text);
            }
            else
            {
                insert.Parameters.AddWithValue("@daysStayed", 1);
            }
            

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                id_textbox.Text = "";
                room_textbox.Text = "";
                spent_textbox.Text = "";
                days_textbox.Text = "";
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