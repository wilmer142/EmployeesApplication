using BusinessLogic.Enumerations;
using BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Models
{
    public static class CalculateAnnualSalary
    {
        public static double CalculateSalary(EContractType contractType, double hourlySalary, double monthlySalary)
        {
            var calculateSalaryFactory = EmployeeFactory.Factory(contractType, hourlySalary, monthlySalary);
            return calculateSalaryFactory.CalculateAnnualSalary();
        }
    }
}