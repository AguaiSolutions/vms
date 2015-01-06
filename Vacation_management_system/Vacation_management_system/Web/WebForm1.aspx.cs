using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblImageStatus.Visible = false;

            }
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles == true)
            {
                var image = FileUpload1.FileBytes;
                var imageName = FileUpload1.FileName;
                //Aguai_Leave_Management_System.Database ds = new Database();

                string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                //var query = "insert employee_additional (emp_id,image_name,image_file,pan) values (23,@imageName,@image,'PANIMAGE')";

                var query = "UPDATE employee_additional SET image_file=@image,image_name = @imageName where emp_id =23";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@imageName", imageName);
                    cmd.Parameters.AddWithValue("@image", image);
                    con.Open();

                    var res = cmd.ExecuteNonQuery();

                    //ds.RunCommand(query);
                    if (res==1)
                    {
                        lblImageStatus.Visible = true;
                        lblImageStatus.Text = "Image has been Uploaded Successfully";
                    }

                    con.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var emp_id = 23;

          Image1.ImageUrl = "~/Web/ImageHandler.ashx?emp_id="+emp_id;

        }
    }
}