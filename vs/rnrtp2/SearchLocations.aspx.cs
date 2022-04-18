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
        {/*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "HR" || (string)Session["username"] != "hotel" || (string)Session["username"] != "ride" || (string)Session["username"] != "restaurant")
            {
                Response.Redirect("BadAccess.html");
            }
            */

            errormessage.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //location name
                MySqlCommand updateName = new MySqlCommand("UPDATE location SET locationName = @locationName WHERE locationID = @locationID;", dbcon);
                if (name_textbox.Text.Length > 0)
                {
                    updateName.Parameters.AddWithValue("@locationID", id_textbox.Text);
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
                    id_textbox.Text = "";
                    name_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Location updated successfully!')</script>");
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
            if ((string)Session["username"] == "HR")
            {
                Response.Redirect("Index.aspx");
            }

            if ((string)Session["username"] == "hotel")
            {
                Response.Redirect("HotelIndex.aspx");
            }

            if ((string)Session["username"] == "restaurant")
            {
                Response.Redirect("RestIndex.aspx");
            }

            if ((string)Session["username"] == "ride")
            {
                Response.Redirect("RideIndex.aspx");
            }
        }
    }
}