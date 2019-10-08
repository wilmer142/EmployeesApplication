using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    class MonthlySalaryEmployee : IEmployee
    {
        public double CalculateAnnualSalary(double salary)
        {
            return salary * 12;
        }
    }
}