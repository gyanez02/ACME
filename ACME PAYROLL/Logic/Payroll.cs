using ACME_PAYROLL.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_PAYROLL.Logic
{
    public class Payroll
    {
        private readonly Connection connection = new Connection();
        List<Employee> employees = new List<Employee>();

        private StreamReader sr;
        private readonly TimeSpan[,] hours = new TimeSpan[3, 2] { { new TimeSpan(0, 1, 0), new TimeSpan(9, 0, 0) }, { new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0) }, { new TimeSpan(18, 0, 0), new TimeSpan(24, 0, 0) } };

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
            }
        }

        public void GetData() // read all lines of the txt file, creates new employees with the data and saves them in a list
        {
            sr = connection.GetConnection();
            string employeeRawData = sr.ReadLine();
            while (employeeRawData != null)
            {
                employees.Add(new Employee(employeeRawData.Trim().ToUpper()));
                employeeRawData = sr.ReadLine();
            }
        }

        public void AmountToPay()// for each employee that exists obtain the total pay
        {
            string day;
            foreach (Employee employee in employees)
            {

                for (int i = 0; i < employee.Dates.GetLength(0); i++)
                {
                    day = employee.Dates[i].Substring(0, 2); // get the day 
                    string[] range = employee.Dates[i].Substring(2).Split('-'); // get the start of the shift and the end of the shift of a string 
                    TimeSpan startOfShift = TimeSpan.Parse(range[0]);
                    TimeSpan endOfShift = TimeSpan.Parse(range[1]);
                    int[] pay = TypeOfPay(day);
                    employee.TotalPay += CalculatePay(hours, startOfShift, endOfShift, pay);
                }

            }
         
        }
        public int[] TypeOfPay(string day)// if the day is weekend o weekday returns an array with the type of pay of the corresponding day
        {
            if (day == "SA" || day == "SU")
            {
                return new int[3] { 30, 20, 25 };
            }
            else if (day == "MO" || day == "TU" || day == "WE" || day == "TH" || day == "FR")
            {
                return new int[3] { 25, 15, 20 };

            }
            else
            {
                return null;
            }


        }

        public static double CalculatePay(TimeSpan[,] hours, TimeSpan startOfShift, TimeSpan endOfShift, int[] pay)// Obtains the total amount to pay one employee for all the days the employee worked
        {
            double totalPay = 0;
            int positionStartOfShift = 0;
            int positionEndOfShift = 0;
            for (int i = 0; i < hours.GetLength(0); i++) // For that goes over the three types of schedules: (00:01 - 09:00, 09:01 - 18:00, 18:01 - 00:00  )
            {
                TimeSpan lowerRange = hours[i, 0];
                TimeSpan upperRange = hours[i, 1];
                if (startOfShift > lowerRange && startOfShift <= upperRange)
                {
                    positionStartOfShift = i; // gets in which of the three schedules the startOfshift is part of 
                }
                if (endOfShift > lowerRange && endOfShift <= upperRange)
                {
                    positionEndOfShift = i; // gets in which of the three schedules the endOfshift is part of 
                }
            }
            double hoursWorked;
            if (positionStartOfShift == positionEndOfShift)// get the amount to pay if the start of the shift and the end of the shift are in the same schedule
            {
                hoursWorked = endOfShift.Subtract(startOfShift).TotalHours;
                totalPay += hoursWorked * pay[positionStartOfShift];
            }

            else// get the amount to pay if the start of the shift and the end of the shift are in a different schedule
            {
                hoursWorked = hours[positionStartOfShift, 1].Subtract(startOfShift).TotalHours;
                totalPay += hoursWorked * pay[positionStartOfShift];
                hoursWorked = endOfShift.Subtract(hours[positionEndOfShift, 0]).TotalHours;
                totalPay += hoursWorked * pay[positionEndOfShift];
                if (positionStartOfShift + 2 == positionEndOfShift)
                {
                    totalPay += hours[1,1].Subtract(hours[1,0]).TotalHours * pay[1];
                }

            }
            return totalPay;
        }
       
    }
}
