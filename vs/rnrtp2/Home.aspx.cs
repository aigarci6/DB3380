using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace rnrtp2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormessage.Visible = false;
        }

        public string getClosures()
        {
            MySqlConnection dbcon = new MySqlConnection("Server = rocknrollthemepark.mysql.database.azure.com; Port = 3306; Database = theme_park; Uid = ziyan@rocknrollthemepark; Pwd = Cosc3380!; SslMode = Preferred;");

            //find date
            DateTime thisDay = DateTime.Today;
            string date = thisDay.ToString("yyyy-MM-dd");
            string cdate;
            string cname;

            MySqlCommand closures = new MySqlCommand("SELECT date, name FROM closes LEFT OUTER JOIN rides ON closes.rideID = rides.rideID WHERE date >= @date", dbcon);
            closures.Parameters.AddWithValue("@date", date);

            string htmlStr = "";

            dbcon.Open();

            MySqlDataReader reader = closures.ExecuteReader();
            while (reader.Read())
            {
                cdate = reader.GetString(0);
                cname = reader.GetString(1);

                htmlStr += "<tr><td>" + cdate + "</td><td>" + cname + "</td></tr>";
            }
            reader.Close();


            dbcon.Close();

            if (htmlStr.Length == 0)
            {
                errormessage.Visible = true;
            }

            return htmlStr;
        }
    }
}