using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.Empolyee
{
    public partial class Add : System.Web.UI.Page
    {

        Database ds = new Database();
        private SqlDataReader _data;
        protected void Page_Load(object sender, EventArgs e)
        {
            var employee_Id = 2;
            

               if (!IsPostBack)
                 {
                     btnupdate.Visible = false;
                string roles = "SELECT id,role_name FROM user_roles ORDER BY ID DESC";

                //  Datatable , Dataset , Datarow ,Datacolumn , Dataadapter

                ds.RunQuery(out _data, roles);
                while (_data.Read())
                {
                    drpRole.Items.Add(new ListItem(_data[1].ToString(), _data[0].ToString()));
                }
                _data.Close();
                ds.Close();

                drpRole_SelectedIndexChanged(sender, e);

                 }
            if(employee_Id==2)
            
            {
                imgEmployee.Visible = false;
                lblImage.Visible = false;
                btnAddEmployee.Visible = false;
                btnsaveandadd.Visible = false;
                btnupdate.Visible = true;
                SqlDataReader _data1;
                string employee_details = "select * from employee INNER JOIN employee_additional  on  employee.id=" + employee_Id + " and employee_additional.emp_id=" + employee_Id + "";
                ds.RunQuery(out _data1, employee_details);
                while(_data1.Read())
                {

                    txtEmpNo.Text = Convert.ToString(_data1["emp_id"]);
                    txtFirstName.Text = Convert.ToString(_data1["first_name"]);
                    txtLastName.Text = Convert.ToString(_data1["last_name"]);
                    drpGender.Text = Convert.ToString(_data1["gender"]);
                    txtPersonalEmail.Text = Convert.ToString(_data1["personal_email"]);
                    txtOfficialEmail.Text = Convert.ToString(_data1["official_email"]);
                    txtDOJ.Text = Convert.ToString(_data1["date_of_join"]);
                    txtDOB.Text = Convert.ToString(_data1["date_of_birth"]);
                    txtPAN.Text = Convert.ToString(_data1["pan"]);
                    txtPassport.Text = Convert.ToString(_data1["passport"]);
                    txtContactNo.Text = Convert.ToString(_data1["mobile_number"]);
                    txtEmergencyNo.Text = Convert.ToString(_data1["house_number"]);
                    txtPermanentAdd.InnerText = Convert.ToString(_data1["permanent_address"]);
                    txtLocalAdd.InnerText = Convert.ToString(_data1["temp_address"]);
                    txtBankName.Text = Convert.ToString(_data1["bank_name"]);
                    txtBranchLocation.Text = Convert.ToString(_data1["bank_branch"]);
                    txtAccountNo.Text = Convert.ToString(_data1["account_number"]);
                    txtIFSC.Text = Convert.ToString(_data1["ifsc_code"]);
                   
                }
                _data1.Close();
            }

        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleID = Convert.ToInt32(drpRole.SelectedValue);
            Session["roleID"] = roleID;
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {

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
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image) VALUES (" + empId + ",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                (txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()) + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + imgEmployee.FileName + "')";

            ds.RunCommand(addEmpAdditional);
            ds.Close();
            if (empId > 0)
            {
                calReminingLeaves(empId, txtDOJ.Text);
            }



        }

        private void calReminingLeaves(long empId, string p)
        {

            var date = DateTime.Parse(p);


            var month = date.Month;
            var currentLeaves = (12 - month) * 1.5;

            string empLeave = "INSERT INTO employee_configuration (emp_id,current_year_leaves) values (" + empId + "," + currentLeaves + ")";
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

        protected void btnSaveandAdd_Click(object sender, EventArgs e)
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

        protected void Update_Click(object sender, EventArgs e)
        {
            string update_query = "update employee set  emp_id='" + txtEmpNo.Text + "', first_name='" + txtFirstName.Text + "', last_name='" + txtLastName.Text + "', gender='" + drpGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + drpRole.Text + "', date_of_join='" + txtDOJ.Text + "', date_of_birth='" + txtDOB.Text + "', mobile_number='" + txtContactNo.Text + "', house_number='" + txtEmergencyNo.Text + "', permanent_address='" + txtPermanentAdd.InnerText + "', temp_address='" + txtLocalAdd.InnerText + "' where id=2";
            var res=  ds.RunCommand(update_query);
            string update_query1 = "update employee_additional set emp_id=2, bank_name='" + txtBankName.Text + "', bank_branch='" + txtBranchLocation.Text + "', holder_name='" + txtEmpNo.Text+ "', account_number='" + txtEmpNo.Text + "', pan='" + txtEmpNo.Text + "', passport='" + txtEmpNo.Text + "', ifsc_code='" + txtEmpNo.Text + "' where id=2";
            var result=  ds.RunCommand(update_query1);
            if(res && result)
            {
                Response.Redirect("EmployeeList.aspx");
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error while updating employee details')</script>");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }
    }
}