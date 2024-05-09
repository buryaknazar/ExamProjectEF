using DLL.Contexts;
using DLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OlimpiaContext olimpiaDB = new OlimpiaContext();

            olimpiaDB.Countries.Where(c => c.Name == "Germany");

            olimpiaDB.SaveChanges();
            Assert.IsTrue(true);
        }
    }
}
