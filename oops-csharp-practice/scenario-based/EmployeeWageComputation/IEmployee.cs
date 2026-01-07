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

        // UC-1
        void CheckAttandance();
    }
}
