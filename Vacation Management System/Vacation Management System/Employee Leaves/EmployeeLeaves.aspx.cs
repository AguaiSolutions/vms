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

namespace Aguai_Leave_Management_System
{
    public partial class EmployeeLeaves : System.Web.UI.Page
    {
        Database ds = new Database();
        SqlDataReader rd;
        string toAddress = null;
        string toUsername = null;
        double leave = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //btnReject.Attributes.Add("onClick", "return true;");
            if (!IsPostBack)
            {
                // here aprover is manager or admin
                string query = "SELECT  L.id,E.emp_id,E.first_name,L.from_date,L.to_date,L.description, leave_type.leave_type as Type,T.Approver, 'approval_status'= CASE L.approval_status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' then 'Cancel' END  FROM leave_management as L  left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id left join (select id,first_name as Approver from employee where id=2 ) as T on T.id = L.approver_id where L.approval_status='p' and L.approver_id = 2 and E.is_active=1 order by 1 DESC";
                ds.RunQuery(out rd, query);
                DataTable table = new DataTable();
                if (rd.HasRows == true)
                {
                    table.Load(rd);
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                   
                }
                else
                    lblResult.Text="No pending vacations records.";
                    rd.Close();
                    ds.Close();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT  L.id,E.emp_id,E.first_name,L.from_date,L.to_date,L.description,leave_type.leave_type as Type,T.Approver,'approval_status'= CASE L.approval_status  WHEN 'p' THEN 'Pending' WHEN 'a' THEN 'Approved' WHEN 'r' THEN 'Rejected' WHEN 'c' then 'Cancel' END,L.reason FROM leave_management as L left JOIN leave_type ON leave_type.id=L.type_id Left join employee as E on E.id = L.emp_id  left join (select ID,first_name as Approver from employee where role_id = 1) as T on T.id = L.approver_id where";

            string conjuction = " ";
            if (!(string.IsNullOrWhiteSpace(this.txtFirst.Text)))
            {
                cmd += conjuction;
                cmd += " " + "first_name like" + " " + "'%" + txtFirst.Text + "%'";
                conjuction = " OR ";

            }

            if (!(string.IsNullOrWhiteSpace(this.txtEmpId.Text)))
            {
                cmd += conjuction;
                cmd += " " + "E.emp_id like" + " " + "'%" + txtEmpId.Text + "%'";
                conjuction = " OR ";
            }

            if (!(string.IsNullOrWhiteSpace(this.txtLeaveType.Text)))
            {
                cmd += conjuction;
                cmd += " " + "leave_type.leave_type like" + " " + "'%" + txtLeaveType.Text + "%'";
                conjuction = " OR ";

            }



            if (!((string.IsNullOrWhiteSpace(this.txtFromDate.Text)) && (string.IsNullOrWhiteSpace(this.txtToDate.Text))))
            {
                cmd += conjuction;
                cmd += " " + "L.from_date >= " + " '" + txtFromDate.Text + "'AND";
                cmd += " " + "L.to_date <= '" + txtToDate.Text + "'";
                conjuction = " OR ";
            }

            var c = cmd; 
            
            ds.RunQuery(out rd, cmd);
            DataTable table1 = new DataTable();
            if (rd.HasRows == true)
            {
                lblResult.Text = null;
                table1.Load(rd);
                GridView1.DataSource = table1;
                GridView1.DataBind();
                GridView1.Visible = true;
                rd.Close();
                ds.Close();
            }
            else
            {
                lblResult.Text = "No records found.";
                GridView1.Visible = false;
            }

            txtFirst.Text = null;
            txtEmpId.Text = null;
            txtLeaveType.Text = null;
            txtFromDate.Text = null;
            txtToDate.Text = null;


        }

     
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Show Individual Leave Application with Id

            if (e.CommandName == "Approve")
            {
                string e_id=null;
                int id = Convert.ToInt32(e.CommandArgument);
                string query = "update leave_management  set approval_Status='a' where ID=" + id + "";
                var res = ds.RunCommand(query);
                ds.Close();
                if (res)
                {
                    string query1 = "SELECT L.id as LID,E.id as Emp,L.leaves, E.first_name,E.official_email FROM leave_management as L  Left join employee as E on E.id = L.emp_id  left join (select id, first_name as Approver from employee where role_id = 1) as T on T.id = L.approver_id where L.id =" + id + "";

                    ds.RunQuery(out rd, query1);

                    while (rd.Read())
                    {
                        toAddress = rd["official_email"].ToString();
                        toUsername = rd["first_name"].ToString();
                        leave = Convert.ToDouble(rd["leaves"]);
                        e_id=Convert.ToString(rd["Emp"]);
                    }
                    rd.Close();
                    ds.Close();
                    string update_leaves = "UPDATE employee_configuration SET remaining_leaves=(remaining_leaves-"+leave+") WHERE emp_id="+e_id+"";
                    var result= ds.RunCommand(update_leaves);
                    
                }


                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("veerudon456@gmail.com");

                    message.To.Add(new MailAddress(toAddress));

                    message.Subject = "Leave Notification.";

                    message.Body = "Hi" + " " + toUsername + "," + "<br/> <br/>" + "Your Leave was" + " " + "Approved" + "<br/> <br/>" + "<br/> <br/>" + "******This is an Autogenerated Email, Please do not Reply.******";

                    message.IsBodyHtml = true;

                    // finaly send the email:
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("veerudon456@gmail.com", "veerudon");

                    smtp.EnableSsl = true;
                    smtp.Send(message);

                    Response.Redirect("~/Employee Leaves/EmployeeLeaves.aspx");
                }

