using System;
using CustomersApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CustomerTestClass
    {
        [TestMethod]
        public void CompareTo_caseSennsetive_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny";
            cust1.ID = 0;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "Danny";
            cust2.ID = 0;

            Assert.AreEqual(0,cust1.CompareTo(cust2));
        }

        [TestMethod]
        public void CompareTo_FirstIsBigger_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny0";
            cust1.ID = 0;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "Danny1";
            cust2.ID = 0;

            Assert.AreEqual(-1, cust1.CompareTo(cust2));
        }
        [TestMethod]
        public void CompareTo_SecondIsBigger_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny1";
            cust1.ID = 0;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "Danny0";
            cust2.ID = 0;

            Assert.AreEqual(1, cust1.CompareTo(cust2));
        }

        [TestMethod]
        public void Equal_nameIsChanged_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny0";
            cust1.ID = 0;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "Danny1";
            cust2.ID = 0;

            Assert.AreEqual(false, cust1.Equals(cust2));
        }
        [TestMethod]
        public void Equal_IdIsChanged_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny1";
            cust1.ID = 1;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "danny1";
            cust2.ID = 0;

            Assert.AreEqual(false, cust1.Equals(cust2));
        }
        [TestMethod]
        public void Equal_AllEqual_Success()
        {
            CustomersApp.Customer cust1 = new Customer();
            cust1.Name = "danny1";
            cust1.ID = 1;

            CustomersApp.Customer cust2 = new Customer();
            cust2.Name = "danny1";
            cust2.ID = 1;

            Assert.AreEqual(true, cust1.Equals(cust2));
        }
    }
}
