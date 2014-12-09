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

namespace Vacation_management_system.Web.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butsignin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                var password = Utilities.EncodePassword(txtPassword.Text.Trim());

                var query =
                    "SELECT E.id,first_name,last_name,role_name,E.role_id FROM employee as E INNER JOIN user_roles on role_id = user_roles.id WHERE (emp_no=@login or official_email=@login) and password=@password and isactive=1";
                using (SqlCommand cmd =new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@login", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", password);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["id"] != null)
                        {
                            Session["role_id"] = dr["role_id"];
                            Session["role_name"] = dr["role_name"];
                            Session["UserName"] = Convert.ToString(dr["first_name"]) + " " + Convert.ToString(dr["last_name"]);
                            Session["userId"] = dr["id"]; 

                            dr.Close();
                            con.Close();
                            if (Request.QueryString["ReturnUrl"] != null)
                            {
                                Response.Redirect(Request.QueryString["ReturnUrl"]);
                            }
                            else
                            {
                                Response.Redirect("~/Web/Dashboard/Dashboard.aspx");
                            }

                           
                        }
                    }                  
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Enter the Correct Email / Employee No and Password')</script>");
                    }
                    dr.Close();
                    con.Close();
                }
            }

            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Email / Employee No or Password can't be empty')</script>");
            }

        }

    }
}