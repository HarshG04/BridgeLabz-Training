using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal interface IEmployee
    {
        void AddEmployee();
        void DisplayEmployee(Employee employee);
        void DisplayAllEmployees();

        // UC-1
        void CheckAttandance();

        // UC-2
        void CalculateDailyWage();
        void CalculateDailyWage(int eId);

        //UC -3 
        void CalculatePartTimeWage();
        void CalculatePartTimeWage(int eID);

        // UC - 5
        void CalculateMonthlyWage();

        // UC-6

        void CalculateWage();
    }
}
