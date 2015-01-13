using System;
using System.Configuration;
using System.Web;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;
using System.Web.UI;
using AjaxControlToolkit;
using Vacation_management_system.Web.Common.Class;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

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
                lblTitle.Text = lblEmployee.Text = "Add Employee";

                txtDor.Visible = lblDor.Visible = lblDeactivate.Visible = cdInactive.Visible = btnupdate1.Visible = btnupdate.Visible = false;

                icon.Attributes["class"] = "fa fa-plus";

                _query = " SELECT id,role_name FROM user_roles where role_name NOT IN ('Admin') ORDER BY ID DESC";

                //  Datatable , Dataset , Datarow ,Datacolumn , Dataadapter

                ds.RunQuery(out _data, _query);
                while (_data.Read())
                {
                    drdRole.Items.Add(new ListItem(_data[1].ToString(), _data[0].ToString()));
                }
                _data.Close();
                ds.Close();
                //select Manager


                _query = "SELECT id,first_name,last_name FROM employee where role_id  in (SELECT id FROM user_roles where role_name like '%manager%') ";

                ds.RunQuery(out _data, _query);

                while (_data.Read())
                {
                    drdManager.Items.Add(new ListItem(_data[1].ToString() + " " + _data[2].ToString(), _data[0].ToString()));
                }
                _data.Close();

                ds.Close();
                //!end 

                if (employeeId != null)
                {
                    lblTitle.Text = lblEmployee.Text = "Edit Employee";

                    txtDOJ.ReadOnly = true;

                    btnSaveandaddnew1.Visible = btnSave1.Visible = btnSaveandaddnew.Visible = btnSave.Visible = lblImage.Visible = empImage.Visible = false;

                    txtDor.Visible = lblDor.Visible = lblDeactivate.Visible = btnupdate1.Visible = btnupdate.Visible = cdInactive.Visible = true;

                    icon.Attributes["class"] = "fa fa-cog";

                    _query = "select * from employee INNER JOIN employee_additional  on employee.id=employee_additional.emp_id where employee.id =" + employeeId + "";
                    ds.RunQuery(out _data, _query);
                    while (_data.Read())
                    {

                        txtEmpNo.Text = Convert.ToString(_data["emp_no"]);
                        txtFirstName.Text = Utilities.convertToSingleQuote(Convert.ToString(_data["first_name"]));
                        txtLastName.Text = Utilities.convertToSingleQuote(Convert.ToString(_data["last_name"]));
                        drdGender.Text = Convert.ToString(_data["gender"]);
                        txtPersonalEmail.Text = Convert.ToString(_data["personal_email"]);
                        txtOfficialEmail.Text = Convert.ToString(_data["official_email"]);
                        txtDOJ.Text = Convert.ToDateTime(_data["date_of_join"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        txtDOB.Text = Convert.ToDateTime(_data["date_of_birth"]).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        txtPAN.Text = Convert.ToString(_data["pan"]);
                        txtPassport.Text = Convert.ToString(_data["passport"]);
                        txtContactNo.Text = Convert.ToString(_data["contact_number"]);
                        txtEmergencyNo.Text = Convert.ToString(_data["emergency_contact_number"]);
                        txtPermanentAdd.Text = Convert.ToString(_data["permanent_address"]);
                        txtLocalAdd.Text = Convert.ToString(_data["temp_address"]);
                        txtBankName.Text = Convert.ToString(_data["bank_name"]);
                        txtBranchLocation.Text = Convert.ToString(_data["bank_branch"]);
                        txtAccountNo.Text = Convert.ToString(_data["account_number"]);
                        txtIFSC.Text = Convert.ToString(_data["ifsc_code"]);
                        txtAccountHolder.Text = Convert.ToString(_data["holder_name"]);
                        drdRole.SelectedValue = _data["role_id"].ToString();

                    }
                    _data.Close();
                    ds.Close();

                    _query = "select manager_id from manager where employee_id = " + employeeId + "";
                    try
                    {
                        drdManager.SelectedValue = (ds.ExecuteObjectQuery(_query)).ToString();
                    }
                    catch (Exception)
                    {
                        drdManager.SelectedValue = "0";
                    }
                    
                }
            }
        }

        protected void drdRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _roleId = Convert.ToInt32(drdRole.SelectedValue);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            drdManager_SelectedIndexChanged(sender, e);
            drdRole_SelectedIndexChanged(sender, e);
            if (DuplicateValidation() == 0)
            {
                Insertemployee();
                Response.Redirect("~/Web/Employee/EmployeeList/EmployeeList.aspx");
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
            string filename = Path.GetFileName(empImage.PostedFile.FileName);
            string ext = Path.GetExtension(filename);
            var imageUrl = "/Web/Images/DefaultImage.JPG";
            DateTime doj, dob;

            DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out doj);

            DateTime.TryParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob);
            string addEmployee =
                "insert into [employee] (emp_no,first_name,last_name,gender,personal_email,official_email,password,role_id,date_of_join,date_of_birth,contact_number,emergency_contact_number,permanent_address,temp_address) VALUES('" +
                txtEmpNo.Text.Trim() + "','" + Utilities.convertQuotes(txtFirstName.Text.Trim()) + "','" + Utilities.convertQuotes(txtLastName.Text.Trim()) + "','" +
                drdGender.SelectedValue + "','" + txtPersonalEmail.Text.Trim() + "','" + txtOfficialEmail.Text.Trim() +
                "','" + password + "'," + _roleId + ",'" + doj + "','" + dob + "','" +
                txtContactNo.Text.Trim() + "','" + txtEmergencyNo.Text.Trim() + "','" + Utilities.convertToMultiline(txtLocalAdd.Text) + "','" +
                Utilities.convertToMultiline(txtPermanentAdd.Text) + "') SELECT SCOPE_IDENTITY() ";
            Int32 empId = Convert.ToInt32(ds.ExecuteObjectQuery(addEmployee));
            filename = filename + empId + ext;
            string addEmpAdditional =
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image_name,ifsc_code,image_url) VALUES (" + empId + ",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                txtAccountHolder.Text + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" + filename + "','" + txtIFSC.Text + "','" + imageUrl + "')";

            var res = ds.RunCommand(addEmpAdditional);

            if (empId > 0)
            {
                DateTime dtx;
                DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtx);
                CalReminingLeaves(empId, dtx);

                InsertImage(empId);

                InsertManager(empId);

            }

            empImage.SaveAs(Server.MapPath("~/Web/Images/" + filename));
            var url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Login.aspx";
            Email mail = new Email();
            mail.SendRegistrationEmail(txtFirstName.Text, txtOfficialEmail.Text, txtEmpNo.Text, RandomString, url);

        }

        private void InsertImage(int empId)
        {

            if (empImage.HasFiles == true)
            {
                var image = empImage.FileBytes;
                var imageName = empImage.FileName;
                var imageUrl = "/Web/ImageHandler.ashx?emp_id=" + empId;

                string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                //var query = "insert employee_additional (emp_id,image_name,image_file,pan) values (23,@imageName,@image,'PANIMAGE')";

                var query = "UPDATE employee_additional SET image_file=@image,image_url=@imageUrl where emp_id =" + empId;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@imageUrl", imageUrl);
                    con.Open();

                    var res = cmd.ExecuteNonQuery();

                    //ds.RunCommand(query);

                    con.Close();
                }
            }
        }

        private void CalReminingLeaves(long empId, DateTime p)
        {
            _query = "SELECT no_of_leaves_current_year from leave_configuration";

            int leavesYear = Convert.ToInt32(ds.ExecuteObjectQuery(_query));

            ds.Close();

            var leavesMonth = (Double)leavesYear / 12;

            var currentLeaves = (12 - (p).Month + 1) * leavesMonth;

            _query = "INSERT INTO employee_configuration (emp_id,current_year_leaves) values (" + empId + "," + currentLeaves + ")";
            ds.RunCommand(_query);
            ds.Close();

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
            drdManager_SelectedIndexChanged(sender, e);

            drdRole_SelectedIndexChanged(sender, e);

            if (DuplicateValidation() == 0)
            {
                Insertemployee();

                txtContactNo.Text = txtDOB.Text = txtDOJ.Text = txtOfficialEmail.Text = txtPersonalEmail.Text = txtLastName.Text = txtFirstName.Text = txtEmpNo.Text = null;

                txtPAN.Text = txtAccountNo.Text = txtBranchLocation.Text = txtBankName.Text = txtPermanentAdd.Text = txtLocalAdd.Text = txtEmergencyNo.Text = null;

                txtPassport.Text = txtAccountHolder.Text = null;

                Response.Redirect("Add.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('The entered employee details already exists')</script>");
            }                   
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            drdRole_SelectedIndexChanged(sender, e);

            drdManager_SelectedIndexChanged(sender, e);
            Queries ob = new Queries();
            var employee_Id = Convert.ToInt32(Request.QueryString["id"]);
            DateTime doj, dob;

            DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out doj);

            DateTime.TryParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob);
            //  var employee_Id = Request.QueryString["id"];
            _query = "update employee set  emp_no='" + txtEmpNo.Text + "', first_name='" + Utilities.convertQuotes(txtFirstName.Text.Trim()) + "', last_name='" + Utilities.convertQuotes(txtLastName.Text.Trim()) + "', gender='" + drdGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + _roleId + "', date_of_join='" + doj + "', date_of_birth='" + dob + "', contact_number='" + txtContactNo.Text + "', emergency_contact_number='" + txtEmergencyNo.Text + "', permanent_address='" + Utilities.convertToMultiline(txtPermanentAdd.Text) + "', temp_address='" + Utilities.convertToMultiline(txtLocalAdd.Text) + "' where id=" + employee_Id + "";
            var res = ds.RunCommand(_query);
            DateTime dor;
            DateTime.TryParseExact(txtDor.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dor);

            _query = "update employee_additional set  bank_name='" + txtBankName.Text + "', bank_branch='" + txtBranchLocation.Text + "', holder_name='" + txtAccountHolder.Text + "', account_number='" + txtAccountNo.Text + "', pan='" + txtPAN.Text + "', passport='" + txtPassport.Text + "', ifsc_code='" + txtIFSC.Text + "' where emp_id=" + employee_Id + "";
            var result = ds.RunCommand(_query);
            _query = "update manager set manager_id=" + _managerId + " where employee_id=" + employee_Id + " ";
            var manager = ds.RunCommand(_query);
            if (cdInactive.Checked)
            {
                string query1 = "update [dbo].[leave_management] set approval_status='i' where emp_id=" + employee_Id + "";
                var leave = ds.RunCommand(query1);


                var re = ob.updateEmployeeLeaves(employee_Id);
                _query = "update employee set  emp_no='" + txtEmpNo.Text + "', first_name='" + Utilities.convertQuotes(txtFirstName.Text.Trim()) + "', last_name='" + Utilities.convertQuotes(txtLastName.Text.Trim()) + "', gender='" + drdGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + _roleId + "', contact_number='" + txtContactNo.Text + "', emergency_contact_number='" + txtEmergencyNo.Text + "', permanent_address='" + Utilities.convertToMultiline(txtPermanentAdd.Text) + "', temp_address='" + Utilities.convertToMultiline(txtLocalAdd.Text) + "' ,isactive='0' , DOR='" + dor + "' where id=" + employee_Id + "";

                var res1 = ds.RunCommand(_query);
            }

            if (res && result)
            {
                Response.Redirect("~/Web/Employee/EmployeeList/EmployeeList.aspx");
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
                "IF EXISTS (SELECT * FROM employee WHERE emp_no='" + txtEmpNo.Text.Trim() + "'OR official_email='" + txtOfficialEmail.Text + "')BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
            int value = Convert.ToInt32(ds.ExecuteObjectQuery(_query));

            return value;

        }


        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Employee/EmployeeList/EmployeeList.aspx");
        }

        protected void drdManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            _managerId = Convert.ToInt32(drdManager.SelectedValue);
        }

    }
}
