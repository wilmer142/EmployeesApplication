using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    public class HourlySalaryEmployee : IEmployee
    {
        public double CalculateAnnualSalary(double salary)
        {
            return 120 * salary * 12;
        }
    }
}