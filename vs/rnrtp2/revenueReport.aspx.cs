using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class revenueReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Response.Write("<script>alert('Button Clicked')</script>");
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");
            /*MySqlCommand insert = new MySqlCommand("INSERT_QUERY, @name, @location, @capacity);", dbcon); //needs to be replaced with query/report
            insert.Parameters.AddWithValue("@restaurantID", id_textbox.Text);
            insert.Parameters.AddWithValue("@name", name_textbox.Text);
            insert.Parameters.AddWithValue("@location", location_textbox.Text);
            insert.Parameters.AddWithValue("@capacity", capacity_textbox.Text);*/

            dbcon.Open();
            //insert.ExecuteNonQuery();
            dbcon.Close();

            if (IsPostBack)
            {
                startDate.Value = "";
                endDate.Value = "";
            }
        }
    }
}