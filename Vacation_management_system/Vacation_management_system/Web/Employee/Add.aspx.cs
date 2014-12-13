using System;
using System.Web;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Aguai_Leave_Management_System;
using System.Web.UI;
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
                lblEmployee.Text = "Add Employee";
                lblTitle.Text = "Add Employee";
                btnupdate.Visible = false;
                btnupdate1.Visible = false;
                cdInactive.Visible = false;
                lblDeactivate.Visible = false;
                lblDor.Visible = false;
                txtDor.Visible = false;
                icon.Attributes["class"] = "fa fa-plus";


                _query = "SELECT id,role_name FROM user_roles where id > 1 ORDER BY ID DESC";

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

               


                if (employeeId != null)
                {
                    lblEmployee.Text = "Edit Employee";
                    lblTitle.Text = "Edit Employee";
                    empImage.Visible = false;
                    lblImage.Visible = false;
                    btnSave.Visible = false;
                    btnSaveandaddnew.Visible = false;
                    btnSave1.Visible = false;
                    btnSaveandaddnew1.Visible = false;
                    cdInactive.Visible = true;
                    btnupdate.Visible = true;
                    btnupdate1.Visible = true;
                    lblDeactivate.Visible = true;
                    lblDor.Visible = true;
                    txtDor.Visible = true;
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
                        txtDOJ.Text = _data["date_of_join"].ToString();
                        txtDOB.Text = _data["date_of_birth"].ToString(); 
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
                        drdRole.SelectedValue =_data["role_id"].ToString();

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
            string filename = Path.GetFileName(empImage.PostedFile.FileName);
             string ext = Path.GetExtension(filename);
             DateTime doj;
             var xxsd = DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                     out doj);
             DateTime dob;
             xxsd = DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                     out dob);
            string addEmployee =
                "insert into [employee] (emp_no,first_name,last_name,gender,personal_email,official_email,password,role_id,date_of_join,date_of_birth,contact_number,emergency_contact_number,permanent_address,temp_address) VALUES('" +
                txtEmpNo.Text.Trim() + "','" + Server.HtmlEncode(txtFirstName.Text.Trim()) + "','" + Server.HtmlEncode(txtLastName.Text.Trim()) + "','" +
                drdGender.SelectedValue + "','" + Utilities.convertQuotes(txtPersonalEmail.Text.Trim()) + "','" + Utilities.convertQuotes(txtOfficialEmail.Text.Trim()) +
                "','" + password + "'," + _roleId + ",'" + doj + "','" + dob + "','" +
                txtContactNo.Text.Trim() + "','" + txtEmergencyNo.Text.Trim() + "','" + txtLocalAdd.InnerText + "','" +
                txtPermanentAdd.InnerText + "') SELECT SCOPE_IDENTITY() ";
            Int32 empId = Convert.ToInt32(ds.ExecuteObjectQuery(addEmployee));
            filename = filename + empId + ext;
            string addEmpAdditional =
                "INSERT into [employee_additional] (emp_id,bank_name,bank_branch,holder_name,account_number,pan,passport,image,ifsc_code) VALUES (" + empId + ",'" +
                txtBankName.Text + "','" + txtBranchLocation.Text + "','" +
                txtAccountHolder.Text + "','" + txtAccountNo.Text.Trim() + "','" +
                txtPAN.Text.Trim() + "','" + txtPassport.Text.Trim() + "','" +filename + "','" + txtIFSC.Text + "')";

            ds.RunCommand(addEmpAdditional);
            
            if (empId > 0)
            {
                DateTime dtx;
               xxsd = DateTime.TryParseExact(txtDOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                                        out dtx);
                CalReminingLeaves(empId, dtx);

                InsertManager(empId);

            }
           
            empImage.SaveAs(Server.MapPath("~/Web/Images/" + filename));
            var url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Web/Login/Login.aspx";
            Email mail = new Email();
            mail.SendRegistrationEmail(txtFirstName.Text, txtOfficialEmail.Text, txtEmpNo.Text, RandomString, url);
           
        }

        private void CalReminingLeaves(long empId, DateTime p)
        {
            var currentLeaves = (12 - (p).Month + 1)*1.5;

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
            drdRole_SelectedIndexChanged(sender, e);

            drdManager_SelectedIndexChanged(sender, e);
            Queries ob = new Queries();
            var employee_Id = Convert.ToInt32(Request.QueryString["id"]);

          //  var employee_Id = Request.QueryString["id"];
            _query = "update employee set  emp_no='" + txtEmpNo.Text + "', first_name='" + Utilities.convertQuotes(txtFirstName.Text.Trim()) + "', last_name='" + Utilities.convertQuotes(txtLastName.Text.Trim()) + "', gender='" + drdGender.Text + "', personal_email='" + txtPersonalEmail.Text + "', official_email='" + txtOfficialEmail.Text + "', role_id='" + _roleId + "', date_of_join='" + txtDOJ.Text.Trim() + "', date_of_birth='" + txtDOB.Text.Trim() + "', contact_number='" + txtContactNo.Text + "', emergency_contact_number='" + txtEmergencyNo.Text + "', permanent_address='" + txtPermanentAdd.InnerText + "', temp_address='" + txtLocalAdd.InnerText + "' ,isactive='0' , DOR='" + txtDor.Text + "' where id=" + employee_Id + "";
            var res = ds.RunCommand(_query);
         
           
            _query = "update employee_additional set  bank_name='" + txtBankName.Text + "', bank_branch='" + txtBranchLocation.Text + "', holder_name='" + txtAccountHolder.Text + "', account_number='" + txtAccountNo.Text + "', pan='" + txtPAN.Text + "', passport='" + txtPassport.Text + "', ifsc_code='" + txtIFSC.Text + "' where emp_id=" + employee_Id + "";
            var result = ds.RunCommand(_query);
            _query = "update manager set manager_id=" + _managerId + " where employee_id=" + employee_Id + " ";
            var manager= ds.RunCommand(_query);
            string query1 = "update [dbo].[leave_management] set approval_status='i' where emp_id=" + employee_Id + "";
            var leave = ds.RunCommand(query1);
      

             var  re= ob.updateEmployeeLeaves(employee_Id);

               
            if (res && result && re)
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
                "IF EXISTS (SELECT * FROM employee WHERE emp_no='" + txtEmpNo.Text.Trim() + "'OR official_email='" + txtOfficialEmail.Text + "')BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
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

        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    string filename = Path.GetFileName(empImage.PostedFile.FileName);
        //    string targetPath = Server.MapPath("Images/" + filename);
        //    Stream strm = empImage.PostedFile.InputStream;
        //    var targetFile = targetPath;
        //    //Based on scalefactor image size will vary
        //    //GenerateThumbnails(0.07, strm, targetFile);
           
            
        //}
        //private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        //{
        //    using (var image = Image.FromStream(sourcePath))
        //    {
        //        var newWidth = (int)(image.Width * scaleFactor);
        //        var newHeight = (int)(image.Height * scaleFactor);
        //        var thumbnailImg = new Bitmap(newWidth, newHeight);
        //        var thumbGraph = Graphics.FromImage(thumbnailImg);
        //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        //        thumbGraph.DrawImage(image, imageRectangle);
        //        thumbnailImg.Save(targetPath, image.RawFormat);
        //    }
        //}

    }
}
