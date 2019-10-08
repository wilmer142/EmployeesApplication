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
        static double CalculateSalary(EContractType contractType, double salary)
        {
            var calculateSalaryFactory = EmployeeFactory.Factory(contractType);
            return calculateSalaryFactory.CalculateAnnualSalary(salary);
        }
    }
}