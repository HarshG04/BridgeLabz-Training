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
                Console.WriteLine("3. View Employee Daily Wage");
                Console.WriteLine("4. View Part Time Employee Daily Wage");
                Console.WriteLine("5. View Employee Monthly Wage");
                Console.WriteLine("6. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                //UC-4 Applying Switch
                switch (option)
                {
                    case 1:
                        employeeUtility.AddEmployee();
                        break;
                    case 2:
                        employeeUtility.CheckAttandance();
                        break;
                    case 3:
                        employeeUtility.CalculateDailyWage();
                        break;
                    case 4:
                        employeeUtility.CalculatePartTimeWage();
                        break;
                    case 5:
                        employeeUtility.CalculateMonthlyWage();
                        break;
                    case 6: return;
                    default: break;
                }
            }

        }
    }

}
