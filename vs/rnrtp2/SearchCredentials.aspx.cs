using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "HR")
            {
                Response.Redirect("BadAccess.html");
            }
            */

            errormessage.Visible = false;
        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            int id;
            string user;
            string password;
            string htmlStr = "";

            dbcon.Open();

            //auto none
            if (search.Value == "none")
            {
            }

            //all
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT * FROM credentials SORT ORDER BY userName ASC;", dbcon);
                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    id = sReader.GetInt32(0);
                    user = sReader.GetString(1);
                    password = sReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                sReader.Close();
            }

            //search by id
            if (search.Value == "id")
            {
                MySqlCommand searchByID = new MySqlCommand("SELECT * FROM credentials WHERE userID = @id ORDER BY userName ASC;", dbcon);
                searchByID.Parameters.AddWithValue("@id", field_textbox.Text);
                MySqlDataReader idReader = searchByID.ExecuteReader();
                while (idReader.Read())
                {
                    id = idReader.GetInt32(0);
                    user = idReader.GetString(1);
                    password = idReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                idReader.Close();
            }

            //search by user
            if (search.Value == "user")
            {
                MySqlCommand searchByUser = new MySqlCommand("SELECT * FROM credentials WHERE userName = @userName ORDER BY userName ASC;", dbcon);
                searchByUser.Parameters.AddWithValue("@userName", field_textbox.Text);
                MySqlDataReader userReader = searchByUser.ExecuteReader();
                while (userReader.Read())
                {
                    id = userReader.GetInt32(0);
                    user = userReader.GetString(1);
                    password = userReader.GetString(2);
                    htmlStr += "<tr><td>" + id + "</td><td>" + user + "</td><td>" + password + "</td></tr>";
                }
                userReader.Close();
            }

            
            dbcon.Close();
            return htmlStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                if (id_textbox.Text.Length > 0)
                {
                    //username
                    MySqlCommand updateUser = new MySqlCommand("UPDATE credentials SET userName = @userName WHERE userID = @userID;", dbcon);
                    if (user_textbox.Text.Length > 0)
                    {
                        updateUser.Parameters.AddWithValue("@userID", id_textbox.Text);
                        updateUser.Parameters.AddWithValue("@userName", user_textbox.Text);
                    }

                    //password
                    MySqlCommand updatePass = new MySqlCommand("UPDATE credentials SET password = @password WHERE userID = @userID;", dbcon);
                    if (pass_textbox.Text.Length > 0)
                    {
                        updatePass.Parameters.AddWithValue("@userID", id_textbox.Text);
                        updatePass.Parameters.AddWithValue("@password", pass_textbox.Text);
                    }

                    dbcon.Open();
                    if (user_textbox.Text.Length > 0)
                    {
                        updateUser.ExecuteNonQuery();
                    }
                    if (pass_textbox.Text.Length > 0)
                    {
                        updatePass.ExecuteNonQuery();
                    }
                    dbcon.Close();

                    if (IsPostBack)
                    {
                        id_textbox.Text = "";
                        user_textbox.Text = "";
                        pass_textbox.Text = "";
                    }

                    if (IsPostBack == true)
                    {
                        Response.Write("<script>alert('Credentials updated successfully!')</script>");
                    }
                }
            }

            else { 
                errormessage.Visible = true; 
            }
            
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