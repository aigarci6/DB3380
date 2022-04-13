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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_textbox.Text.Length > 0 && hid_textbox.Text.Length > 0)
            {
                MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

                //amount spent
                MySqlCommand updateSpending = new MySqlCommand("UPDATE visit_hotel SET amountSpent = @amountSpent WHERE tickID_h = @tickIDh AND hotID = @hotID;", dbcon);
                if (spent_textbox.Text.Length > 0)
                {
                    updateSpending.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
                    updateSpending.Parameters.AddWithValue("@hotID", hid_textbox.Text);
                    updateSpending.Parameters.AddWithValue("@amountSpent", spent_textbox.Text);
                }

                //days stayed
                MySqlCommand updateDays = new MySqlCommand("UPDATE visit_hotel SET daysStayed = @daysStayed WHERE tickID_h = @tickIDh AND hotID = @hotID;", dbcon);
                if (spent_textbox.Text.Length > 0)
                {
                    updateDays.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
                    updateDays.Parameters.AddWithValue("@hotID", hid_textbox.Text);
                    updateDays.Parameters.AddWithValue("@daysStayed", days_textbox.Text);
                }

                //room number
                MySqlCommand updateRoom = new MySqlCommand("UPDATE visit_hotel SET roomNumber = @roomNumber WHERE tickID_h = @tickIDh AND hotID = @hotID;", dbcon);
                if (spent_textbox.Text.Length > 0)
                {
                    updateRoom.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
                    updateRoom.Parameters.AddWithValue("@hotID", hid_textbox.Text);
                    updateRoom.Parameters.AddWithValue("@roomNumber", room_textbox.Text);
                }

                dbcon.Open();
                if (spent_textbox.Text.Length > 0)
                {
                    updateSpending.ExecuteNonQuery();
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
                    spent_textbox.Text = "";
                    days_textbox.Text = "";
                    room_textbox.Text = "";
                }

                if (IsPostBack == true)
                {
                    Response.Write("<script>alert('Visit updated successfully!')</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        public string getData()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            int vid;
            string vemail;
            int hid;
            string hname;
            double spent;
            int daysstayed;
            int roomnum;
            string htmlStr = "";

            dbcon.Open();

            //auto (all)
            if (search.Value == "none")
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
    }
}