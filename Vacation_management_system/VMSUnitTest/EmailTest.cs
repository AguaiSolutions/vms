using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vacation_management_system.Web.Common.Class;


namespace VMSUnitTest
{
    [TestClass]
    class EmailTest
    {
        Email mailtest = new Email();

         [TestMethod]
        public void EmailTester()
        {
            Assert.IsTrue(mailtest.SendRegistrationEmail("Kumar","ksk90044@gmail.com","100","jfdkfj",""));
        }

    }
}
