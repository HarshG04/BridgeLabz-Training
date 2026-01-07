using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class EmployeeUtilityImpl : IEmployee
    {
        private Employee[] employees = new Employee[10];
        private int idx = 0;
        private static Random random = new Random();
        private int WagePerHour = 20;
        private int FullDayHour = 8;
        private int PartTimeHour = 8;
        private int WorkingDayPerMonth = 20;
        public void AddEmployee()
        {
            if (idx >= employees.Length)
            {
                Console.WriteLine("Capacity Is full.");
                return;
            }
            Console.Write("Enter Employee Name: ");
            string employeeName = Console.ReadLine();

            Console.Write("Enter Employee Age: ");
            int employeeAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Salary: ");
            double employeeSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Employee Type [0:Regular,1:PartTime]");
            int type = Convert.ToInt32(Console.ReadLine());


            Employee newEmployee = new Employee();

            newEmployee.EmployeeName = employeeName;
            newEmployee.EmployeeAge = employeeAge;
            newEmployee.EmployeeSalary = employeeSalary;
            newEmployee.IsPresent = random.Next(2) == 1;
            newEmployee.EmployeeId = idx;
            newEmployee.EmployeeType = (type == 0 ? "Regular" : "PartTime");

            employees[idx++] = newEmployee;

            Console.WriteLine("Employee Added Successfully");

        }

        public void DisplayEmployee(Employee employee)
        {
            Console.WriteLine(employee);
        }


        // UC-1

        public void CheckAttandance()
        {
            if (idx == 0)
            {
                Console.WriteLine("No employees available.");
                return;
            }

            for (int i = 0; i < idx; i++)
            {
                DisplayEmployee(employees[i]);
            }

            Console.Write("Select Employee Id: ");
            int eId = Convert.ToInt32(Console.ReadLine());

            if (eId < 0 || eId >= idx)
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            Console.WriteLine($"Is Present Today: {employees[eId].IsPresent}");
        }
            
        //UC-2
        public void CalculateDailyWage()
        {
            Console.WriteLine("All Employeess Daily Wage: ");
            int dailyWage = WagePerHour * FullDayHour;
            Console.WriteLine($"Daily Wage : {dailyWage}");

        }

        //UC-3
        public void CalculatePartTimeWage()
        {
            Console.WriteLine("Part Time Employeess Daily Wage: ");
            int partTimeWage = WagePerHour * PartTimeHour;
            Console.WriteLine($"Part Time Wage : {partTimeWage}");
        }

        // UC- 5
        public void CalculateMonthlyWage()
        {
            Console.WriteLine("Employeess Monthly Wage: ");
            int monthlyWage = WorkingDayPerMonth * FullDayHour * WagePerHour;
            Console.WriteLine($"Monthly Wage : {monthlyWage}");
        }
    }

}
