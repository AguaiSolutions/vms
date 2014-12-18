﻿using System;
using Aguai_Leave_Management_System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using Vacation_management_system.Web.Common.Class;
namespace Vacation_management_system.Web.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Queries ob = new Queries();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Database ds = new Database();
                lblBirth.Text = DateTime.Now.ToString("MMMM", new CultureInfo("en-US"))+"  Birthdays";
                string query = "select holiday_name as Name,CONVERT(varchar,holiday_date,103) as Date from holidays where year(holiday_date)=year(getdate())";
                SqlDataReader _data;
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                if (_data.HasRows == true)
                {
                    table.Load(_data);
                    grdHolidayList.DataSource = table;
                    grdHolidayList.DataBind();
                }
                else
                    lblEmpty.Text = "No records found";
                _data.Close();
                ds.Close();

                //profile information
                query = "select (first_name+' ' +last_name) as name, convert(varchar,date_of_join,103) as doj, emp_no, official_email,  image from employee join employee_additional on  employee.id=" + Session["userId"] + " and employee_additional.emp_id=" + Session["userId"] + "";
                SqlDataReader data;
                ds.RunQuery(out data, query);

                while (data.Read())
                {
                    img_profile_pic.ImageUrl = "~/Web/Images/" + data["image"].ToString() + "?dt=" + DateTime.Now;
                    lblUsername.Text = "<b>&nbsp;&nbsp;" + data["name"].ToString() + "</b>";
                    lblEmpno.Text = data["emp_no"].ToString();
                    lblDOJ.Text =  data["doj"].ToString();
                    lblEmail.Text = data["official_email"].ToString();
                   
                }

                data.Close();
                ds.Close();

                //vacation summary
                double balance, currentVaction, previousVacation;
                Int32 approve_count, pending_count, cancel_count, reject_count;
                ob.employees_leave_balance(out balance, out currentVaction, out previousVacation, Convert.ToInt32(Session["userId"]));
                approve_count = Queries.VacationDetails("a", Convert.ToInt32(Session["userId"]));
                pending_count = Queries.VacationDetails("p", Convert.ToInt32(Session["userId"]));
                cancel_count = Queries.VacationDetails("c", Convert.ToInt32(Session["userId"]));
                reject_count = Queries.VacationDetails("r", Convert.ToInt32(Session["userId"]));
                lblTotalVaction.Text = balance.ToString() ;
                lblApprovedVaction.Text =  approve_count.ToString();
                lblPendingVaction.Text =  pending_count.ToString();
                lblCancelVaction.Text = cancel_count.ToString();
                lblrejectedVaction.Text = reject_count .ToString();

            }
        }

         protected void  btnUpload_Click(object sender, EventArgs e)
        {
            if (empImage.HasFile)
            {

                string filename = Path.GetFileName(empImage.PostedFile.FileName);
                string ext = Path.GetExtension(filename);
                filename =Session["userId"] + ext;
                string profile_pic=null;
                Database ds = new Database();
                SqlDataReader data;
                string query = "select image from employee_additional  WHERE emp_id=" + Session["userId"] + " ";
                ds.RunQuery(out data, query);
                while(data.Read())
                {
                    profile_pic = data["image"].ToString();
                }
                data.Close();
                ds.Close();
                string query1 = "UPDATE employee_additional SET image ='" + filename + "'  WHERE emp_id=" + Session["userId"] + "";
                 var res= ds.RunCommand(query1);
                if(res)
                {
                    if (!profile_pic.Equals("Defalut.jpg"))
                    {
                        string path = Server.MapPath("~/Web/Images/" + profile_pic);
                        FileInfo file = new FileInfo(path);
                        file.Delete();
                    }
                    empImage.SaveAs(Server.MapPath("~/Web/Images/" + filename));
                    Response.Redirect("Dashboard.aspx");
                   
                  // ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'> location.reload(); </script>");
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error while updating image.')</script>");

            }
        }

    }
}