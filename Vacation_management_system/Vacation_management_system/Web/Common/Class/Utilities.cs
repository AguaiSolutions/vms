using System.Security.Cryptography;
using System.Web.UI;
using System.Text;

using System.Configuration;
using Aguai_Leave_Management_System;

namespace Vacation_management_system.Web.Common.Class
{
    public class Utilities
    {

        //Database ds = new Database();
        //private string query;
        ClientScriptManager ClientScript;
        public static string EncodePassword(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static bool ComparePassword(string dbPassword, string hashedPassword)
        {
            return dbPassword == hashedPassword;


        }

        public static string convertQuotes(string str)
        {
            return str.Replace("'", "''");

        }

        public static string convertToSingleQuote(string str)
        {
            return str.Replace("''", "'");

        }

        public void alert(System.Type type)
        {

            ClientScript.RegisterStartupScript(type, "validation", "<script language='javascript'>alert('Invalid Dates.')</script>");
        }

    }
}