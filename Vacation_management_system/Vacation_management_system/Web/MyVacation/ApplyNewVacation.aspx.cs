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

namespace Vacation_management_system.Web.MyVacation
{
    public partial class ApplyNewVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        List<DateTime> holidays = new List<DateTime>();
        string remaining_leaves = null;
        private string  query;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (!(Session["role_ID"].Equals(1)))
                {
                    query = "SELECT id,first_name,last_name,official_email from employee where id = (select manager_id from manager where employee_id = " + Convert.ToInt32(Session["userId"]) + ")";
                    ds.RunQuery(out _data, query);
                    if (_data.HasRows == true)
                    {
                        
                        while (_data.Read())
                        {
                            lblManager_Id.Text = _data["id"].ToString();
                            txtApprover.Text = _data["first_name"].ToString() + " " + _data["last_name"].ToString();
                            lblManager_Email.Text = _data["official_email"].ToString();
                        }
                       
                    }
                    else
                    {
                        query = "SELECT id,first_name,last_name,official_email from employee where role_id=1";
                        SqlDataReader _data1;
                        ds.RunQuery(out _data1, query);
                        while (_data1.Read())
                        {
                            lblManager_Id.Text =(string) _data["id"];
                            txtApprover.Text = _data["first_name"].ToString() + " " + _data["last_name"].ToString();
                            lblManager_Email.Text = _data["official_email"].ToString();
                        }
                       
                        _data1.Close();
                    }
                    
                    _data.Close();
                    ds.Close();
                }
                else
                {
                    lblApprover.Visible = false;
                    txtApprover.Visible = false;
                }
                query = "select * from leave_type";
                ds.RunQuery(out _data, query);
                while (_data.Read())
                {
                    drpLeaveType.Items.Add(new ListItem(_data["leave_type"].ToString(), _data["id"].ToString()));
                }
                _data.Close();
                ds.Close();
            }

                
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            DateTime Fromdate = DateTime.Today, Todate = DateTime.Today;
            Fromdate = DateTime.Parse(txtFromDate.Text);
            Todate = DateTime.Parse(txtToDate.Text);
            if (Fromdate > Todate)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Dates.')</script>");
            }
            else
            {
                    // check holiday list available for this dates.
                    bool res = checkholidaylist(txtToDate.Text);
                    if (res)
                    {
                        var duplicate = duplicate_check(txtFromDate.Text, txtToDate.Text);
                        if (!duplicate)
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('you are already applied vacation for this dates.')</script>");
                        }
                        else
                        {
                        // excludes holidays and weekends
                        double leave = Countleave(Fromdate, Todate);

                        query = "select remaining_leaves FROM employee_configuration where emp_id= " + Convert.ToInt32(Session["userId"]) + "";
                        ds.RunQuery(out _data, query);
                        while (_data.Read())
                        {
                            remaining_leaves = _data["remaining_leaves"].ToString();
                        }
                        _data.Close();
                        ds.Close();

                        if (Convert.ToInt32(remaining_leaves) - leave > -6)
                        {
                            query = "insert into leave_management(emp_id,type_id,from_date,to_date,description,approver_id,leaves) values (" + Convert.ToInt32(Session["userId"]) + "," + Convert.ToInt32(drpLeaveType.SelectedValue) + ",'" + txtFromDate.Text + "','" + txtToDate.Text + "','" + txtReason.Text + "'," + lblManager_Id.Text + "," + leave + ")";
                            var result = ds.RunCommand(query);
                            ds.Close();
                            if (result)
                            {
                                string fromEmail = "veerudon456@gmail.com";
                                //sending mail to manager
                                Mail(fromEmail, lblManager_Email.Text);
                                Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
                            }
                            else
                                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('error while applying vacation')</script>");
                        }
                        else

                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('No sufficient leaves to apply')</script>");
                    }
                }
            }
        }

        private double Countleave(DateTime Fromdate, DateTime Todate)
        {
            double leave = 0, diff, h = 0, w = 0;
            DataTable weeklyoffdays = (DataTable)Session["weekly_off"];
            DataTable holidaylist = (DataTable)Session["holiday"];
            

            diff = Todate.ToOADate() - Fromdate.ToOADate() + 1;
            while (0 != Fromdate.CompareTo(Todate))
            {
                foreach (DataRow row in weeklyoffdays.Rows)
                {
                    foreach (var weeklyoff in row.ItemArray)
                    {
                        if (weeklyoff.Equals(Convert.ToString(Fromdate.DayOfWeek)))
                            w++;
                    }
                }

                foreach (DataRow row in holidaylist.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        var get = (DateTime)item;
                        if (0 == get.CompareTo(Fromdate))
                            h++;
                    }
                }
                Fromdate = Fromdate.AddDays(1);
            }
            leave = diff - (w + h);
            return leave;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtReason.Text = null;
            txtFromDate.Text = null;
            txtToDate.Text = null;
        }

        private bool checkholidaylist(string todate)
        {
            DataTable holidaylist = (DataTable)Session["holiday"];
            var year = DateTime.Parse(todate).Year;
            int i = holidaylist.Rows.Count;
            var lastholidaydate = (DateTime)holidaylist.Rows[i - 1]["holiday_date"];
            if (year >= lastholidaydate.Year)
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Holiday list is not available for " + year + "')</script>");
                return false;
            }
            else
                return true;
        }

        public void Mail(string fromEmail, string toEmail)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);

            message.To.Add(new MailAddress(toEmail));
            message.Subject = "Leave Notification.";

            message.Body = "Hi" + " " + txtApprover.Text + "," + "<br/> <br/>" + Session["username"].ToString() + " " + "Applied leave and the Details as below" + "<br/> <br/>" + "Type" + " " + drpLeaveType.SelectedItem + " <br/> <br/> " + "From" + " " + txtFromDate.Text + "<br/> <br/>" + "To" + " " + txtToDate.Text + " " + "<br/> <br/>" + "Description" + " " + ":" + " " + txtReason.Text + "<br/> <br/>" + "<br/> <br/>" + "******This is an Autogenerated Email.******";

            message.IsBodyHtml = true;

            // finaly send the email:
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("veerudon456@gmail.com", "veerudon");

            smtp.EnableSsl = true;
            smtp.Send(message);
        }

        protected bool duplicate_check(string from, string to)
        {
            SqlDataReader _data2;
            query = (" select from_date,to_date from leave_management where ( (from_date BETWEEN '" + from + "'and '" + to + "') or (to_date BETWEEN '" + from + "'and '" + to + "') or (from_date >='" + from + "'and to_date <='" + to + "' or from_date<='" + from + "' and to_date >='" + to + "' ))");
            ds.RunQuery(out _data2, query);
            if (_data2.HasRows == true)
            {
                _data2.Close();
                ds.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('you already apply leave for this date')</script>");
                return false;
               
            }
            else
            { 
                _data2.Close();
                ds.Close();
                return true;
            }
        }

    }
}