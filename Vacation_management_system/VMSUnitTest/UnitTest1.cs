using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vacation_management_system.Web.Common;

namespace VMSUnitTest
{
    [TestClass]
    public class EncriptPassword
    {
        Utilities utilities = new Utilities();

        [TestMethod]
        public void TestMethod1()
        {
            string password = "welcome";

            string dbhashpassword = "40be4e59b9a2a2b5dffb918c0e86b3d7";

            Assert.IsTrue(utilities.ComparePassword(dbhashpassword, utilities.EncodePassword(password)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            string password = "welcome1";

            string dbhashpassword = "40be4e59b9a2a2b5dffb918c0e86b3d7";

            Assert.IsFalse(utilities.ComparePassword(dbhashpassword, utilities.EncodePassword(password)));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string password1 = "welcome1";
            string password2= "welcome2";


            Assert.IsFalse(utilities.ComparePassword(utilities.EncodePassword(password1), utilities.EncodePassword(password2)));
        }
    }
}
