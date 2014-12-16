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
using System.Net;
using System.Net.Mail;
using System.Globalization;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;

namespace Vacation_management_system.Web.MyVacation
{
    public partial class Report : System.Web.UI.Page
    {
        Database ds = new Database();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpMonth.Items.Insert(0, new ListItem("-select-", string.Empty));
                dd_monthbind();
                drpEmployee.Items.Insert(0, new ListItem("-select-", string.Empty));

                drpStatus.Items.Insert(0, new ListItem("-select-", string.Empty));
            }
        }


        private void dd_monthbind()
        {

   DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            for (int i = 1; i < 13; i++)
            {
                drpMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            bindgrind();
        }
        private void bindgrind()
        {


            string query;
            if (Session["role_ID"].Equals(1))
            {
                if ((drpMonth.SelectedValue == "") && (drpStatus.SelectedValue == "") && (drpEmployee.SelectedValue == "") && ((txtFromDate.Text == "") && (txtToDate.Text == "")))
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select any one of the below ')</script>");
                }
                else
                {
                    query = "SELECT  L.id, E.first_name, CONVERT(varchar,L.from_date,103) as from_date, CONVERT(varchar,L.to_date,103) as to_date ,'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join employee as E ";
                    string oncondition = "on ";

                   // {

                        if (drpMonth.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "DATEPART(month,L.from_date)='" + drpMonth.SelectedValue + "'";
                            oncondition = "and  ";
                        }

                        if (drpEmployee.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "E.isactive='" + drpEmployee.SelectedValue + "'";
                            oncondition = "and ";

                        }
                        if (drpStatus.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "L.approval_status='" + drpStatus.SelectedValue + "'";
                            oncondition = "and ";
                        }
                        if ((txtFromDate.Text.Length > 0) && (txtToDate.Text.Length > 0))
                        {
                            query += oncondition;
                            query += "L.from_date>'" + txtFromDate.Text + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + txtToDate.Text + "'";
                        }

                        SqlDataReader _data;
                        ds.RunQuery(out _data, query);

                        if (_data.HasRows == true)
                        {
                            DataTable dt = new DataTable();


                            dt.Load(_data);


                            grdview1.DataSource = dt;
                            grdview1.DataBind();
                            _data.Close();
                            ds.Close();

                        }

                        else
                        {
                            lblEmpty.Text = "No records found";
                            _data.Close();
                            ds.Close();

                        }
                    }


                if (Session["role_ID"].Equals(2))
                {
                    if ((drpMonth.SelectedValue == "") && (drpStatus.SelectedValue == "") && (drpEmployee.SelectedValue == "") && ((txtFromDate.Text == "") && (txtToDate.Text == "")))
                    {

                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('please select ')</script>");
                    }
                    else
                    {

                        query = "SELECT  L.id,E.id, E.first_name, CONVERT(varchar,L.from_date,103)as from_date, CONVERT(varchar,L.to_date,103) as to_date , 'approval_status'= CASE L.Approval_Status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'i' THEN 'Ideal' WHEN 'c' THEN 'Cancelled' WHEN 'x' THEN 'Cancel Pending' END FROM leave_management as L inner join manager m on l.emp_id=m.employee_id inner join  employee E on l.emp_id=e.id ";
                        string oncondition = "and ";





                        if (Session["role_ID"].Equals(2))
                        {
                            query += oncondition;
                            query += "m.manager_id=" + Session["userId"];
                            oncondition = "and ";

                        }

                        if (drpMonth.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "DATEPART(month,L.from_date)='" + drpMonth.SelectedValue + "'";
                            oncondition = "and  ";
                        }

                        if (drpEmployee.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "E.isactive='" + drpEmployee.SelectedValue + "'";
                            oncondition = "and ";

                        }
                        if (drpStatus.SelectedValue != "")
                        {
                            query += oncondition;
                            query += "L.approval_status='" + drpStatus.SelectedValue + "'";
                            oncondition = "and ";
                        }
                        if ((txtFromDate.Text.Length > 0) && (txtToDate.Text.Length > 0))
                        {
                            query += oncondition;
                            query += "L.from_date>'" + txtFromDate.Text + "' and ";
                            oncondition = "and ";
                            query += "L.to_date<='" + txtToDate.Text + "'";
                        }

                        SqlDataReader _data;
                        ds.RunQuery(out _data, query);
                        if (_data.HasRows == true)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(_data);


                            grdview1.DataSource = dt;
                            grdview1.DataBind();
                            _data.Close();
                            ds.Close();
                        }
                        else
                        {

                            lblEmpty.Text = "No records found";
                            _data.Close();
                            ds.Close();


                        }
                    }
                }
                    }
                }

            
        
        



        protected void grdview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview1.PageIndex = e.NewPageIndex;
            bindgrind();
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }




    }
}