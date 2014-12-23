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
    public partial class ApplyNewVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        double remaining_leaves, current_year_vacations, previous_year_vacations, temp;
        private string query;
        ApplyVacation vacation = new ApplyVacation();
        Queries query_object = new Queries();
        Int32 user_id;
    
        string msg;
        int year;
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Convert.ToInt32(Session["userId"]);
            if (!IsPostBack)
            {
                query = "SELECT  id,CONVERT(varchar,from_date,103)as from_date,CONVERT(varchar,to_date,103)as to_date,'approval_status'= CASE approval_status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' END from leave_management where (approval_status='p' or approval_status='a') and emp_id=" + user_id + "";
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                if (_data.HasRows == true)
                {
                    table.Load(_data);
                    gvVacation.DataSource = table;
                    gvVacation.DataBind();
                }
                else
                    lblEmpty.Text = "No records found";
                _data.Close();
                ds.Close();

                if (!(Session["role_ID"].ToString().Equals("1")))
                {
                    query = "SELECT id,first_name,last_name,official_email from employee where id = (select manager_id from manager where employee_id = " + user_id + ")";
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
                        _data.Close();
                        ds.Close();
                        query = "SELECT id,first_name,last_name,official_email from employee where role_id=1";
                        ds.RunQuery(out _data, query);
                        while (_data.Read())
                        {
                            lblManager_Id.Text = _data["id"].ToString();
                            txtApprover.Text = _data["first_name"].ToString() + " " + _data["last_name"].ToString();
                            lblManager_Email.Text = _data["official_email"].ToString();
                        }


                    }

                    _data.Close();
                    ds.Close();
                }
                else
                {
                    lblApprover.Visible = false;
                    txtApprover.Visible = false;
                }
                //leave type dropdown list filling
                vacation.leavetype(drpLeaveType);

            }
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            DateTime Fromdate = DateTime.Today, Todate = DateTime.Today;
            var xxsd = DateTime.TryParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Fromdate);
                xxsd = DateTime.TryParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Todate);

           //Fromdate = DateTime.Parse(txtFromDate.Text);
            //Todate = DateTime.Parse(txtToDate.Text);
            DataTable weeklyoffdays = (DataTable)Session["weekly_off"];
            DataTable holidaylist = (DataTable)Session["holiday"];
            if (Fromdate > Todate)
            {
                msg = "<script language='javascript'>alert('Please enter correct dates.')</script>";
                alert(msg);

            }
            else
            {
                // check holiday list available for this dates.
                bool res = vacation.checkholidaylist(Todate, holidaylist, out year);
                if (res)
                {
                    var duplicate = vacation.duplicate_check(Fromdate, Todate, user_id);
                    if (!duplicate)
                    {
                        msg = "<script language='javascript'>alert('you are already applied vacation for this dates.')</script>";
                        alert(msg);
                    }
                    else
                    {
                        // excludes holidays and weekends
                        double leave = vacation.Countleave(Fromdate, Todate, weeklyoffdays, holidaylist);
                        query_object.employees_leave_balance(out remaining_leaves, out  current_year_vacations, out previous_year_vacations, user_id);

                        if (remaining_leaves - leave >= 0)
                        {
                            bool update_result = false;
                            if (leave != 0)
                            {
                                if (previous_year_vacations >= leave)
                                {
                                    previous_year_vacations = previous_year_vacations - leave;
                                    update_result = query_object.updateEmployeeLeaves(user_id, previous_year_vacation: previous_year_vacations);
                                }
                                else if (previous_year_vacations != 0)
                                {
                                    temp = previous_year_vacations - leave;
                                    previous_year_vacations = temp;
                                    current_year_vacations = current_year_vacations + temp;
                                    update_result = query_object.updateEmployeeLeaves(user_id, current_year_vacations, previous_year_vacations);
                                }
                                else
                                {
                                    current_year_vacations = current_year_vacations - leave;
                                    update_result = query_object.updateEmployeeLeaves(user_id, current_year_vacation: current_year_vacations);
                                }
                            }
                            else
                                update_result = true;

                            query = "insert into leave_management(emp_id,type_id,from_date,to_date,description,approver_id,leaves) values (" + user_id + "," + Convert.ToInt32(drpLeaveType.SelectedValue) + ",'" + Fromdate + "','" + Todate + "','" + txtReason.Text + "'," + lblManager_Id.Text + "," + leave + ") SELECT SCOPE_IDENTITY()";
                            Int32 leave_Id = Convert.ToInt32(ds.ExecuteObjectQuery(query));
                           // var result = ds.RunCommand(query);

                            ds.Close();
                            if (leave_Id!=0 && update_result)
                            {
                                //string fromEmail = "veerudon456@gmail.com";
                                //sending mail to manager
                                // Mail(fromEmail, lblManager_Email.Text); 
                                Email mail = new Email();
                                var url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Web/Login/Login.aspx?ReturnUrl=~/web/EmployeeVacation/EmployeeVacation.aspx?id="+leave_Id+"";
           
                                mail.VacationRequestEmail(txtApprover.Text, lblManager_Email.Text, Session["UserName"].ToString(), txtFromDate.Text, txtToDate.Text, leave.ToString(), txtReason.Text,url);
                                msg = "<script language='javascript'>alert('you successfully requested for vacation ')</script>";
                                alert(msg);
                                Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
                            }
                            else
                                msg = "<script language='javascript'>alert('error while applying vacation, please try again')</script>";
                            alert(msg);
                        }
                        else
                            msg = "<script language='javascript'>alert('No sufficient leaves to apply')</script>";
                        alert(msg);

                    }

                }
                else
                {
                    msg = "<script language='javascript'>alert('Holiday list is not available for " + year + "')</script>";
                    alert(msg);
                }
            }
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtReason.Text = null;
            txtFromDate.Text = null;
            txtToDate.Text = null;
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

        private void alert(string message)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", message);
        }

    }
}