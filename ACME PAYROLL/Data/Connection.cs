using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_PAYROLL.Data
{
    public class Connection
    {
        private static string filePath = "../../../employees.txt";
        public StreamReader GetConnection() {
            return new StreamReader(filePath);
        }
    }
}
