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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (Session["role_ID"].Equals(1))
                    {
                        string query =
                            "SELECT  L.id,E.id as emp_id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as " +
                            "to_date,L.description, leave_type.leave_type as type_id, 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END,L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id left join (select id,first_name as Approver from employee where id=" +
                            Session["userId"] +
                            " and role_id=1) as T on T.id = L.approver_id where (L.approval_status='p' or L.approval_status='x') and E.isactive=1 order by 1 DESC";
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
                        string query =
                            "SELECT  L.id,E.id as emp_id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date," +
                            "CONVERT(varchar,L.to_date,103)as to_date,L.description, leave_type.leave_type as type_id, " +
                            "'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END," +
                            "L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id " +
                            "left join (select id,first_name as Approver from employee where id=" + Session["userId"] +
                            " and role_id=2) as T on T.id = L.approver_id where (L.approval_status='p' or L.approval_status='x') and L.approver_id = " +
                            Session["userId"] + " and E.isactive=1 order by 1 DESC";
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
                catch (Exception ex)
                {
                    Response.Redirect("~/Web/Login/Login.aspx");
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string email,username;
            Control chkRow = null;
            string status = "";
            double current_leaves, previous_leave, remaining, leaves;
            for (int iRow = 0; iRow < GridView1.Rows.Count; iRow++)
            {
                //Find CheckBox control in GridView
                chkRow = GridView1.Rows[iRow].Cells[0].FindControl("chkRow");
                if (chkRow != null)
                {
                    if (((CheckBox)chkRow).Checked)
                    {
                        int leaveid = (int)GridView1.DataKeys[iRow].Value;
                        status = GridView1.Rows[iRow].Cells[8].Text;
                        int empid = (int)GridView1.DataKeys[iRow].Values["emp_id"];

                        if (status.Equals("Cancel Pending"))
                        {
                            Queries update_query = new Queries();

                            
                            leaves = Convert.ToInt32(GridView1.Rows[iRow].Cells[9].Text);

                            Queries.Statusupdate('c', leaveid);

                            update_query.employees_leave_balance(out remaining, out current_leaves, out previous_leave, empid);

                            update_query.updateEmployeeLeaves(empid, current_leaves + leaves, previous_leave);

                            //cancel vacation
                        }
                        else
                        {
                            Queries.Statusupdate('a', leaveid);
                            Queries.GetDetails(empid,out username, out email);
                            //approve vaction
                            //Email mail = new Email();
                            // mail.VacationRequestApprovedEmail(Session["UserName"].ToString(),  username, email);
                        }

                    }
                }
            }
            Response.Redirect("~/Web/EmployeeVacation/EmployeeVacation.aspx");
        }


        protected void btnRejectReason_Click(object sender, EventArgs e)
        {
            string status = "";
            Control chkRow = null;
            double leaves;
            int empid, leaveid;
            double current_leaves, previous_leave, balance;
            for (int jRow = 0; jRow < GridView1.Rows.Count; jRow++)
            {
                //Find CheckBox control in GridView
                chkRow = GridView1.Rows[jRow].Cells[0].FindControl("chkRow");
                if (chkRow != null)
                {
                    if (((CheckBox)chkRow).Checked)
                    {
                        leaveid = (int)GridView1.DataKeys[jRow].Values["id"];

                        status = GridView1.Rows[jRow].Cells[8].Text;

                        if (status.Equals("Cancel Pending"))
                        {
                            Queries.Statusupdate('a', leaveid);

                            //cancel - approve vacation
                        }
                        else
                        {
                            leaves = Convert.ToInt32(GridView1.Rows[jRow].Cells[9].Text);

                            empid = (int)GridView1.DataKeys[jRow].Values["emp_id"];

                            Queries update_query = new Queries();

                            update_query.employees_leave_balance(out balance, out current_leaves, out previous_leave, empid);

                            Queries.Statusupdate('r', leaveid, txtRejectreason.Text);

                            update_query.updateEmployeeLeaves(empid, current_year_vacation: current_leaves + leaves);

                            //reject vaction

                        }
                    }
                }
            }

            Response.Redirect("~/Web/EmployeeVacation/EmployeeVacation.aspx");

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var mail_id = Request.QueryString["id"]; 
           for(int i=0;i<GridView1.Rows.Count;i++)
           {
             var table_id= GridView1.DataKeys[i].Values["id"].ToString();
              
              if (table_id.Equals(mail_id))
               {
                   GridView1.Rows[i].BackColor = System.Drawing.Color.MistyRose;
               }
           }
           
        }

    }
}

