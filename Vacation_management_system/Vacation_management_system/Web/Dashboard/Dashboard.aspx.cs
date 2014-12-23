using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aguai_Leave_Management_System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Collections;

using Vacation_management_system.Web.Common.Class;
namespace Vacation_management_system.Web.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Queries ob = new Queries();
        Hashtable HolidayList = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Database ds = new Database();
               // lblBirth.Text = DateTime.Now.ToString("MMMM", new CultureInfo("en-US"))+"  Birthdays";
               // DataTable dt = (DataTable)Session["holiday"];
               // DateTime now = DateTime.Now;
               //now=now.AddDays(-1);
               // var thisYearRows = dt.AsEnumerable().Where(r => r.Field<DateTime>("holiday_date").Year == now.Year && r.Field<DateTime>("holiday_date") >= now);
               //if (thisYearRows.Any())
               //{
               //     DataView dataview = thisYearRows.AsDataView();
               //     grdHolidayList.DataSource =dataview;
               //     grdHolidayList.DataBind();
               // }
                Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
                Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
                Calendar1.TitleFormat = TitleFormat.MonthYear;
                Calendar1.ShowGridLines = false;
                Calendar1.DayStyle.Height = new Unit(30);
                Calendar1.DayStyle.Width = new Unit(490);
                Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Center;
                Calendar1.DayStyle.VerticalAlign = VerticalAlign.Middle;
                Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;

                DataTable dt = (DataTable)Session["holiday"];
                DateTime now = DateTime.Now;
                now = now.AddDays(-1);
                var thisYearRows = dt.AsEnumerable().Where(r => r.Field<DateTime>("holiday_date").Year == now.Year);
                if (thisYearRows.Any())
                {
                    int k = 0;
                    for (k = 0; k < thisYearRows.Count(); k++)
                    {
                        var result = thisYearRows.ElementAt(k);
                        DateTime dt1 = (DateTime)result.ItemArray[1];

                        //string get = dt1.ToShortDateString();
                        //string fd = (string)result.ItemArray[0];
                        HolidayList[dt1.ToShortDateString()] = (string)result.ItemArray[0];

                    }
                }
                else
                    lblEmpty.Text = "No records found";
                
                //profile information
                string  query = "select (first_name+' ' +last_name) as name, convert(varchar,date_of_join,103) as doj, emp_no, official_email,  image from employee join employee_additional on  employee.id=" + Session["userId"] + " and employee_additional.emp_id=" + Session["userId"] + "";
                SqlDataReader data;
                ds.RunQuery(out data, query);

                while (data.Read())
                {
                    img_profile_pic.ImageUrl = "~/Web/Images/" + data["image"].ToString() + "?dt=" + DateTime.Now;
                    lblUsername.Text = "<b>" + data["name"].ToString() + "</b>";
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
                if (Session["role_ID"].Equals(1))
                {
                  //  ClientScript.RegisterStartupScript(Page.GetType(), "validation", "Hide_Row();");
                Row_id.Style.Add("display", "none");
                approve_count = Queries.VacationDetails("a" ,0);
                pending_count = Queries.VacationDetails("p",0);
                cancel_count = Queries.VacationDetails("c", 0);
                reject_count = Queries.VacationDetails("r", 0); 
                
                lblApprovedVaction.Text =  approve_count.ToString();
                lblPendingVaction.Text =  pending_count.ToString();
                lblCancelVaction.Text = cancel_count.ToString();
                lblrejectedVaction.Text = reject_count .ToString();
                }
                else
                {
                    approve_count = Queries.VacationDetails("a", Convert.ToInt32(Session["userId"]));
                    pending_count = Queries.VacationDetails("p", Convert.ToInt32(Session["userId"]));
                    cancel_count = Queries.VacationDetails("c", Convert.ToInt32(Session["userId"]));
                    reject_count = Queries.VacationDetails("r", Convert.ToInt32(Session["userId"]));
                    lblTotalVaction.Text = balance.ToString();
                    lblApprovedVaction.Text = approve_count.ToString();
                    lblPendingVaction.Text = pending_count.ToString();
                    lblCancelVaction.Text = cancel_count.ToString();
                    lblrejectedVaction.Text = reject_count.ToString();
                }

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

         protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
         {

             if (HolidayList[e.Day.Date.ToShortDateString()] != null)
             {
                 Literal literal1 = new Literal();
                 literal1.Text = "<br/>";
                 e.Cell.Controls.Add(literal1);
                 Label label1 = new Label();
                 label1.Text = (string)HolidayList[e.Day.Date.ToShortDateString()];
                 label1.Font.Size = new FontUnit(FontSize.Small);
                 e.Cell.Controls.Add(label1);
             }
         }

    }
}