                if (e.CommandName == "Reject")
                {
                    Session["id"] = Convert.ToInt32(e.CommandArgument);

                     System.Text.StringBuilder sb = new System.Text.StringBuilder();
                     sb.Append(@"<script type='text/javascript'>");

                     sb.Append("$('#myModal').modal('show');");

                     sb.Append(@"</script>");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
               
               int cancel_id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Cancel")
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    //int idq = (int)GridView1.DataKeys[row.RowIndex].Value;
                  
                   if(row.Cells[8].Text.Equals("Approved"))
                   {
                       string e_id=null;
                       
                       string  query="SELECT E.id as Emp,L.leaves FROM leave_management as L  Left join employee as E on E.id = L.emp_id  left join (select id, first_name as Approver from employee where role_id = 1) as T on T.id = L.approver_id where L.id =" + cancel_id + "";
                      
                       ds.RunQuery(out rd,query);
                       while(rd.Read())
                       {
                        e_id = Convert.ToString(rd["Emp"]);
                        leave = Convert.ToDouble(rd["leaves"]);
                       
                       }
                       rd.Close();
                       ds.Close();
                       string query1="UPDATE employee_configuration SET remaining_leaves=(remaining_leaves+"+leave+") WHERE emp_id="+e_id+"";
                       string query2="update leave_management set approval_status='c' where id=" + cancel_id + "";
                       var res = ds.RunCommand(query1);
                       if (res)
                       {
                           var res1 = ds.RunCommand(query2);
                       }
                      

                   }
                   else
                   { 
                       string query = "INSERT INTO cancel_leave (cancel_leave.emp_id, cancel_leave.leave_id, reason) SELECT leave_management.emp_id, leave_management.id,leave_management.reason  FROM leave_management where leave_management.id=" + cancel_id + "";
                       string query1 = "update leave_management set approval_status='c' where id=" + cancel_id + "";
                       var rest = ds.RunCommand(query);
                       var res = ds.RunCommand(query1);
                       ds.Close();
                   }
                    
                }

                Response.Redirect("~/Employee Leaves/EmployeeLeaves.aspx");
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lbtApprove = (LinkButton)e.Row.FindControl("btnApprove");
            LinkButton lbtReject = (LinkButton)e.Row.FindControl("btnReject");
            LinkButton lbtCancel = (LinkButton)e.Row.FindControl("lbtnCancel");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                if(e.Row.Cells[8].Text.Equals("Approved"))
                {
                    lbtApprove.Enabled = false;
                    lbtReject.Enabled = false;
                   
                }
                else
                    if (e.Row.Cells[8].Text.Equals("Rejected") || e.Row.Cells[8].Text.Equals("Cancel"))
                    {
                        lbtApprove.Enabled = false;
                        lbtCancel.Enabled = false;
                        lbtReject.Enabled = false;
                    }
                
            }
        }
       

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string query = "update[dbo].[LeaveManagement]  set Approval_Status=2 where ID=" + Session["id"] + "";
            ds.RunCommand(query);
            ds.Close();

            string query1 = "SELECT L.ID as LID,E.ID as Emp,E.UserName,E.Email FROM LeaveManagement as L  Left join EmployeeTable as E on E.ID = L.EmpID  left join (select ID,UserName as Approver from EmployeeTable where IsAdmin = 1) as T on T.ID = L.Approver_ID where L.ID =" + Session["id"] + "";

            ds.RunQuery(out rd, query1);

            while (rd.Read())
            {
                toAddress = rd["Email"].ToString();
                toUsername = rd["UserName"].ToString();
            }
            rd.Close();
            ds.Close();

            MailMessage message = new MailMessage();
            message.From = new MailAddress("veerudon456@gmail.com");

            message.To.Add(new MailAddress(toAddress));

            message.Subject = "Leave Notification.";

            message.Body = "Hi" + " " + toUsername + "," + "<br/> <br/>" + "Your Leave was" + " " + "Rejected" + "<br/> <br/>" + "<br/> <br/>" + "******This is an Autogenerated Email, Please do not Reply.******";

            message.IsBodyHtml = true;

            // finaly send the email:
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("veerudon456@gmail.com", "veerudon");

            smtp.EnableSsl = true;
            smtp.Send(message);

            Response.Redirect("~/Employee Leaves/EmployeeLeaves.aspx");
        }
    }
}