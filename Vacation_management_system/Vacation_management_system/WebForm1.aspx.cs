using Aguai_Leave_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Aguai_Leave_Management_System;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;


namespace Vacation_management_system
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Database ds = new Database();
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.Form["drpname"].ToString();

            //    string query;
            //    Database ds = new Database();
            //    protected void Page_Load(object sender, EventArgs e)
            //    {
            //        name();

            //    }
            //    private void name()
            //    {

            //          query  = "select first_name +' '+last_name from employee";

            //          SqlDataReader _data;
            //          ds.RunQuery(out _data, query);
            //        DataTable dt=new DataTable();
            //          dt.Load(_data);

            //        drpName.DataSource=dt;
            //        drpName.DataTextField="first_name";
            //        drpName.DataTextField = "last_name";

            //        drpName.DataValueField="id";



            dd_name();
        }


        private void dd_name()
        {
            query = "select id, first_name+' '+last_name as name from employee";
            DataTable dt = new DataTable();

            SqlDataReader _data;

            ds.RunQuery(out _data, query);
            dt.Load(_data);
            drpName.DataSource = dt;
            drpName.DataValueField = "id";
            drpName.DataTextField = "name";
            drpName.DataBind();
            drpName.Multiple = true;



        }
        

    }
}