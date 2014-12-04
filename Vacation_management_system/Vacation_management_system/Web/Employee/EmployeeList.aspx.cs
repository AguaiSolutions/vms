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
using Vacation_management_system.Web.Common.Class;
namespace Vacation_management_system.Web.Employee
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CheckString = "(SELECT id ,emp_no,first_name, last_name,replace(replace(gender,'m','male'),'f','female')as gender,official_email,CONVERT(varchar,date_of_join,103)as date_of_join,contact_number,permanent_address,replace(replace(isactive,'0','inactive'),'1','active')as isactive from employee)";
            ds.RunQuery(out _data,CheckString);
            DataTable dt = new DataTable();
            dt.Load(_data);
            GvEmployeeList.DataSource = dt;
            GvEmployeeList.DataBind();
            _data.Close();
            ds.Close();
        }

        protected void GvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/web/Employee/Add.aspx?id=" + id + "");
            }
        }
        protected void GvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Utilities.convertToSingleQuote(e.Row.Cells[2].Text);
                e.Row.Cells[3].Text = Utilities.convertToSingleQuote(e.Row.Cells[3].Text);
            }
        }
    }
}