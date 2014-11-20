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
    public partial class Login : System.Web.UI.Page
    {
        Database ds = new Database();
        SqlDataReader rd;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // for getting applied and remaining leaves for particular user in Employee Login
            Session["Email"] = txtEmail.Text;

            string query = "select * from EmployeeTable where Email='" + txtEmail1.Text + "'and password='" + txtpwd.Text + "'";
            ds.RunQuery(out rd, query);
 
            if (rd.Read())
            {
                if (rd["ID"] != null)
                {
                    Session["FirstName"] = rd["FirstName"];
                    Session["LastName"] = rd["LastName"];

                    //to get the user details for Admin page
                     Session["EmpID"] = rd["ID"];
                     Session["Emp_Reg_No"] = rd["Emp_Reg_No"];
                     Session["UserName"] = rd["UserName"];
                     Session["Email"] = rd["Email"];
                     Session["Contact"] = rd["Contact"];
                     Session["Address"] = rd["Address"];
                }        

                var IsActive = rd["isActive"];
                var IsAdmin = rd["isAdmin"];

                //for Employee Login
                if (Convert.ToInt32(IsActive) == 1 && Convert.ToInt32(IsAdmin) == 0)
                {
                    rd.Close();
                    Response.Redirect("~/Dashboard/Dashboard.aspx");
                }

                    //for Admin Login
                else if (Convert.ToInt32(IsActive) == 1 && Convert.ToInt32(IsAdmin) == 1)
                {
                    rd.Close();
                    Response.Redirect("~/Dashboard/Dashboard.aspx");      
                }

                    //If employee rejected
                else if (Convert.ToInt32(IsActive) == 2)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('User Acoount was Rejected')</script>");
                }

                    //If Username is inactive
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Username is not approved')</script>");
                }
            }

                //If username and password are incorrect
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
            rd.Close();
            ds.Close();
        }

        public void btnSignUp_Click(object sender, EventArgs e)
        {

            //Register Page Details
            string query = "insert into EmployeeTable(UserName,FirstName,LastName,Gender,Email,Password,Date_of_Joining,Date_of_Birth,Contact,Address) values('" + txtUsername.Text + "','" + txtFN.Text + "','" + txtLN.Text + "','" + ddlgender.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtDOJ.Text + "','" + txtDOB.Text + "','" + txtCON.Text + "','" + txtAddress.InnerText + "')";
            ds.RunCommand(query);
            ds.Close();

            Response.Redirect("~/Login/Login.aspx");
        }  
    }
}