﻿using System;
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

namespace Aguai_Leave_Management_System
{
    public partial class ApplyLeave : System.Web.UI.Page
    {
        Database ds = new Database();
        SqlDataReader rd;
        List<DateTime> holidays = new List<DateTime>();
        string toAdminAddress = null;
        //Test
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["username"] != null)
                //{
                //    lblregno.Text += Session["Emp_Reg_No"].ToString();
                //}
               
            
                //populate  Type dropdown
                string query = "select * from leave_type";
                ds.RunQuery(out rd, query);
                while (rd.Read())
                {
                    ddltype.Items.Add(new ListItem(rd["leave_type"].ToString(), rd["id"].ToString()));
                }
                rd.Close();
                ds.Close();
               
                //populate  Approver dropdown
                string query1 = "select id, first_name,last_name from employee where id=2";
                ds.RunQuery(out rd, query1);
                while (rd.Read())
                {
                    //toAdminAddress = rd1["Email"].ToString();
                    ddlapprover.Items.Add(new ListItem(rd["first_name"].ToString() + " " + rd["last_name"].ToString(), rd["id"].ToString()));
                }
                rd.Close();
                ds.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            //check general holiday list is avaible for apply dates
             checkholidaylist(txtenddate.Text);

         
              // exclude general holidays and weekly offs
              double leave = numberOfLeaves(txtstartdate.Text, txtenddate.Text);

              string query3 = "insert into leave_management (emp_id,from_date,to_date,description,type_id,approver_id,leaves) values (5,'" + txtstartdate.Text + "','" + txtenddate.Text + "','" + txtdescription.InnerText + "'," + Convert.ToInt32(ddltype.SelectedValue) + "," + Convert.ToInt32(ddlapprover.SelectedValue) + "," + leave + ")";
              var res = ds.RunCommand(query3);
              ds.Close();
              if (res)
              {
                  string query2 = "select official_email from employee where id=" + ddlapprover.SelectedValue + "";
                  ds.RunQuery(out rd, query2);
                  while (rd.Read())
                  {
                      toAdminAddress = rd["official_email"].ToString();
                  }
                  rd.Close();
                  ds.Close();
                  var str = "Shreenidhi";
                  MailMessage message = new MailMessage();
                  message.From = new MailAddress("veerudon456@gmail.com");

                  message.To.Add(new MailAddress(toAdminAddress));
                  message.Subject = "Leave Notification.";

                  message.Body = "Hi" + " " + ddlapprover.SelectedItem + "," + "<br/> <br/>" + str + " " + "Applied leave and the Details as below" + "<br/> <br/>" + "Type" + " " + ddltype.SelectedItem + " <br/> <br/> " + "From" + " " + txtstartdate.Text + "<br/> <br/>" + "To" + " " + txtenddate.Text + " " + "<br/> <br/>" + "Description" + " " + ":" + " " + txtdescription.InnerText + "<br/> <br/>" + "<br/> <br/>" + "******This is an Autogenerated Email.******";

                  message.IsBodyHtml = true;

                  // finaly send the email:
                  SmtpClient smtp = new SmtpClient();
                  smtp.Host = "smtp.gmail.com";

                  smtp.Port = 587;
                  smtp.Credentials = new System.Net.NetworkCredential("veerudon456@gmail.com", "veerudon");

                  smtp.EnableSsl = true;
                  smtp.Send(message);

                  //insert apply leave data into database
                  Response.Redirect("~/AppliedLeaves/AppliedLeaves.aspx");
                 
              }
             
         
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //cleare the apply leave data while applying for leave
            ddltype.SelectedValue = null;
            txtdescription.InnerText = null;
            txtstartdate.Text = null;
            txtenddate.Text = null;
            ddlapprover.SelectedValue = null;
        }

        private double numberOfLeaves(string from, string to)
        {

            double diff, h = 0, w = 0;
            DataTable weeklyoffdays = (DataTable)Session["weekly_off"];
            DataTable holidaylist = (DataTable)Session["holiday"];
            DateTime Fromdate = DateTime.Today, Todate = DateTime.Today;
            Fromdate = DateTime.Parse(from);
            Todate = DateTime.Parse(to);

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
                    var get = (DateTime)row["holiday_date"];
                    if (0 == get.CompareTo(Fromdate))
                        h++;
                }
                Fromdate = Fromdate.AddDays(1);
            }
            
            return( diff - (w + h));
        }

        private void checkholidaylist(string todate)
        {
            DataTable holidaylist = (DataTable)Session["holiday"];
            var year = DateTime.Parse(todate).Year;
            int i = holidaylist.Rows.Count;
            var lastholidaydate = (DateTime)holidaylist.Rows[i-1]["holiday_date"];
            if (year>= lastholidaydate.Year)
            {
                lblResult.Visible = true;
                
                lblResult.Text = "Holiday list is not available";
                txtdescription.InnerText = null;
                txtstartdate.Text = null;
                txtenddate.Text = null;
               // ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('apply leave')</script>");
                Response.Redirect("ApplyLeave.aspx");
               
            }
        }
    }
}