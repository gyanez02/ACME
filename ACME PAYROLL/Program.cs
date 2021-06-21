using ACME_PAYROLL.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_PAYROLL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UserInterface.Start();
            UserInterface.DisplayPayroll();
            UserInterface.ExitApllication();
        }
        
    }

}
