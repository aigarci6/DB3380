using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchLocations : System.Web.UI.Page
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

            if (jcategory != "HR" && jcategory != "hotel" && jcategory != "ride" && jcategory != "restaurant")
            {
                Response.Redirect("BadAccessP.aspx");
            }
            
            
            errormessage.Visible = false;
            
            //dropdownlist
            MySqlConnection dbconn = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred; Allow User Variables=True;");
            MySqlCommand locid = new MySqlCommand("SELECT locationID, locationName FROM location ORDER BY locationName ASC;", dbconn);

            ListItem firstListItem = new ListItem("SELECT", "000");
            DropDownList1.Items.Add(firstListItem);

            dbconn.Open();
            MySqlDataReader locReader = locid.ExecuteReader();
            if (!IsPostBack)
            {
                while (locReader.Read())
                {
                    string name = locReader.GetString(1);
                    string id = locReader.GetString(0);
                    ListItem newListItem = new ListItem(name, id);
                    DropDownList1.Items.Add(newListItem);
                }
            }
            locReader.Close();
            dbconn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text != "SELECT")
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //location name
                MySqlCommand updateName = new MySqlCommand("UPDATE location SET locationName = @locationName WHERE locationID = @locationID;", dbcon);
                if (name_textbox.Text.Length > 0)
                {
                    updateName.Parameters.AddWithValue("@locationID", DropDownList1.SelectedValue);
                    updateName.Parameters.AddWithValue("@locationName", name_textbox.Text);
                }

                dbcon.Open();
                if (name_textbox.Text.Length > 0)
                {
                    updateName.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    name_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Location updated successfully!')</script>");
                    Response.Redirect(Request.RawUrl);
                }
            }

            else
            {
                errormessage.Visible = true;
            }
        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            int id;
            string name;

            string htmlStr = "";

            dbcon.Open();
            
            //auto none
            if (search.Value =="none")
            {

            }

            // all
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT * FROM location", dbcon);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    name = sReader.GetString(1);
                    htmlStr += "<tr><td>" + id + "</td><td>" + name + "</td></tr>";
                }
                sReader.Close();
            }

            //id
            if (search.Value == "id")
            {
                MySqlCommand search = new MySqlCommand("SELECT * FROM location WHERE locationID = @id", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    name = sReader.GetString(1);
                    htmlStr += "<tr><td>" + id + "</td><td>" + name + "</td></tr>";
                }
                sReader.Close();
            }

            //name
            if (search.Value == "name")
            {
                MySqlCommand search = new MySqlCommand("SELECT * FROM location WHERE locationName = @name", dbcon);
                search.Parameters.AddWithValue("@name", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    name = sReader.GetString(1);
                    htmlStr += "<tr><td>" + id + "</td><td>" + name + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

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