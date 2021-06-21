using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ACME_PAYROLL;
using ACME_PAYROLL.Logic;
using System.Linq;
using System.IO;
using ACME_PAYROLL.Data;

namespace TESTPAYROLL
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test_Rene_215()
        {
            Employee e = new Employee("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00");
            Payroll payroll = new Payroll();
            payroll.Employees.Add(e);
            payroll.AmountToPay();

            Assert.AreEqual(215, payroll.Employees[0].TotalPay);
        }
        [TestMethod]
        public void Test_Astrid_85()
        {
            Employee e = new Employee("ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00");
            Payroll payroll = new Payroll();
            payroll.Employees.Add(e);
            payroll.AmountToPay();

            Assert.AreEqual(85, payroll.Employees[0].TotalPay);
        }
        [TestMethod]
        public void Test_three_shifts() 
        {
            Employee e = new Employee("JOHNSMITH=MO08:00-19:00");
            Payroll payroll = new Payroll();
            payroll.Employees.Add(e);
            payroll.AmountToPay();

            Assert.AreEqual(180, payroll.Employees[0].TotalPay);
        }
        [TestMethod]
        public void Test_two_shifts()
        {
            Employee e = new Employee("BIGFOOT=MO015:00-19:00");
            Payroll payroll = new Payroll();
            payroll.Employees.Add(e);
            payroll.AmountToPay();
            Assert.AreEqual(65, payroll.Employees[0].TotalPay);
        }


        [TestMethod]
        public void Test_Saturday()
        {
           
            Payroll payroll = new Payroll();
            int[] expectedValue = new int[3] { 30, 20, 25 };
            int[] realValue = payroll.TypeOfPay("SA");
            Assert.IsTrue(expectedValue.SequenceEqual(realValue));

        }
        [TestMethod]
        public void Test_Sunday()
        {
            Payroll payroll = new Payroll();
            int[] expectedValue = new int[3] { 30, 20, 25 };
            int[] realValue = payroll.TypeOfPay("SU");
            Assert.IsTrue(expectedValue.SequenceEqual(realValue));
        }

        [TestMethod]
        public void Test_connection() 
        {
            Connection co= new Connection();
            StreamReader sr = co.GetConnection();

            Assert.IsNotNull(sr);
        }



    }
}
