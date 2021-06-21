using ACME_PAYROLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_PAYROLL.Presentation
{
    public class UserInterface
    {
       
        static Payroll payroll = new Payroll();

        public static void Start() {
            Console.WriteLine("Welecome to ACME payroll system.");
        }
        public static void DisplayPayroll() 
        {

            try
            {
                payroll.GetData();
                payroll.AmountToPay();
                foreach (Employee employee in payroll.Employees)
                {
                    Console.WriteLine(String.Format("The amount to pay {0} is: {1} USD", employee.EmployeeName, employee.TotalPay));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Be sure the file exists and the verify if the data has the correct format.");
                Console.WriteLine("Exception: " + e.Message);
            }
            
           
        }
        public static void ExitApllication() {
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();

        }


    }
}
