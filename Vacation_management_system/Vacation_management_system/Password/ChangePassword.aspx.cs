using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;
using Aguai_Leave_Management_System;
using System.Data;

namespace Vacation_management_system.Web.Login
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var p_id = Request.QueryString["Id"];
                var email = Request.QueryString["Email"];
                Int32 is_active = 0;
                txtEmail.Text = email;
                Database ob = new Database();
                SqlDataReader data;
                string query = "select is_active from password_reset where id=" + p_id + "";
                ob.RunQuery(out data, query);
                while (data.Read())
                {
                    is_active = Convert.ToInt32(data["is_active"]);
                }
                data.Close();
                ob.Close();
                if (is_active == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " validatelink();", true);
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Database ob = new Database();
            string query = "update employee set password='"+Utilities.EncodePassword(txtNewpassword.Text.Trim())+"' where official_email='"+txtEmail.Text+"'";
            var res=  ob.RunCommand(query);
            query = "update password_reset set is_active=0";
             var res1= ob.RunCommand(query);
                      
            if(res && res1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "confirmation();", true);
        
            }
            else
            ClientScript.RegisterStartupScript(Page.GetType(), "validation"," <script language='javascript'>alert('Error while reseting password. ')</script>");
            }
        }
    }
