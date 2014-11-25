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

namespace Vacation_management_system.Web.MyVacation
{
    public partial class MyVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Employee Leave Management
                int EmpID = Convert.ToInt32(Session["userId"]);

                string query = "SELECT  L.id,L.from_date,L.to_date,L.description,leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id where emp_id=" + EmpID + " order by 1 DESC";
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                table.Load(_data);
                GridView1.DataSource = table;
                GridView1.DataBind();
                _data.Close();
                ds.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Cancel")
            {
                string query = "update [dbo].[leave_management] set approval_status='c' where id=" + id + "";
                ds.RunCommand(query);
                ds.Close();
            }

            Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyNewVacation.aspx");
        }
    }
}
