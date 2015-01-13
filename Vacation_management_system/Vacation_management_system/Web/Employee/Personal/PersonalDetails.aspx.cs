using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Aguai_Leave_Management_System;
using Vacation_management_system.Web.Common;
using Vacation_management_system.Web.Common.Class;
using System.Globalization;

namespace Vacation_management_system.Web.Employee
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string query;
        Int32 user_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPersonalDetails();
                GetOfficialDetails();
                GetBankDetails();
            }
        }

        private void GetPersonalDetails()
        {

            user_id = Convert.ToInt32(Session["userId"]);
            query = "SELECT  EA.emp_id,EA.passport,E.id,E.first_name,E.last_name,CASE E.gender  WHEN 'M' THEN 'Male' WHEN 'F' THEN 'Female' END as gender,E.personal_email,CONVERT(varchar,E.date_of_birth,103)as date_of_birth,E.contact_number,E.emergency_contact_number,E.permanent_address,E.temp_address from employee as E left JOIN employee_additional as EA ON EA.emp_id=E.id where E.id =" + user_id + "";
            ds.RunQuery(out _data, query);
            DataTable table = new DataTable();
           if (_data.HasRows == true)
            {
                table.Load(_data);
                DataList1.DataSource = table;
                DataList1.DataBind();
                _data.Close();
                ds.Close();
            }
        }


        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;

            GetPersonalDetails();
        }

        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {

            DataList1.EditItemIndex = -1;

            GetPersonalDetails();

        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            String id = ((Label)e.Item.FindControl("lblId")).Text;

            user_id = Convert.ToInt32(Session["userId"]);

            TextBox firstname = (TextBox)e.Item.FindControl("txtFirstname");

            TextBox lastname = (TextBox)e.Item.FindControl("txtLastname");

            DropDownList gender = (DropDownList)e.Item.FindControl("drdGender");

            TextBox email = (TextBox)e.Item.FindControl("txtEmail");

            TextBox dob = (TextBox)e.Item.FindControl("txtDOB");
            DateTime H_date;
            var xxsd = DateTime.TryParseExact(dob.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out H_date);

            TextBox contact = (TextBox)e.Item.FindControl("txtContact");

            TextBox emergency = (TextBox)e.Item.FindControl("txtEmergency");

            TextBox permanent = (TextBox)e.Item.FindControl("txtPermanent");

            TextBox temp = (TextBox)e.Item.FindControl("txtTemp");

            TextBox pass = (TextBox)e.Item.FindControl("txtPassport");

                query = "update employee set first_name='" + Utilities.convertQuotes(firstname.Text.Trim()) + "',last_name='" + Utilities.convertQuotes(lastname.Text.Trim()) + "', gender='" + gender.SelectedValue + "', personal_email='" + Utilities.convertQuotes(email.Text.Trim()) + "', date_of_birth='" + H_date + "', contact_number='" + contact.Text + "', emergency_contact_number='" + emergency.Text + "', permanent_address='" + Utilities.convertQuotes(permanent.Text.Trim()) + "', temp_address='" + Utilities.convertQuotes(temp.Text.Trim()) + "' where id=" + id + "";
                ds.RunCommand(query);
                ds.Close();
                query = "update employee_additional set passport='" + pass.Text + "' where emp_id=" + user_id + "";
                ds.RunCommand(query);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Details Updated Successfully.')</script>");
                ds.Close();
                GetPersonalDetails();
                Response.Redirect("~/Web/Employee/Personal/PersonalDetails.aspx");
        }

        private void GetOfficialDetails()
        {
            user_id = Convert.ToInt32(Session["userId"]);
            query = "SELECT  EA.emp_id,EA.pan,E.id,E.emp_no,E.official_email,CONVERT(varchar,E.date_of_join,103)as date_of_join from employee as E left JOIN employee_additional as EA ON EA.emp_id=E.id where E.id =" + user_id + "";
            ds.RunQuery(out _data, query);
            DataTable table = new DataTable();
            if (_data.HasRows == true)
            {
                table.Load(_data);
                DataList2.DataSource = table;
                DataList2.DataBind();
                _data.Close();
                ds.Close();
            }
        }

        private void GetBankDetails()
        {
            user_id = Convert.ToInt32(Session["userId"]);
            query = "SELECT emp_id,bank_name,bank_branch,holder_name,account_number,ifsc_code from employee_additional where emp_id =" + user_id + "";
            ds.RunQuery(out _data, query);
            DataTable table = new DataTable();
            if (_data.HasRows == true)
            {
                table.Load(_data);
                DataList3.DataSource = table;
                DataList3.DataBind();
                _data.Close();
                ds.Close();
            }
        }

        protected void btnFamily_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Employee/Personal/AddFamilyDetails.aspx");
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var msg = "<script language='javascript'> $(\"#demo1\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation12", msg);
            // if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType.ToString() == "Alternate, Edit")

            if (e.Item.ItemType == ListItemType.EditItem)
            //if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                // BIND THE "DROPDOWNLIST" WITH THE DATASET FILLED WITH "QUALIFICATION" DETAILS.
                DropDownList ddl = new DropDownList();
                ddl.Items.Add(new ListItem("Male", "M"));
                ddl.Items.Add(new ListItem("Female", "F"));

                Label lbl = new Label();
                lbl = (Label)e.Item.FindControl("lblGender");
                var ddl1 = (DropDownList)e.Item.FindControl("drdGender");
                // DropDownList ddl1 = DataList1.FindControl("drdGender") as DropDownList;

                if (lbl.Text.Equals("Male"))
                {
                    ddl1.SelectedValue = "M";
                }
                else
                    ddl1.SelectedValue = "F";
            }

            var sd = e.Item.ItemType.ToString();

            if (e.Item.ItemType.ToString() == "Alternate, Edit")
            {
                var x = e.Item.ItemType;
            }
        }
    }
}
