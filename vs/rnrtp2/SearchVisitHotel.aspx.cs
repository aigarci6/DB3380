using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class SearchVisitHotel : System.Web.UI.Page
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
            

            errormessage.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && hid_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

                //days stayed
                MySqlCommand updateDays = new MySqlCommand("UPDATE visit_hotel SET daysStayed = @daysStayed WHERE visitID=@updateID;", dbcon);
                MySqlCommand updateID = new MySqlCommand("SELECT visitID FROM visit_hotel WHERE tickID_h=@tickID AND hotID=@hID", dbcon);

                updateID.Parameters.AddWithValue("@tickID", id_textbox.Text);
                updateID.Parameters.AddWithValue("@hID", hid_textbox.Text);

                dbcon.Open();
                MySqlDataReader idReader = updateID.ExecuteReader();
                idReader.Read();
                int id = idReader.GetInt32(0);
                idReader.Close();

                if (days_textbox.Text.Length > 0)
                {
                    updateDays.Parameters.AddWithValue("@updateID", id);
                    updateDays.Parameters.AddWithValue("@daysStayed", days_textbox.Text);
                }

                //room number
                MySqlCommand updateRoom = new MySqlCommand("UPDATE visit_hotel SET roomNumber = @roomNumber WHERE visitID=@updateID;", dbcon);
                if (room_textbox.Text.Length > 0)
                {
                    updateRoom.Parameters.AddWithValue("@updateID", id);
                    updateRoom.Parameters.AddWithValue("@roomNumber", room_textbox.Text);
                }
               
                if (days_textbox.Text.Length > 0)
                {
                    updateDays.ExecuteNonQuery();
                }
                if (room_textbox.Text.Length > 0)
                {
                    updateRoom.ExecuteNonQuery();
                }
                dbcon.Close();

                if (IsPostBack)
                {
                    id_textbox.Text = "";
                    hid_textbox.Text = "";
                    days_textbox.Text = "";
                    room_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Visit updated successfully!')</script>");
                }
            }

            else
            {
                errormessage.Visible = true;
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
            int hid;
            string hname;
            double spent;
            int daysstayed;
            int roomnum;
            string htmlStr = "";

            dbcon.Open();

            // none
            if (search.Value == "none")
            {

            }

            //* (all)
            if (search.Value == "all")
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID ORDER BY tickID_h ASC;", dbcon);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //visitor id
            if (search.Value == "vid" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE tickID_h = @id ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //hotel id
            if (search.Value == "hid" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE hotID = @id ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@id", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //spent greater than
            if (search.Value == "spent_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE amountSpent > @spent ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //spent less than
            if (search.Value == "spent_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE amountSpent < @spent ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@spent", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //days stayed greater than
            if (search.Value == "days_greater" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE daysStayed > @days ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@days", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //days stayed less than
            if (search.Value == "days_less" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE daysStayed < @days ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@days", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            //room number
            if (search.Value == "room" && field_textbox.Text.Length > 0)
            {
                MySqlCommand search = new MySqlCommand("SELECT tickID_h, email, hotID, name, amountSpent, daysStayed, roomNumber FROM visit_hotel LEFT OUTER JOIN visitor ON tickID_h = ticketID LEFT OUTER JOIN hotel ON hotID = hotelID WHERE roomNumber = @room ORDER BY tickID_h ASC;", dbcon);
                search.Parameters.AddWithValue("@room", field_textbox.Text);

                MySqlDataReader sReader = search.ExecuteReader();
                while (sReader.Read())
                {
                    vid = sReader.GetInt32(0);
                    vemail = sReader.GetString(1);
                    hid = sReader.GetInt32(2);
                    hname = sReader.GetString(3);
                    spent = sReader.GetDouble(4);
                    daysstayed = sReader.GetInt32(5);
                    roomnum = sReader.GetInt32(6);

                    htmlStr += "<tr><td>" + vid + "</td><td>" + vemail + "</td><td>" + hid + "</td><td>" + hname + "</td><td> $" + spent + "</td><td>" + daysstayed + "</td><td>" + roomnum + "</td></tr>";
                }
                sReader.Close();
            }

            dbcon.Close();
            return htmlStr;
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