using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Aguai_Leave_Management_System;
using System.Data.SqlClient;
using System.Data;



namespace Vacation_management_system.Web.Common
{
    public partial class BirthDay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BindDataList();
        }

        protected void BindDataList()
        {
            if (!IsPostBack)
            {
                Database ob = new Database();
                string query = " select top 5 (first_name+' ' +last_name) as name, (DATENAME(month, date_of_birth)+' '+DATENAME(DAY, date_of_birth)) as dob, image from employee join employee_additional on  employee.id= employee_additional.emp_id  where month(date_of_birth)=month(GETDATE()) and DATEADD(YEAR, DATEPART(YEAR, GETDATE()) - DATEPART(YEAR, date_of_birth), date_of_birth)  > GETDATE()-1 order by month(date_of_birth), day(date_of_birth)";
                SqlDataReader data;
                ob.RunQuery(out data, query);
                DataTable dt = new DataTable();
                dt.Load(data);
                dtlist.DataSource = dt;
                dtlist.DataBind();
                data.Close();
                ob.Close();
            }

        }
    }
}