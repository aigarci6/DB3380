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
            
            //auth
            string jcategory = "";
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
            dbcon.Open();
            MySqlCommand search = new MySqlCommand("SELECT jobCategory FROM credentials WHERE userName = @username", dbcon);
            search.Parameters.AddWithValue("@username", (string)Session["username"]);
            MySqlDataReader sReader = search.ExecuteReader();
            while(sReader.Read())
            {
                jcategory = sReader.GetString(0);
            }
            sReader.Close();


            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (jcategory != "HR" && jcategory != "ride")
            {
                Response.Redirect("BadAccess.html");
            }
            dbcon.Close();
            
            

            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Ride closed successfully!')</script>");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");
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