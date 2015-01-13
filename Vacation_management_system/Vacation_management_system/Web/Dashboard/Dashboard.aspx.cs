using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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
        //Final project
        Queries ob = new Queries();
        Hashtable HolidayList = new Hashtable();
        DataSet dataSet = new DataSet();


        protected void Page_Load(object sender, EventArgs e)
        {
            string holiday = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection mycn = new SqlConnection(holiday);
            SqlDataAdapter myda = new SqlDataAdapter("Select * FROM holidays", mycn);
            myda.Fill(dataSet, "Table");

            if (!IsPostBack)
            {
                Database ds = new Database();
                lblBirth.Text = DateTime.Now.ToString("MMMM", new CultureInfo("en-US")) + "  Birthdays";
                try
                {
                    //profile information
                    string query = "select (first_name+' ' +last_name) as name, convert(varchar,date_of_join,103) as doj, emp_no, official_email,image_url from employee left join employee_additional on  employee.id= employee_additional.emp_id where employee.id= " + Session["userId"] + "";
                    SqlDataReader data;
                    ds.RunQuery(out data, query);

                    while (data.Read())
                    {

                        img_profile_pic.ImageUrl = data["image_url"].ToString();
                        lblUsername.Text = "<b>" + data["name"].ToString() + "</b>";
                        lblEmpno.Text = data["emp_no"].ToString();
                        lblDOJ.Text = data["doj"].ToString();
                        lblEmail.Text = data["official_email"].ToString();
                        lblRole.Text = Session["role_name"].ToString();

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
                        approve_count = Queries.VacationDetails("a", 0);
                        pending_count = Queries.VacationDetails("p", 0);
                        cancel_count = Queries.VacationDetails("c", 0);
                        reject_count = Queries.VacationDetails("r", 0);

                        lblApprovedVaction.Text = approve_count.ToString();
                        lblPendingVaction.Text = pending_count.ToString();
                        lblCancelVaction.Text = cancel_count.ToString();
                        lblrejectedVaction.Text = reject_count.ToString();
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
                catch (Exception)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //if (empImage.HasFile)
            //{

            //    //string filename = Path.GetFileName(empImage.PostedFile.FileName);
            //    //string ext = Path.GetExtension(filename);
            //    //filename =Session["userId"] + ext;
            //    //string profile_pic=null;
            //    //Database ds = new Database();
            //    //SqlDataReader data;
            //    //string query = "select image from employee_additional  WHERE emp_id=" + Session["userId"] + " ";
            //    //ds.RunQuery(out data, query);
            //    //while(data.Read())
            //    //{
            //    //    profile_pic = data["image"].ToString();
            //    //}
            //    //data.Close();
            //    //ds.Close();
            //    //string query1 = "UPDATE employee_additional SET image ='" + filename + "'  WHERE emp_id=" + Session["userId"] + "";
            //    // var res= ds.RunCommand(query1);
            //    //if(res)
            //    //{
            //    //    if (!profile_pic.Equals("Defalut.jpg"))
            //    //    {
            //    //        string path = Server.MapPath("~/Web/Images/" + profile_pic);
            //    //        FileInfo file = new FileInfo(path);
            //    //        file.Delete();
            //    //    }
            //    //    empImage.SaveAs(Server.MapPath("~/Web/Images/" + filename));
            //    //    Response.Redirect("Dashboard.aspx");

            //    //  // ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'> location.reload(); </script>");
            //    //}
            //    //else
            //    //    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error while updating image.')</script>");

            //    Database ds = new Database();

            //    string query = "update employee_additional SET image_file = " + empImage.FileBytes + " where emp_id= " +
            //                   Session["userId"];
            //    var res = ds.RunCommand(query);

            //    if (res == true)
            //    {
            //        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'> location.reload(); </script>");
            //    }
            //    else
            //    {
            //        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error while updating image.')</script>");
            //    }
            //}

            if (empImage.HasFiles == true)
            {
               
                    var image = empImage.FileBytes;
                    var imageName = empImage.FileName;
                    var imageUrl = "/Web/ImageHandler.ashx?emp_id=" + Session["userId"];

                    string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);

                    //var query = "insert employee_additional (emp_id,image_name,image_file,pan) values (23,@imageName,@image,'PANIMAGE')";

                    var query = "UPDATE employee_additional SET image_file=@image,image_url = @imageUrl where emp_id =" + Session["userId"];

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@imageUrl", imageUrl);
                    cmd.Parameters.AddWithValue("@image", image);
                    con.Open();

                    var res = cmd.ExecuteNonQuery();
                    con.Close();
                    //ds.RunCommand(query);
                    if (res == 1)
                    {
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation",
                            "<script language='javascript'>alert('Error while updating image.')</script>");
                    }
                    
                }

            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            if (!e.Day.IsOtherMonth)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    if ((dr["holiday_date"].ToString() != DBNull.Value.ToString()))
                    {
                        DateTime dtEvent = (DateTime)dr["holiday_date"];
                        if (dtEvent.Equals(e.Day.Date))
                        {
                            e.Cell.BackColor = Color.PowderBlue;
                            //e.Cell.Text = dr["holiday_name"].ToString();
                            Literal literal1 = new Literal();
                            literal1.Text = "<br/>";
                            e.Cell.Controls.Add(literal1);
                            Label label1 = new Label();
                            label1.Text = dr["holiday_name"].ToString();
                            label1.Font.Size = new FontUnit(FontSize.Small);
                            e.Cell.Controls.Add(label1);
                        }
                    }
                }
            }
            //If the month is not CurrentMonth then hide the Dates
            else
            {
                e.Cell.Text = "";
            }
        }
    }
}