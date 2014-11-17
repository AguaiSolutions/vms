using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace Aguai_Leave_Management_System
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
    new ScriptResourceDefinition
    {
        Path = "~/scripts/jquery-2.1.1.min.js",
        DebugPath = "~/scripts/jquery-2.1.1.min.js",
        CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
        CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
    });
        }

        void Session_Start(object sender, EventArgs e)
        {
            Database ob = new Database();
            //string query1 = "select weekly_off from weekly_off_days";
            //SqlDataReader data;
            //ob.RunQuery(out data, query1);
            //DataTable weekly_dt = new DataTable();
            //weekly_dt.Load(data);
            //Session["weekly_off"] = weekly_dt;
            //data.Close();
            //ob.Close();

            //string query2 = "select Date from Holidays";
            //Database ob2 = new Database();
            //SqlDataReader data2;
            //ob2.RunQuery(out data2, query2);
            //DataTable holiday = new DataTable();
            //holiday.Load(data2);
            //Session["holiday"] = holiday;
            //data2.Close();
            //ob2.Close();

        }

    }
}