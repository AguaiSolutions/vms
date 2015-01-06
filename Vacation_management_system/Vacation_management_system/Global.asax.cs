using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aguai_Leave_Management_System
{
    public class Global : System.Web.HttpApplication
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        "Default", // Route name
        //        "{controller}/{action}/{id}", // URL with parameters
        //        new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        //    );
        //}

        protected void Application_Start(object sender, EventArgs e)
        {
            //AreaRegistration.RegisterAllAreas();
            //RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            EnableCrossDmainAjaxCall();
        }
        
        //protected void Application_Start(object sender, EventArgs e)
        //{
        //    //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost");
        //    //if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    //{
        //    //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");

        //    //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        //    //    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        //    //    HttpContext.Current.Response.End();
        //    //}
        //}

        private void EnableCrossDmainAjaxCall()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            Database ob = new Database();
            string query1 = "select week_off_days from weekly_off_days";
            SqlDataReader data;
            ob.RunQuery(out data, query1);
            DataTable weekly_dt = new DataTable();
            weekly_dt.Load(data);
            Session["weekly_off"] = weekly_dt;
            data.Close();
            ob.Close();

            string query2 = "select holiday_date from holidays";
            Database ob2 = new Database();
            SqlDataReader data2;
            ob2.RunQuery(out data2, query2);
            DataTable holiday = new DataTable();
            holiday.Load(data2);
            Session["holiday"] = holiday;
            data2.Close();
            ob2.Close();

        }

    }
}