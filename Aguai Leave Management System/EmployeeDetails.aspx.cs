using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aguai_Leave_Management_System
{
    public partial class Admin_UserManage : System.Web.UI.Page
    {
        Database ds = new Database();
        SqlDataReader rd;
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];
            if (!IsPostBack)
            {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            string query = "select ID,Emp_Reg_No,UserName,Email,Contact,Address from EmployeeTable where IsActive=1";
            ds.RunQuery(out rd, query);

            DataTable table = new DataTable();
            table.Load(rd);
            GridView2.DataSource = table;
            GridView2.DataBind();
            rd.Close();
            ds.Close();
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deactivate")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                string query = "update [dbo].[EmployeeTable] set IsActive=2 where ID=" + id + "";

                ds.RunCommand(query);
                ds.Close();

                Response.Redirect("EmployeeDetails.aspx");
            }
        }
    }
}