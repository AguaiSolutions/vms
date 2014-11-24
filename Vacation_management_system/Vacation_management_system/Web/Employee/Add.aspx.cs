using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.Employee
{
    public partial class Add : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        protected void Page_Load(object sender, EventArgs e)
        {
            var employee_Id = Request.QueryString["id"];

               if (!IsPostBack)
                 {
                   btnupdate.Visible = false;
                string roles = "SELECT id,role_name FROM user_roles ORDER BY ID DESC";

                //  Datatable , Dataset , Datarow ,Datacolumn , Dataadapter

                ds.RunQuery(out _data, roles);
                while(_data.Read())
                {
                    drdRole.Items.Add(new ListItem(_data[1].ToString(), _data[0].ToString()));
                }
                _data.Close();
                ds.Close();

                drdRole_SelectedIndexChanged(sender, e);

               
            if(employee_Id!=null)
            
            {
                empImage.Visible = false;
                lblImage.Visible = false;
                btnSave.Visible = false;
                btnSaveandaddnew.Visible = false;
                btnupdate.Visible = true;
                SqlDataReader _data1;
                string employee_details = "select * from employee INNER JOIN employee_additional  on  employee.id=" + employee_Id + " and employee_additional.emp_id=" + employee_Id + "";
                ds.RunQuery(out _data1, employee_details);
                while(_data1.Read())
                {

                    txtEmpNo.Text = Convert.ToString(_data1["emp_no"]);
                    txtFirstName.Text = Convert.ToString(_data1["first_name"]);
                    txtLastName.Text = Convert.ToString(_data1["last_name"]);
                    drdGender.Text = Convert.ToString(_data1["gender"]);
                    txtPersonalEmail.Text = Convert.ToString(_data1["personal_email"]);
                    txtOfficialEmail.Text = Convert.ToString(_data1["official_email"]);
                    txtDOJ.Text = Convert.ToString(_data1["date_of_join"]);
                    txtDOB.Text = Convert.ToString(_data1["date_of_birth"]);
                    txtPAN.Text = Convert.ToString(_data1["pan"]);
                    txtPassport.Text = Convert.ToString(_data1["passport"]);
                    txtContactNo.Text = Convert.ToString(_data1["contact_number"]);
                    txtEmergencyNo.Text = Convert.ToString(_data1["emergency_contact_number"]);
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
        }

        protected void drdRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleID = Convert.ToInt32(drdRole.SelectedValue);
            Session["roleID"] = roleID;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            insertemployee();
            Response.Redirect("EmployeeList.aspx");
        }

        protected void insertemployee()
        {
            string password = generatePassword(8);
            string addEmployee =
                "insert into [employee] (emp_no,first_name,last_name,gender,personal_email,official_email,password,role_id,date_of_join,date_of_birth,contact_number,emergency_contact_number,permanent_address,temp_address) VALUES('" +
                txtEmpNo.Text.Trim() + "','" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" +
                drdGender.SelectedValue + "','" + txtPersonalEmail.Text.Trim() + "','" + txtOfficialEmail.Text.Trim() +
                "','" + password + "'," + Session["roleID"] + ",'" + txtDOJ.Text + "','" + txtDOB.Text + "','" +
                txtContactNo.Text.Trim() + "','" + txtEmergencyNo.Text.Trim() + "','" + txtLocalAdd.InnerText + "','" +
                txtPermanentAdd.InnerText + "') SELECT SCOPE_IDENTITY() ";
            Int64 empId = Convert.ToInt64(ds.ExecuteObjectQuery(addEmployee));
            string addEmpAdditional =
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image,ifsc_code) VALUES (" + empId + ",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                (txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim()) + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + empImage.FileName + "','" + txtIFSC.Text + "')";

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

        protected void btnSaveandAddNew_Click(object sender, EventArgs e)
        {
            insertemployee();
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
            Response.Redirect("Add.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            var employee_Id = Request.QueryString["id"];
            string update_query = "update employee set  emp_no='" + txtEmpNo.Text + "', first_name='" + txtFirstName.Text + "', last_name='" + txtLastName.Text + "', gender='" + drdGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + drdRole.Text + "', date_of_join='" + txtDOJ.Text + "', date_of_birth='" + txtDOB.Text + "', contact_number='" + txtContactNo.Text + "', emergency_contact_number='" + txtEmergencyNo.Text + "', permanent_address='" + txtPermanentAdd.InnerText + "', temp_address='" + txtLocalAdd.InnerText + "' where id=" + employee_Id + "";
            var res=  ds.RunCommand(update_query);
            string update_query1 = "update employee_additional set  bank_name='" + txtBankName.Text + "', bank_branch='" + txtBranchLocation.Text + "', holder_name='" + txtEmpNo.Text + "', account_number='" + txtEmpNo.Text + "', pan='" + txtEmpNo.Text + "', passport='" + txtEmpNo.Text + "', ifsc_code='" + txtEmpNo.Text + "' where emp_id=" + employee_Id + "";
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