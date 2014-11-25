using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.MyVacation
{
    public partial class ApplyNewVacation : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        List<DateTime> holidays = new List<DateTime>();
        string remaining_leaves = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Database ob = new Database();
                string query1 = "select week_off_days from weekly_off_days";
                SqlDataReader data;
                ob.RunQuery(out data, query1);
                DataTable weekly_dt = new DataTable();
                weekly_dt.Load(data);
                Session["weekly_off"] = weekly_dt;
                data.Close();
                ob.Close();

                string query2 = "select holiday_date from holidays";
                Database ob2 = new Database();
                SqlDataReader data2;
                ob2.RunQuery(out data2, query2);
                DataTable holiday = new DataTable();
                holiday.Load(data2);
                Session["holiday"] = holiday;
                data2.Close();
                ob2.Close();
                string query3 = "SELECT id,first_name,last_name,official_email from employee where id = (select manager_id from manager where employee_id = " + Convert.ToInt32(Session["userId"]) + ")";
                ds.RunQuery(out _data, query3);
                while (_data.Read())
                {
                    Session["Managerid"] = _data["id"];
                    Session["Manager"] = _data["first_name"].ToString() +" "+ _data["last_name"].ToString();
                    Session["toAdminAddress"] = _data["official_email"].ToString();
                }
                _data.Close();
                ds.Close();
  
                txtApprover.Text = Session["Manager"].ToString();

                string query5 = "select * from leave_type";
                ds.RunQuery(out _data, query5);
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
            Response.Redirect("~/Web/Dashboard/Dashboard.aspx");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            double leave = 0, diff, h = 0, w = 0;
            DataTable weeklyoffdays = (DataTable)Session["weekly_off"];
            DataTable holidaylist = (DataTable)Session["holiday"];
            DateTime Fromdate = DateTime.Today, Todate = DateTime.Today;
            Fromdate = DateTime.Parse(txtFromDate.Text);
            Todate = DateTime.Parse(txtToDate.Text);

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

            string query4 = "select remaining_leaves FROM employee_configuration where emp_id=" + Convert.ToInt32(Session["userId"]) + "";
            ds.RunQuery(out _data, query4);
            while (_data.Read())
            {
                remaining_leaves = _data["remaining_leaves"].ToString();
            }
            _data.Close();
            ds.Close();


            if (Convert.ToInt32(remaining_leaves)-leave > -6)
            {
                string query = "insert into leave_management(emp_id,type_id,from_date,to_date,description,approver_id,leaves) values (" + Convert.ToInt32(Session["userId"]) + "," + Convert.ToInt32(drpLeaveType.SelectedValue) + ",'" + txtFromDate.Text + "','" + txtToDate.Text + "','" + txtDescription.Text + "'," + Session["Managerid"] + "," + leave + ")";
                ds.RunCommand(query);
                ds.Close();

            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('You don't have enough leaves to apply')</script>");
            }

            MailMessage message = new MailMessage();
            message.From = new MailAddress("veerudon456@gmail.com");

            message.To.Add(new MailAddress(Session["toAdminAddress"].ToString()));
            message.Subject = "Leave Notification.";

            message.Body = "Hi" + " " + txtApprover.Text + "," + "<br/> <br/>" + Session["username"].ToString() + " " + "Applied leave and the Details as below" + "<br/> <br/>" + "Type" + " " + drpLeaveType.SelectedItem + " <br/> <br/> " + "From" + " " + txtFromDate.Text + "<br/> <br/>" + "To" + " " + txtToDate.Text + " " + "<br/> <br/>" + "Description" + " " + ":" + " " + txtDescription.Text + "<br/> <br/>" + "<br/> <br/>" + "******This is an Autogenerated Email.******";

            message.IsBodyHtml = true;

            // finaly send the email:
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("veerudon456@gmail.com", "veerudon");

            smtp.EnableSsl = true;
            smtp.Send(message);

            Response.Redirect("~/Web/MyVacation/MyVacation.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            drpLeaveType.SelectedValue = null;
            txtDescription.Text = null;
            txtFromDate.Text = null;
            txtToDate.Text = null;
        }
    }
}