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
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;

namespace Vacation_management_system.Web.EmployeeVacation
{
    public partial class EmployeeVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        List<int> leaveid = new List<int>();
        List<double> leaves = new List<double>();
        List<int> empid = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role_ID"].Equals(1))
                {
                    string query = "SELECT  L.id,E.id as emp_id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as " +
                            "to_date,L.description, leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id left join (select id,first_name as Approver from employee where id=" + Session["userId"] + " and role_id=1) as T on T.id = L.approver_id where L.approval_status='p' and E.isactive=1 order by 1 DESC";
                    ds.RunQuery(out _data, query);
                    DataTable table = new DataTable();
                    if (_data.HasRows == true)
                    {
                        table.Load(_data);
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                    }
                    else
                        lblEmpty.Text = "No records found";
                    _data.Close();
                    ds.Close();

                }
                else
                {
                    //Employee Leave Management
                    string query = "SELECT  L.id,E.id as emp_id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as to_date,L.description, leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id left join (select id,first_name as Approver from employee where id=" + Session["userId"] + " and role_id=2) as T on T.id = L.approver_id where L.approval_status='p' and L.approver_id = " + Session["userId"] + " and E.isactive=1 order by 1 DESC";
                    ds.RunQuery(out _data, query);
                    DataTable table = new DataTable();
                    if (_data.HasRows == true)
                    {
                        table.Load(_data);
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                    }
                    else
                        lblEmpty.Text = "No records found";
                    _data.Close();
                    ds.Close();
                }
            }
        }

        protected void btnReject(object sender, EventArgs e)
        {


            //  RejectRecord(leaves, empNo);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void ApproveRecord(int empid)
        {
            string query = "update[dbo].[leave_management]  set approval_status='a' where id=" + empid;
            var result = ds.RunCommand(query);
            ds.Close();
        }
        protected void RejectRecord()
        {
            Queries update_query = new Queries();
            double current_leaves, previous_leave, balance;


            for (int i = 0; i < leaves.Count; i++)
            {
               update_query.employees_leave_balance(out balance, out current_leaves, out previous_leave, empid[i]);
                string query = "update [dbo].[leave_management] set approval_status='r', reason='" + txtRejectreason.Text + "' where id=" + leaveid[i] + "";
                var result = ds.RunCommand(query);
                var update_result = update_query.updateEmployeeLeaves(empid[i], current_year_vacation: current_leaves + leaves[i]);
            }
            ds.Close();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Control chkRow = null;
            for (int iRow = 0; iRow < GridView1.Rows.Count; iRow++)
            {
                //Find CheckBox control in GridView
                chkRow = GridView1.Rows[iRow].Cells[0].FindControl("chkRow");
                if (chkRow != null)
                {
                    if (((CheckBox)chkRow).Checked)
                    {
                        int id = (int)GridView1.DataKeys[iRow].Value;
                        ApproveRecord(id);
                    }
                }
            }
            Response.Redirect("~/Web/EmployeeVacation/EmployeeVacation.aspx");
        }


        protected void btnRejectReason_Click(object sender, EventArgs e)
        {


            foreach (GridViewRow grow in GridView1.Rows)
            {
                //Searching CheckBox("chkRow") in an individual row of Grid  
                CheckBox chkRow = (CheckBox)grow.FindControl("chkRow");
                //If CheckBox is checked than delete the record with particular empid  
                if (chkRow.Checked)
                {
                    leaves.Add(Convert.ToInt32(grow.Cells[9].Text));
                }
            }

            Control chkRow1 = null;
                for (int jRow = 0; jRow < GridView1.Rows.Count; jRow++)
                {
                    //Find CheckBox control in GridView
                    chkRow1 = GridView1.Rows[jRow].Cells[0].FindControl("chkRow");
                    if (chkRow1 != null)
                    {
                        if (((CheckBox)chkRow1).Checked)
                        {
                            leaveid.Add((int)GridView1.DataKeys[jRow].Values["id"]);
                            empid.Add((int)GridView1.DataKeys[jRow].Values["emp_id"]);   
                        }
                    }       
            }

            RejectRecord();
            Response.Redirect("~/Web/EmployeeVacation/EmployeeVacation.aspx");

        }
    }
}

