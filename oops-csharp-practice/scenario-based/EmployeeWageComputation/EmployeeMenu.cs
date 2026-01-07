using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class EmployeeMenu
    {
        private IEmployee employeeUtility;
        public void MyEmployeeMenu()
        {
            employeeUtility = new EmployeeUtilityImpl();

            while (true)
            {
                Console.WriteLine("\nEmployee Menu");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employee Toadys Attandance");
                Console.WriteLine("3. Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        employeeUtility.AddEmployee();
                        break;
                    case 2:
                        employeeUtility.CheckAttandance();
                        break;
                    case 3: return;
                    default: break;
                }
            }

        }
    }

}
