using System;
using Aguai_Leave_Management_System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                query = "select (first_name+' ' +last_name) as name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as dob, image from employee join employee_additional on  employee.id=" + Session["userId"] + " and employee_additional.emp_id=" + Session["userId"] + "";
                SqlDataReader data;
                ds.RunQuery(out data, query);

                while (data.Read())
                {
                    img_profile_pic.ImageUrl = "~/Web/Images/" + data["image"].ToString();
                    lblUsername.Text = data["name"].ToString();
                    lblBirthday.Text = "BirthDay   <b>:</b> " + data["dob"].ToString();
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
                lblTotalVaction.Text = "Available  Vacations      :<b>" + balance + "</b>";
                lblApprovedVaction.Text = "Approved Vacations      :<b>" + approve_count + "</b>";
                lblPendingVaction.Text = "Non Approved Vactions    :<b>" + pending_count + "</b>";
                lblCancelVaction.Text = "Canceled Vactions     :<b>" + cancel_count + "</b>";
                lblrejectedVaction.Text = "Rejected Vactions   :<b>" + reject_count + "</b>";

            }
        }
    }
}