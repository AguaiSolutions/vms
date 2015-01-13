using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;
using System.Globalization;
using Vacation_management_system.Web.Common.Class;


namespace Vacation_management_system.Web.Login
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = null;
            string msg;
            Database ob = new Database();
            DateTime dob;
            var xxsd = DateTime.TryParseExact(txtdob.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                      out dob);
            string query = "select (first_name+' '+last_name) as name from employee where official_email='" + txtEmail.Text + "' and date_of_birth='" + dob.ToShortDateString() + "'";
            SqlDataReader data;
            ob.RunQuery(out data, query);
            if (data.HasRows)
            {
                while (data.Read())
                {
                    name = Convert.ToString(data["name"]);
                }
            }
            else
            {
                msg = "<script language='javascript'>alert('Please Enter correct Email/Date of birth')</script>";
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", msg);
            }

            data.Close();
            ob.Close();

            if (name != null)
            {
                query = "insert into password_reset(email) values ('" + txtEmail.Text + "') SELECT SCOPE_IDENTITY()";
                Int32 Id = Convert.ToInt32(ob.ExecuteObjectQuery(query));
                Email mail = new Email();
                var url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Password/ChangePassword.aspx?id=" + Id + "&Email=" + txtEmail.Text + "";
                mail.ForgotPassword(name, txtEmail.Text, url);
                msg = "<script language='javascript'>alert('we sent you a password reset link to your mail id. ')</script>";
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", msg);
            }
            txtdob.Text = "";
            txtEmail.Text = "";

        }

    }
}