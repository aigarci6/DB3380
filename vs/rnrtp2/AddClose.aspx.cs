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
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if ((string)Session["username"] != "admin" || (string)Session["username"] != "ridestaff")
            {
                Response.Redirect("BadAccess.html");
            }



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
            MySqlCommand insert = new MySqlCommand("CALL InsertClose(@rideID, @employeeID, @date, @time, @type);", dbcon);
            insert.Parameters.AddWithValue("@rideID", rid_textbox.Text);
            insert.Parameters.AddWithValue("@employeeID", eid_textbox.Text);
            insert.Parameters.AddWithValue("@date", date.Value);
            insert.Parameters.AddWithValue("@time", time_textbox.Text);

            if (type_textbox.Text.Length > 0)
            {
                insert.Parameters.AddWithValue("@type", type_textbox.Text);
            }

            else
            {
                insert.Parameters.AddWithValue("@type", "n/a");
            }

            dbcon.Open();
            insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                rid_textbox.Text = "";
                eid_textbox.Text = "";
                date.Value = "";
                time_textbox.Text = "";
                type_textbox.Text = "";
            }
        }
    }
}