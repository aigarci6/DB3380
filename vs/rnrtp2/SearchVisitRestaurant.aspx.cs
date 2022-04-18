using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitRestaurant : System.Web.UI.Page
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

            if (jcategory != "HR" && jcategory  != "restaurant")
            {
                Response.Redirect("BadAccess.html");
            }
            
        }

            

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            int vid;
            string vemail;
            int rid;
            string rname;
            double spent;
            string htmlStr = "";

            dbcon.Open();

            // none
            if (search.Value == "none")
            {
            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID ORDER BY tickID_r ASC;", dbcon);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //visitor id
            if (search.Value == "vid")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE tickID_r = @id ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //restaurant id
            if (search.Value == "rid")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE restID = @id ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //spent greater than
            if (search.Value == "spent_greater")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE amountSpent > @spent ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            //spent less than
            if (search.Value == "spent_less")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_r, email, restID, name, amountSpent FROM visit_restaurant LEFT OUTER JOIN visitor ON tickID_r = ticketID LEFT OUTER JOIN restaurant ON restID = restaurantID WHERE amountSpent < @spent ORDER BY tickID_r ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    rid = sReader.GetInt32(2);
                    rname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + rid + "</td><td>" + rname + "</td><td> $" + spent + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
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