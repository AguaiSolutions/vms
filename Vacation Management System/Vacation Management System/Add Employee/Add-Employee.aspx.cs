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
    public partial class Add_Employee : System.Web.UI.Page
    {
        Database ds = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnSignUp_Click(object sender, EventArgs e)
        {
            //Register Page Details
            string query = "insert into EmployeeTable(FirstName,LastName,Gender,Email,Password,Date_of_Joining,Date_of_Birth,Contact,Address) values('" + txtFN.Text + "','" + txtLN.Text + "','" + ddlgender.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtDOJ.Text + "','" + txtDOB.Text + "','" + txtCON.Text + "','" + txtAddress.InnerText + "')";
            ds.RunCommand(query);
            ds.Close();

        } 
    }
}