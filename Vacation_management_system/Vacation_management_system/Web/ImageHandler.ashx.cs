using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using AjaxControlToolkit;

namespace Vacation_management_system.Web
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            var query = "SELECT image_file from employee_additional where emp_id="+context.Request.QueryString["emp_id"];

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    context.Response.ContentType = "image/JPG";
                    context.Response.BinaryWrite((Byte[])dr["image_file"]);

                }
                dr.Close();
                con.Close();
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}