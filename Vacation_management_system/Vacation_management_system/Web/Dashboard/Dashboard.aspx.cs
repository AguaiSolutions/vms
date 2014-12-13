using System;
using Aguai_Leave_Management_System;
using System.Data;
using System.Data.SqlClient;
namespace Vacation_management_system.Web.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database ds = new Database();
            string query = "select holiday_name as Name, holiday_date as Date from holidays";
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

            query = "select (first_name+' ' +last_name) as name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as dob, image from employee join employee_additional on  employee.id=" + Session["userId"] + " and employee_additional.emp_id=" +Session["userId"]+"";
            SqlDataReader data;
            ds.RunQuery(out data, query);
            while(data.Read())
            {
                img_profile_pic.ImageUrl = "~/Web/Images/" + data["image"].ToString();
                lblUsername.Text = data["name"].ToString();
                lblBirthday.Text = "BirthDay   " + data["dob"].ToString();
            }



        }
    }
}