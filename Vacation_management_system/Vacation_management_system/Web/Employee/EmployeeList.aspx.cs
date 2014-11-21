using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vacation_management_system.Web.Employee
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
            con.Open();
            string CheckString = "(SELECT id ,emp_no,first_name, last_name,gender,official_email,date_of_join,mobile_number,permanent_address,isactive from employee)";
            SqlCommand cmd = new SqlCommand(CheckString, con);
            var result = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(result);
            GvEmployeeList.DataSource = dt;
            GvEmployeeList.DataBind();
            con.Close();
        }
    }
}