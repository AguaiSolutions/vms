using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vacation_management_system.Web.Common;


namespace Vacation_management_system.Web.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private Utilities utilities;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butsignin_Click(object sender, EventArgs e)
        {
            utilities=new Utilities();
            if (txtUsername.Text != null && txtPassword.Text != null)
            {
                string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                using (SqlCommand cmd =new SqlCommand("SELECT id, password,first_name,last_name,role_id FROM employee WHERE (emp_no=@login or official_email=@login) and isactive=1",con))
                {
                    cmd.Parameters.AddWithValue("@login", txtUsername.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["id"] != null)
                        {
                            Session["role_ID"] = dr["role_id"];
                            Session["UserName"] = Convert.ToString(dr["first_name"]) + Convert.ToString(dr["last_name"]);
                            Session["userId"] = dr["id"];
                            string dbPassword = Convert.ToString(dr["password"]);

                            string hashedPassword = utilities.EncodePassword(txtPassword.Text.Trim());

                            if (utilities.ComparePassword(dbPassword, hashedPassword) == true)
                            {
                                dr.Close();
                               Response.Redirect("~/Web/Dashboard/Dashboard.aspx");
                            }
                            else
                            {
                               ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Enter the Correct Password')</script>");
                            }

                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Enter the Correct EmpNo/Email or Password')</script>");
                    }
                    dr.Close();
                    con.Close();
                }



            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('EmpNo/Email or Password should not be empty')</script>");
            }

        }

    }
}