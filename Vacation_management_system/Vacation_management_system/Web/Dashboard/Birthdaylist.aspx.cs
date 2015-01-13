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
using Vacation_management_system.Web.Common.Class;

namespace Vacation_management_system.Web.Dashboard
{
    public partial class Birthdaylist : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    string query = "select  (first_name+' ' +last_name) as Name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as [Date Of Birth] from employee join employee_additional on  employee.id= employee_additional.emp_id  where  DATEADD(YEAR, DATEPART(YEAR, GETDATE()) - DATEPART(YEAR, date_of_birth), date_of_birth)  >YEAR( GETDATE()-1) order by month(date_of_birth), day(date_of_birth) ";
                    ds.RunQuery(out _data, query);
                    DataTable dt = new DataTable();
                    dt.Load(_data);
                    grdbirthday.DataSource = dt;
                    grdbirthday.DataBind();
                    _data.Close();
                    ds.Close();
                }
                catch (Exception)
                {
                    Response.Redirect("~/Login.aspx");
                }

            }
        }
    }
}