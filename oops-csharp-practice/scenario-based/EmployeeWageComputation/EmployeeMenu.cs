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
                Console.WriteLine("\n==========Employee Menu==========");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. View Employee Toadys Attandance");
                Console.WriteLine("4. Calculate Employee Daily Wage");
                Console.WriteLine("5. Calculate Part Time Employee Daily Wage");
                Console.WriteLine("6. Calculate Employee Monthly Wage");
                Console.WriteLine("7. Calculate Wage");
                Console.WriteLine("8. Exit");
                Console.Write("Enter Choise: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        employeeUtility.AddEmployee();
                        break;
                    case 2:
                        employeeUtility.DisplayAllEmployees();
                        break;
                    case 3:
                        employeeUtility.CheckAttandance();
                        break;
                    case 4:
                        employeeUtility.CalculateDailyWage();
                        break;
                    case 5:
                        employeeUtility.CalculatePartTimeWage();
                        break;
                    case 6:
                        employeeUtility.CalculateMonthlyWage();
                        break;
                    case 7:
                        employeeUtility.CalculateWage();
                        break;
                    case 8: return;
                    default: break;
                }
            }

        }
    }

}
