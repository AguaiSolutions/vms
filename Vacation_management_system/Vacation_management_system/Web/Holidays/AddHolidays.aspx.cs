using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;
using System.Globalization;

namespace Vacation_management_system.Web.Holidays
{
    public partial class AddHolidays : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string query;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            //string query = "insert into holidays(holiday_name,holiday_date) values ('" + txtHolidayname1.Value + "','" + txtDate1.Value + "')";
            //ds.RunCommand(query);
            //ds.Close();
            Response.Redirect("~/Web/Holidays/Holidays.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Holidays/Holidays.aspx");
        }
    }
}