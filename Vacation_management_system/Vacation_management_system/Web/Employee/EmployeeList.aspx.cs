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

namespace Vacation_management_system.Web.Employee
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CheckString = "(SELECT id ,emp_no,first_name, last_name,gender,official_email,date_of_join,contact_number,permanent_address,isactive from employee)";
            ds.RunQuery(out _data,CheckString);
            DataTable dt = new DataTable();
            dt.Load(_data);
            GvEmployeeList.DataSource = dt;
            GvEmployeeList.DataBind();
            _data.Close();
            ds.Close();
        }
    }
}