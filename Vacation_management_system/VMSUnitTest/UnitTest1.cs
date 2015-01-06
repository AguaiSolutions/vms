using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vacation_management_system.Web.Common.Class;

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

            Assert.IsTrue(Utilities.ComparePassword(dbhashpassword, Utilities.EncodePassword(password)));
        }

        [TestMethod]
        public void TestMethod2()
        {
            string password = "welcome1";

            string dbhashpassword = "40be4e59b9a2a2b5dffb918c0e86b3d7";

            Assert.IsFalse(Utilities.ComparePassword(dbhashpassword, Utilities.EncodePassword(password)));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string password1 = "welcome1";
            string password2= "welcome2";


            Assert.IsFalse(Utilities.ComparePassword(Utilities.EncodePassword(password1), Utilities.EncodePassword(password2)));
        }

        Email mailtest = new Email();

        [TestMethod]
        public void EmailTester()
        {
            Assert.IsTrue(mailtest.SendRegistrationEmail("Kumar", "ksk90044@gmail.com", "100", "jfdkfj",""));
        }

    }
}
