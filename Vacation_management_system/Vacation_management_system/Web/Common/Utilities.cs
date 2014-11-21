using System.Security.Cryptography;
using System.Text;

namespace Vacation_management_system.Web.Common
{
    public class Utilities
    {
        public string EncodePassword(string password)
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

        public bool ComparePassword(string dbPassword, string hashedPassword)
        {
            if (dbPassword == hashedPassword)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}