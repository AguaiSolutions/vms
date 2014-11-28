using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;

namespace Vacation_management_system.Web.Employee
{
    public partial class Add : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string _query;
        private int _roleId, _managerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            var employeeId = Request.QueryString["id"];

            if (!IsPostBack)
            {
                btnupdate.Visible = false;
                _query = "SELECT id,role_name FROM user_roles ORDER BY ID DESC";

                //  Datatable , Dataset , Datarow ,Datacolumn , Dataadapter

                ds.RunQuery(out _data, _query);
                while (_data.Read())
                {
                    drdRole.Items.Add(new ListItem(_data[1].ToString(), _data[0].ToString()));
                }
                _data.Close();
                ds.Close();
                //select Manager

                _query = "SELECT id,first_name,last_name FROM employee where role_id < 3";

                ds.RunQuery(out _data, _query);

                while (_data.Read())
                {
                    drdManager.Items.Add(new ListItem(_data[1].ToString() + " " + _data[2].ToString(), _data[0].ToString()));
                }
                _data.Close();
                ds.Close();
                //!end 

                drdRole_SelectedIndexChanged(sender, e);

                drdManager_SelectedIndexChanged(sender, e);


                if (employeeId != null)
                {
                    empImage.Visible = false;
                    lblImage.Visible = false;
                    btnSave.Visible = false;
                    btnSaveandaddnew.Visible = false;
                    btnupdate.Visible = true;

                    _query = "select * from employee INNER JOIN employee_additional  on employee.id=employee_additional.emp_id where employee.id =" + employeeId + "";
                    ds.RunQuery(out _data, _query);
                    while (_data.Read())
                    {

                        txtEmpNo.Text = Convert.ToString(_data["emp_no"]);
                        txtFirstName.Text = Convert.ToString(_data["first_name"]);
                        txtLastName.Text = Convert.ToString(_data["last_name"]);
                        drdGender.Text = Convert.ToString(_data["gender"]);
                        txtPersonalEmail.Text = Convert.ToString(_data["personal_email"]);
                        txtOfficialEmail.Text = Convert.ToString(_data["official_email"]);
                        txtDOJ.Text = ((DateTime)_data["date_of_join"]).ToString("d");
                        txtDOB.Text = ((DateTime)_data["date_of_birth"]).ToString("d"); 
                        txtPAN.Text = Convert.ToString(_data["pan"]);
                        txtPassport.Text = Convert.ToString(_data["passport"]);
                        txtContactNo.Text = Convert.ToString(_data["contact_number"]);
                        txtEmergencyNo.Text = Convert.ToString(_data["emergency_contact_number"]);
                        txtPermanentAdd.InnerText = Convert.ToString(_data["permanent_address"]);
                        txtLocalAdd.InnerText = Convert.ToString(_data["temp_address"]);
                        txtBankName.Text = Convert.ToString(_data["bank_name"]);
                        txtBranchLocation.Text = Convert.ToString(_data["bank_branch"]);
                        txtAccountNo.Text = Convert.ToString(_data["account_number"]);
                        txtIFSC.Text = Convert.ToString(_data["ifsc_code"]);
                        txtAccountHolder.Text = Convert.ToString(_data["holder_name"]);
                        drdRole.SelectedIndex = Convert.ToInt32(_data["role_id"]);

                    }
                    _data.Close();
                }
            }
        }

        protected void drdRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _roleId = Convert.ToInt32(drdRole.SelectedValue);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DuplicateValidation() == 0)
            {
                Insertemployee();
                Response.Redirect("EmployeeList.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('The entered employee details already exists')</script>");
            }
        }

        protected void Insertemployee()
        {
            string RandomString = generateString(8);

            string password = Utilities.EncodePassword(RandomString);

            string DOB = ConvertDate(txtDOB.Text);

            string DOJ = ConvertDate(txtDOJ.Text);

            string addEmployee =
                "insert into [employee] (emp_no,first_name,last_name,gender,personal_email,official_email,password,role_id,date_of_join,date_of_birth,contact_number,emergency_contact_number,permanent_address,temp_address) VALUES('" +
                txtEmpNo.Text.Trim() + "','" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" +
                drdGender.SelectedValue + "','" + txtPersonalEmail.Text.Trim() + "','" + txtOfficialEmail.Text.Trim() +
                "','" + password + "'," + _roleId + ",'" + DOJ + "','" + DOB + "','" +
                txtContactNo.Text.Trim() + "','" + txtEmergencyNo.Text.Trim() + "','" + txtLocalAdd.InnerText + "','" +
                txtPermanentAdd.InnerText + "') SELECT SCOPE_IDENTITY() ";
            Int32 empId = Convert.ToInt32(ds.ExecuteObjectQuery(addEmployee));
            string addEmpAdditional =
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image,ifsc_code) VALUES (" + empId + ",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                txtAccountHolder.Text + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + empImage.FileName + "','" + txtIFSC.Text + "')";



            ds.RunCommand(addEmpAdditional);
            
            if (empId > 0)
            {
                CalReminingLeaves(empId, txtDOJ.Text);

                InsertManager(empId);

            }
        }

        public string ConvertDate(string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return dt.ToString("yyyy-MM-dd");
        }

        private void CalReminingLeaves(long empId, string p)
        {
            var currentLeaves = (12 - DateTime.Parse(p).Month + 1)*1.5;

            _query = "INSERT INTO employee_configuration (emp_id,current_year_leaves) values (" + empId + "," + currentLeaves + ")";
            ds.RunCommand(_query);
            

        }

        private string generateString(int length)
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
            Insertemployee();
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
            txtAccountHolder.Text = null;
            Response.Redirect("Add.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            var employee_Id = Request.QueryString["id"];
            _query = "update employee set  emp_no='" + txtEmpNo.Text + "', first_name='" + txtFirstName.Text + "', last_name='" + txtLastName.Text + "', gender='" + drdGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + drdRole.Text + "', date_of_join='" + ConvertDate(txtDOJ.Text) + "', date_of_birth='" + ConvertDate(txtDOB.Text) + "', contact_number='" + txtContactNo.Text + "', emergency_contact_number='" + txtEmergencyNo.Text + "', permanent_address='" + txtPermanentAdd.InnerText + "', temp_address='" + txtLocalAdd.InnerText + "' where id=" + employee_Id + "";
            var res = ds.RunCommand(_query);
            _query = "update employee_additional set  bank_name='" + txtBankName.Text + "', bank_branch='" + txtBranchLocation.Text + "', holder_name='" + txtAccountHolder.Text + "', account_number='" + txtAccountNo.Text + "', pan='" + txtPAN.Text + "', passport='" + txtPassport.Text + "', ifsc_code='" + txtIFSC.Text + "' where emp_id=" + employee_Id + "";
            var result = ds.RunCommand(_query);
            if (res && result)
            {
                Response.Redirect("EmployeeList.aspx");
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error while updating employee details')</script>");
        }

        public void InsertManager(int empId)
        {
            _query = "insert into manager (employee_id, manager_id) values (" + empId + "," + _managerId + ")";

            ds.RunCommand(_query);
            
        }

        public int DuplicateValidation()
        {
            _query =
                "IF EXISTS (SELECT * FROM employee WHERE emp_no='" + txtEmpNo.Text + "' OR first_name='" + txtFirstName.Text + "' OR last_name='" + txtLastName.Text + "' OR official_email='" + txtOfficialEmail + "')BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
            int value = Convert.ToInt32(ds.ExecuteObjectQuery(_query));

            return value;

        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }

        protected void drdManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            _managerId = Convert.ToInt32(drdManager.SelectedValue);
        }

    }
}
