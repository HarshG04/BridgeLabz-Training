using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class EmployeeMain
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Employee Wage Computation Program");
            EmployeeMenu menu = new EmployeeMenu();
            menu.MyEmployeeMenu();
        }
    }
}
