using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class Employee
    {
        // private fields with getter setter
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public double EmployeeSalary { get; set; }
        public bool IsPresent { get; set; }

        // no consturctor


        // override toString
        public override string ToString()
        {
            return $"ID: {EmployeeId} || Name: {EmployeeName} || Age: {EmployeeAge} || Salary : {EmployeeSalary}";
        }
    }
}
