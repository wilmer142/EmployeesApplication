using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    public class HourlySalaryEmployee : IEmployee
    {
        public double Salary { set; get; }

        public HourlySalaryEmployee(double salary)
        {
            Salary = salary;
        }

        public double CalculateAnnualSalary()
        {
            return 120 * Salary * 12;
        }
    }
}