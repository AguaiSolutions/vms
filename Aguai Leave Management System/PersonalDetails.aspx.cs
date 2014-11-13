using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Aguai_Leave_Management_System
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    lblregno.Text += Session["Emp_Reg_No"].ToString();
                    lblemp.Text += Session["UserName"].ToString();
                    lblemail.Text += Session["Email"].ToString();
                    lblcont.Text += Session["Contact"].ToString();
                    lbladdress.Text += Session["Address"].ToString();
                }
            }    
        }
    }
}