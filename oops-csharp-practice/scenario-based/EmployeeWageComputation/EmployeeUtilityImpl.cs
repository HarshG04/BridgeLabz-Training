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

        //private int WagePerHour = 20;
        //private int FullDayHour = 8;
        //private int PartTimeHour = 8;
        //private int WorkingDayPerMonth = 20;
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

            //Console.Write("Enter Employee Salary: ");
            //double employeeSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Employee Type [0:Regular, 1:PartTime]: ");
            int type = Convert.ToInt32(Console.ReadLine());


            Employee newEmployee = new Employee();

            newEmployee.EmployeeName = employeeName;
            newEmployee.EmployeeAge = employeeAge;
            //newEmployee.EmployeeSalary = employeeSalary;
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

        public void DisplayAllEmployees()
        {
            if (idx == 0)
            {
                Console.WriteLine("No Employees Found!!!");
                return;
            }
            Console.WriteLine("===== All Employees =====");
            for(int i=0;i<idx;i++) DisplayEmployee(employees[i]);
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
        public void CalculateDailyWage(int eId)
        {
            
            Console.WriteLine($"Employee Name: {employees[eId].EmployeeName} || Employee Type: {employees[eId].EmployeeType}");
            Console.Write("Enter Todays Working Hours : ");
            int hrs = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Wage Per Hour: ");
            int wagePerHour = Convert.ToInt32(Console.ReadLine());

            int wage = hrs * wagePerHour;
            Console.WriteLine($"Name: {employees[eId].EmployeeName} || Todays Wage: {wage}");

        }

        public void CalculateDailyWage()
        {
            Console.WriteLine("Calculate Employee Daily Wage:: ");
            Console.Write("Select Employee Id: ");
            int eId = Convert.ToInt32(Console.ReadLine());

            if (eId < 0 || eId >= idx)
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            if (employees[eId].EmployeeType == "PartTime")
            {
                Console.WriteLine("\nEmployee A PartTime Employee. Calculating PartTime Employee Wage...");
                CalculatePartTimeWage(eId);
                return;
            }

            CalculateDailyWage(eId);

        }

        //UC-3
        public void CalculatePartTimeWage(int eId)
        {
            
            Console.WriteLine($"Employee Name: {employees[eId].EmployeeName} || Employee Type: {employees[eId].EmployeeType}");
            Console.Write("Enter Todays Working Hours : ");
            int hrs = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Part Time Wage Per Hour: ");
            int wagePerHour = Convert.ToInt32(Console.ReadLine());

            int wage = hrs * wagePerHour;
            Console.WriteLine($"Name: {employees[eId].EmployeeName} || Todays Wage: {wage}");
        }

        public void CalculatePartTimeWage()
        {
            Console.WriteLine("Calculate PartTime Employee Daily Wage:: ");
            Console.Write("Select Employee Id: ");
            int eId = Convert.ToInt32(Console.ReadLine());

            if (eId < 0 || eId >= idx)
            {
                Console.WriteLine("Invalid Id");
                return;
            }
            if (employees[eId].EmployeeType == "Regular")
            {
                Console.WriteLine("Employee A Regular Employee. Calculating Regular Employee Wage...");
                CalculateDailyWage(eId);
                return;
            }

            CalculatePartTimeWage(eId);
        }

        // UC- 5
        public void CalculateMonthlyWage()
        {
            Console.WriteLine("Employee Monthly Wage... ");
            Console.Write("Select Employee Id: ");
            int eId = Convert.ToInt32(Console.ReadLine());

            if (eId < 0 || eId >= idx)
            {
                Console.WriteLine("Invalid Id");
                return;
            }

            Console.WriteLine($"Employee Name: {employees[eId].EmployeeName} || Employee Type: {employees[eId].EmployeeType}");

            Console.Write("Enter Monthly Working Days : ");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Wage per Day: ");
            int wagePerDay = Convert.ToInt32(Console.ReadLine());


            int monthlyWage = days*wagePerDay;
            Console.WriteLine($"Name: {employees[eId].EmployeeName} || Monthly Wage : {monthlyWage}");
        }

        // UC-6
        public void CalculateWage()
        {
            Console.Write("Enter Wage Per Hour: ");
            int wagePerHour = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Total Working Hours: ");
            int hrs = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Total Working Days ");
            int days = Convert.ToInt32(Console.ReadLine());

            if(hrs==100)
            {
                int wage = hrs * wagePerHour;
                Console.WriteLine($"Wage: {wage}");
            }else if (days == 20)
            {
                int wage = days * 8 * wagePerHour;
                Console.WriteLine($"Wage: {wage}");
            }
            else
            {
                Console.WriteLine("Conditions not met (100 hours or 20 days required)");
            }

        }
    }

}
