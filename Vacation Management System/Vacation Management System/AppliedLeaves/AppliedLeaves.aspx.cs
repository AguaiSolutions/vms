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

                string query = "SELECT  L.id,L.from_date, L.to_date,L.description,leave_type.leave_type as Type,T.Approver, 'approval_status'= CASE L.approval_status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' then 'Cancel' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.ID=L.type_id Left join employee as E on E.id = L.emp_id  left join (select id,first_name as Approver from employee where role_id = 1) as T on T.id = L.approver_id where E.id=5 order by 1 DESC";
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
                string query = "INSERT INTO cancel_leave (cancel_leave.emp_id, cancel_leave.leave_id, reason) SELECT leave_management.emp_id, leave_management.id,leave_management.reason  FROM leave_management where leave_management.id=" + id + "";
                string query1="update leave_management set approval_status='c' where id="+id+"";
                var rest= ds.RunCommand(query);
                var res = ds.RunCommand(query1);
                ds.Close();
            }

            Response.Redirect("~/AppliedLeaves/AppliedLeaves.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lbtCancel = (LinkButton)e.Row.FindControl("lbtnCancel");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[6].Text.Equals("Cancel") || e.Row.Cells[6].Text.Equals("Rejected"))
                    {
                        lbtCancel.Enabled = false;
                    }
                else
                    if (e.Row.Cells[6].Text.Equals("Approved"))
                    {
                        lbtCancel.Enabled = false;
                    }
                    
            }
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppliedLeaves/ApplyLeave.aspx");
        }
    }
}
