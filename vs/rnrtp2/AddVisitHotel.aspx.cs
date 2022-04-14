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

            if ((string)Session["username"] != "admin" || (string)Session["username"] != "hotelstaff")
            {
                Response.Redirect("BadAccess.html");
            }


            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Hotel Visit added successfully!')</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            MySqlCommand insert = new MySqlCommand("CALL InsertVisitHotel(@tickIDh, @hotID, @amountSpent, @daysStayed, @roomNumber);", dbcon);
            insert.Parameters.AddWithValue("@tickIDh", id_textbox.Text);
            insert.Parameters.AddWithValue("@hotID", hid_textbox.Text);
            insert.Parameters.AddWithValue("@roomNumber", room_textbox.Text);

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
                hid_textbox.Text = "";
                room_textbox.Text = "";
                spent_textbox.Text = "";
                days_textbox.Text = "";
            }
        }
    }
}