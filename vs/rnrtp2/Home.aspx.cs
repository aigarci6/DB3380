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
            MySqlConnection dbcon = new MySqlConnection("Server=rnrthemepark-db3380.mysql.database.azure.com; Port=3306; Database=theme_park; Uid=courtney@rnrthemepark-db3380; Pwd=cosc3380!; SslMode=Preferred;");

            //find date
            DateTime thisDay = DateTime.Today;
            string date = thisDay.ToString("yyyy-MM-dd");
            DateTime cdate;
            string c2date;
            string cname;

            MySqlCommand closures = new MySqlCommand("SELECT date, name FROM closes LEFT OUTER JOIN rides ON closes.rideID = rides.rideID WHERE date >= @date", dbcon);
            closures.Parameters.AddWithValue("@date", date);

            string htmlStr = "";

            dbcon.Open();

            MySqlDataReader reader = closures.ExecuteReader();
            while (reader.Read())
            {
                cdate = reader.GetDateTime(0);
                c2date = cdate.ToString("yyyy-MM-dd");
                cname = reader.GetString(1);

                htmlStr += "<tr><td>" + c2date + "</td><td>" + cname + "</td></tr>";
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