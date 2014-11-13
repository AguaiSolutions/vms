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
    public partial class Emp_Leave : System.Web.UI.Page
    {
        Database ds = new Database();
        SqlDataReader rd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Employee Leave Management
                int EmpID = Convert.ToInt32(Session["EmpID"]);

                string query = "SELECT  L.ID,L.From_date,L.To_date,L.Description,LeaveType.Description as Type,T.Approver, 'Approval_Status'= CASE L.Approval_Status  WHEN '0' THEN 'Pending' WHEN '1' THEN 'Approved' WHEN '2' THEN 'Rejected' END,L.Reason FROM LeaveManagement as L left JOIN LeaveType ON LeaveType.ID=L.Type Left join EmployeeTable as E on E.ID = L.EmpID  left join (select ID,UserName as Approver from EmployeeTable where IsAdmin = 1) as T on T.ID = L.Approver_ID where EmpID=" + EmpID + " order by 1 DESC";
                ds.RunQuery(out rd, query);
                DataTable table = new DataTable();
                table.Load(rd);
                GridView1.DataSource = table;
                GridView1.DataBind();
                rd.Close();
                ds.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Cancel")
            {
                string query = "delete[dbo].[LeaveManagement] where Approval_Status=0 and ID=" + id + "";
                ds.RunCommand(query);
                ds.Close();
            }

            Response.Redirect("AppliedLeaves.aspx");
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyLeave.aspx");
        }
    }
}
