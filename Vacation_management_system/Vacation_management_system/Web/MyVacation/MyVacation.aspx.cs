﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;

namespace Vacation_management_system.Web.MyVacation
{
    public partial class Vacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        double remaining_leaves, current_year_vacations, previous_year_vacations, temp;
        private string query;
        ApplyVacation vacation = new ApplyVacation();
        Queries query_object = new Queries();
        Int32 user_id;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {

                    int approved = 0;
                    user_id = Convert.ToInt32(Session["userId"]);
                    query_object.employees_leave_balance(out remaining_leaves, out  current_year_vacations, out previous_year_vacations, user_id);
                    //query = "select leaves from leave_management where approval_status='a' and emp_id=" + user_id + "";
                    //ds.RunQuery(out _data, query);
                    //while (_data.Read())
                    //{
                    //    approved += Convert.ToInt32(_data["leaves"]);
                    //}
                    //_data.Close();
                    //ds.Close();

                    lblApproved.Text = Queries.VacationDetails("a", Convert.ToInt32(Session["userId"])).ToString();
                    lblRemaining.Text = remaining_leaves.ToString();

                    if (Session["role_name"].Equals("Admin"))
                    {
                        AdminGridviewBind();

                    }
                    else
                    {
                        EmployeeGridviewBind(); 
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblRow_Id.Text = (e.CommandArgument).ToString();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button lbtCancel = (Button)e.Row.FindControl("btncancel");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[6].Text.Equals("Cancelled") || e.Row.Cells[6].Text.Equals("Cancel Pending") || e.Row.Cells[6].Text.Equals("Rejected"))
                {
                    lbtCancel.Visible = false;
                }

            }
        }

        protected void btnApplyLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyNewVacation.aspx");
        }

        protected void btncancel(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //lblEmpty.Text = gvr.Cells[0].Text;
            //txtCfromdate.Text = gvr.Cells[2].Text;
            //txtCtodate.Text = gvr.Cells[3].Text;
            //txtCleavetype.Text = gvr.Cells[5].Text;
            //txtCapprover.Text = gvr.Cells[6].Text;
            //txtCdesc.Text = gvr.Cells[4].Text;
            lblLeaves.Text = gvr.Cells[8].Text;
            lblStatus.Text = gvr.Cells[6].Text;
            lblType.Text = gvr.Cells[5].Text;
            var msg = "<script language='javascript'> $(\"#demo2\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation15", msg);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }


        protected void btnCancelReason_Click(object sender, EventArgs e)
        {
            var res = false;
            if (lblStatus.Text.Equals("Approved"))
            {
              res=  Queries.Statusupdate('x', Convert.ToInt32(lblRow_Id.Text), txtCreason.Text);
            }
            else
            {
                if (lblType.Text.Equals("RH"))
                {
                  res=  Queries.Statusupdate('c', Convert.ToInt32(lblRow_Id.Text), txtCreason.Text);
                }
                else
                {
                    Queries update_query = new Queries();
                    double current_leaves, previous_leave, balance;
                    update_query.employees_leave_balance(out balance, out current_leaves, out previous_leave, Convert.ToInt32(Session["userId"]));

                    //query = "update [dbo].[leave_management] set approval_status='c', reason='" + txtCreason.Text + "' where id=" + lblRow_Id.Text + "";
                    //var res = ds.RunCommand(query);

                    res = Queries.Statusupdate('c', Convert.ToInt32(lblRow_Id.Text), txtCreason.Text);
                    var update_result = update_query.updateEmployeeLeaves(Convert.ToInt32(Session["userId"]), current_year_vacation: current_leaves + Convert.ToDouble(lblLeaves.Text));
                    ds.Close();
                }
                
                if (!res)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('you are already applied vacation for this dates.')</script>");

                }
            }

            Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
        }

        private void AdminGridviewBind()
        {
            lblApprovedVacation.Style.Add("display", "none");
            lblApproved.Style.Add("display", "none");
            lblBalance.Style.Add("display", "none");
            lblRemaining.Style.Add("display", "none");
            btnapplyleave.Style.Add("display", "none");
            btnapplyleave1.Style.Add("display", "none");
            query = "SELECT  L.id, E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as to_date,L.description,leave_type.leave_type as type_id, approval_status= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' END,L.reason,L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id  order by 1 DESC";
            ds.RunQuery(out _data, query);
            DataTable table = new DataTable();
            table.Load(_data);
            GridView1.DataSource = table;
            GridView1.DataBind();
            GridView1.Columns[9].Visible = false;
            _data.Close();
            ds.Close();
        }

        private void EmployeeGridviewBind()
        {
            query = "SELECT   L.id,E.first_name,CONVERT(varchar,L.from_date,103)as from_date,CONVERT(varchar,L.to_date,103)as to_date,L.description,leave_type.leave_type as type_id, approval_status= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END,L.reason,L.leaves FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id where emp_id=" + Session["userId"] + " order by 1 DESC";
            ds.RunQuery(out _data, query);
            DataTable table = new DataTable();
            table.Load(_data);
            GridView1.DataSource = table;
            GridView1.DataBind();
            _data.Close();
            ds.Close();
        }


        protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var msg = "<script language='javascript'> $(\"#demo2\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation16", msg);
            GridView1.PageIndex = e.NewPageIndex;

            if (Session["role_ID"].Equals(1))
            {
                AdminGridviewBind();

            }
            else
            {
                EmployeeGridviewBind();
            }
        }


    }
}
