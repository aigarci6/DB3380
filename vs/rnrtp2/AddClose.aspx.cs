using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class AddClose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //auth
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "admin" || (string)Session["username"] != "ridestaff")
            {
                Response.Redirect("BadAccess.html");
            }
            */


            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Ride closed successfully!')</script>");
            }

            DateTime now = DateTime.Now;

            string hour = now.Hour.ToString();
            string minute = now.Minute.ToString();
            string second = now.Second.ToString();

            date.Value = now.Date.ToString("yyyy-MM-dd");
            time_textbox.Text = hour + ":" + minute + ":" + second;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("INSERT INTO closes (rideID, employeeID, date, time, type, cost, month, year) VALUES (@rideid, @empID, @dte, @tme, @tpe, @cst, @munth, @yeer);", dbcon);

            //parse date
            string str = date.Value;
            string[] dates = str.Split('-');

            insert.Parameters.AddWithValue("@rideid", rid_textbox.Text);
            insert.Parameters.AddWithValue("@empID", eid_textbox.Text);
            insert.Parameters.AddWithValue("@dte", date.Value);
            insert.Parameters.AddWithValue("@tme", time_textbox.Text);
            insert.Parameters.AddWithValue("@tpe", type.Value);
            insert.Parameters.AddWithValue("@cst", cost.Text);
            insert.Parameters.AddWithValue("@yeer", dates[0]);
            insert.Parameters.AddWithValue("@munth", dates[1]);



            dbcon.Open();
            insert.ExecuteReader();
            //insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                rid_textbox.Text = "";
                eid_textbox.Text = "";
                date.Value = "";
                time_textbox.Text = "";
                type.Value = "";
                cost.Text = "0";
            }
        }
    }
}