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
    public partial class AddFamilyDetails : System.Web.UI.Page
    {
        Database ds = new Database();
        private SqlDataReader _data;
        private string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFamilyDetails();
            }
        }
        protected void GetFamilyDetails()
        {
            try
            {
                //query = "SELECT  id,emp_id,relation_name,relationship,age,dependency from employee_familydetails where emp_id=" + Convert.ToInt32(Session["userId"]) + ""; 
                query = "SELECT  id,emp_id,relation_name,relationship,age,dependency= CASE dependency WHEN 'D' THEN 'Dependent' WHEN 'I' THEN 'Independent' END from employee_familydetails where emp_id=" + Convert.ToInt32(Session["userId"]) + "";
                ds.RunQuery(out _data, query);
                DataTable table = new DataTable();
                if (_data.HasRows == true)
                {
                    familytable.Style.Add("display", "none");
                    btnSave.Visible = false;
                    table.Load(_data);
                    gvDetails.DataSource = table;
                    gvDetails.DataBind();
                    btnCancel1.Visible = false;
                }
                else
                {
                    familytable.Style.Add("display", "inline");
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    btnCancel1.Visible = true;
                }
                _data.Close();
                ds.Close();
            }

            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetails.EditIndex = e.NewEditIndex;
            GetFamilyDetails();
        }

        protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gvDetails.DataKeys[e.RowIndex].Values["id"].ToString();

            TextBox name = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtName");

            TextBox relation = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtRelationship");

            TextBox age = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtAge");
            
            DropDownList dependency = (DropDownList)gvDetails.Rows[e.RowIndex].FindControl("drdDependent1");           

            if (!(name.Text.Equals("") || relation.Text.Equals("") || age.Text.Equals("")))
            {
                query = "update employee_familydetails set relation_name='" + Utilities.convertQuotes(name.Text.Trim()) + "', relationship='" + Utilities.convertQuotes(relation.Text.Trim()) + "', age=" + Convert.ToInt32(age.Text) + ",dependency='" + dependency.SelectedValue + "' where id=" + id + "";
                ds.RunCommand(query);
                ds.Close();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation23", "<script language='javascript'>alert('Details Updated Successfully.')</script>");
                gvDetails.EditIndex = -1;
                GetFamilyDetails();
                Response.Redirect("~/Web/Employee/Personal/AddFamilyDetails.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation434", "<script language='javascript'>alert('Please Enter the Family Details.')</script>");
            }
        }

        protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetails.EditIndex = -1;
            GetFamilyDetails();
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                TextBox name = (TextBox)gvDetails.FooterRow.FindControl("txtRname");

                TextBox relation = (TextBox)gvDetails.FooterRow.FindControl("txtRelationship1");

                TextBox age = (TextBox)gvDetails.FooterRow.FindControl("txtAge1");

                DropDownList dependency = (DropDownList)gvDetails.FooterRow.FindControl("drdDependent2");
                if (!(name.Text.Equals("") || relation.Text.Equals("") || age.Text.Equals("")))
                {
                    query = "insert into employee_familydetails(emp_id,relation_name,relationship,age,dependency) values(" + Convert.ToInt32(Session["userId"]) + ",'" + Utilities.convertQuotes(name.Text.Trim()) + "','" + Utilities.convertQuotes(relation.Text.Trim()) + "'," + Convert.ToInt32(age.Text) + ",'" + dependency.SelectedValue + "')";
                    ds.RunCommand(query);
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation454", "<script language='javascript'>alert('Details added Successfully.')</script>");
                    ds.Close();
                    GetFamilyDetails();
                    Response.Redirect("~/Web/Employee/Personal/AddFamilyDetails.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation4657", "<script language='javascript'>alert('Please Enter the Family Details.')</script>");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!(textname1.Text.Equals("") || textrelation1.Text.Equals("") || textage1.Text.Equals("")))
            {
                query = "insert into employee_familydetails(emp_id,relation_name,relationship,age,dependency) values(" + Convert.ToInt32(Session["userId"]) + ",'" + Utilities.convertQuotes(textname1.Text.Trim()) + "','" + Utilities.convertQuotes(textrelation1.Text.Trim()) + "'," + Convert.ToInt32(textage1.Text) + ",'" + drdDependent1.SelectedValue + "')";
                ds.RunCommand(query);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation645645", "<script language='javascript'>alert('Details added Successfully.')</script>");
                ds.Close();
                GetFamilyDetails();
                Response.Redirect("~/Web/Employee/Personal/AddFamilyDetails.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation90090", "<script language='javascript'>alert('Please Enter the Family Details.')</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Control chkRow = null;
            for (int jRow = 0; jRow < gvDetails.Rows.Count; jRow++)
            {
                chkRow = gvDetails.Rows[jRow].Cells[0].FindControl("chkRow");
                if (chkRow != null)
                {
                    if (((CheckBox)chkRow).Checked)
                    {
                        int FamilyId = (int)gvDetails.DataKeys[jRow].Values["id"];
                        query = "delete employee_familydetails where id=" + FamilyId + "";
                        ds.RunCommand(query);
                        ds.Close();
                    }
                }
            }
            Response.Redirect("~/Web/Employee/Personal/AddFamilyDetails.aspx");
            GetFamilyDetails();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Employee/Personal/PersonalDetails.aspx");
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState.ToString() == "Alternate, Edit")
            {
                // BIND THE "DROPDOWNLIST" WITH THE DATASET FILLED WITH "QUALIFICATION" DETAILS.
                DropDownList ddl = new DropDownList();
                //ddl.Items.Add(new ListItem("Dependent", "D"));
                //ddl.Items.Add(new ListItem("Independent", "I"));

                Label lbl = new Label();
                lbl = (Label)e.Row.FindControl("lblDependent");
                var ddl1 = (DropDownList)e.Row.FindControl("drdDependent1");

                if (lbl.Text.Equals("Dependent"))
                {
                    ddl1.SelectedValue = "D";
                }
                else
                    ddl1.SelectedValue = "I";
            }

            var sd = e.Row.RowState.ToString();

            if (e.Row.RowState.ToString() == "Alternate, Edit")
            {
                var x = e.Row.RowState;
            }
            var msg = "<script language='javascript'> $(\"#demo1\").removeClass(\"collapse\");</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "validation434454", msg);
        }
    }
}
                //if (ddl != null)
                //{
                //    //ddl.DataSource = ds.Tables["qual"];
                //    //ddl.DataTextField = ds.Tables["qual"].Columns["Qualification"].ColumnName.ToString();
                //    //ddl.DataValueField = ds.Tables["qual"].Columns["QualificationCode"].ColumnName.ToString();
                //    //ddl.DataBind();

                //    // ASSIGN THE SELECTED ROW VALUE ("QUALIFICATION CODE") TO THE DROPDOWNLIST SELECTED VALUE.
                //    ((DropDownList)e.Row.FindControl("drdDependent1")).SelectedValue =
                //        DataBinder.Eval(e.Row.DataItem, "dependency").ToString();
                //}
      
        //private void PopulateDS()
        //{
        //    ds.Clear();
        //    SqlAdapter = new System.Data.SqlClient.SqlDataAdapter
        //        ("SELECT QualificationCode, Qualification FROM dbo.Qualification", myConn);

        //    SqlAdapter.Fill(ds, "qual");
        //    SqlAdapter.Dispose();
        //}
    


