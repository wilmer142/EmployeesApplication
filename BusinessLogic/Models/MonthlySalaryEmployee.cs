using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    class MonthlySalaryEmployee : IEmployee
    {
        public double Salary { set; get; }

        public MonthlySalaryEmployee(double salary)
        {
            Salary = salary;
        }

        public double CalculateAnnualSalary()
        {
            return Salary * 12;
        }
    }
}