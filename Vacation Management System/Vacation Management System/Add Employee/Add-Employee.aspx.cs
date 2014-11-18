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
        private SqlDataReader _data;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string roles = "SELECT id,role_name FROM user_roles ORDER BY ID DESC";

                //  Datatable , Dataset , Datarow ,Datacolumn , Dataadapter

                ds.RunQuery(out _data, roles);
                while (_data.Read())
                {
                    drpRole.Items.Add(new ListItem(_data[1].ToString(), _data[0].ToString()));
                }
                _data.Close();

                drpRole_SelectedIndexChanged(sender, e);

            }

        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleID = Convert.ToInt32(drpRole.SelectedValue);
            Session["roleID"] = roleID;
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var connstring = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);

            string password = generatePassword(8);
            string addEmployee =
                "insert into [employee] (emp_no,first_name,last_name,gender,personal_email,official_email,password,role_id,date_of_join,date_of_birth,contact_number,emergency_contact_number,permanent_address,temp_address) VALUES('" +
                txtEmpNo.Text.Trim() + "','" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" +
                drpGender.SelectedValue + "','" + txtPersonalEmail.Text.Trim() + "','" + txtOfficialEmail.Text.Trim() +
                "','" + password + "'," + Session["roleID"] + ",'" + txtDOJ.Text + "','" + txtDOB.Text + "','" +
                txtContactNo.Text.Trim() + "','" + txtEmergencyNo.Text.Trim() + "','" + txtLocalAdd.InnerText + "','" +
                txtPermanentAdd.InnerText + "') SELECT SCOPE_IDENTITY() ";
            Int64 empId = Convert.ToInt64(ds.ExecuteObjectQuery(addEmployee));
            string addEmpAdditional =
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image) VALUES ("+empId+",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                (txtFirstName.Text.Trim() +" "+ txtLastName.Text.Trim()) + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + imgEmployee.FileName + "')";
            
            ds.RunCommand(addEmpAdditional);
            ds.Close();
            if (empId > 0)
            {
                calReminingLeaves(empId, txtDOJ.Text);
            }
            

            btnClear_Click(sender,e);

        }

        private void calReminingLeaves(long empId, string p)
        {

            var date = DateTime.Parse(p);
           
           
            var month = date.Month;
            var currentLeaves = (12 - month) * 1.5;

            string empLeave = "INSERT INTO employee_configuration (emp_id,current_year_leaves) values ("+empId+","+currentLeaves+")";
            ds.RunCommand(empLeave);
            ds.Close();

        }

        private string generatePassword(int length)
        {

            string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            string allowedNumberChars = "23456789";
            char[] chars = new char[length];
            Random rd = new Random();

            bool useLetter = true;
            for (int i = 0; i < length; i++)
            {
                if (useLetter)
                {
                    chars[i] = allowedLetterChars[rd.Next(0, allowedLetterChars.Length)];
                    useLetter = false;
                }
                else
                {
                    chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                    useLetter = true;
                }

            }

            return new string(chars);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmpNo.Text = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtPersonalEmail.Text = null;
            txtOfficialEmail.Text = null;
            txtDOJ.Text = null;
            txtDOB.Text = null;
            txtContactNo.Text = null;
            txtEmergencyNo.Text = null;
            txtLocalAdd.InnerText = null;
            txtPermanentAdd.InnerText = null;
            txtBankName.Text = null;
            txtBranchLocation.Text = null;
            txtAccountNo.Text = null;
            txtPAN.Text = null;
            txtPassport.Text = null;
        }
    }
}