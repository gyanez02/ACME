using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_PAYROLL.Logic
{
    public class Employee
    {

        private double totalPay=0;
        private string employeeName;
        private string[] dates;

        public Employee(string employeeRawData) { 

            employeeName = employeeRawData.Substring(0, employeeRawData.IndexOf("="));
            dates = employeeRawData.Substring(employeeRawData.IndexOf("=") + 1).Split(',');
        }

        public double TotalPay
        {
            get
            {
                return totalPay;
            }
            set
            {
                totalPay = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }



        public string[] Dates
        {
            get
            {
                return dates;
            }
            set
            {
                dates = value;
            }
        }

    

    }
}
