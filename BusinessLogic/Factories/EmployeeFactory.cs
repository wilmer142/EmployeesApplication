using BusinessLogic.Enumerations;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogic.Factories
{
    public static class EmployeeFactory
    {
        public static IEmployee Factory(EContractType contractType)
        {
            if (contractType == EContractType.HourlySalaryEmployee) return new HourlySalaryEmployee();
            if (contractType == EContractType.MonthlySalaryEmployee) return new MonthlySalaryEmployee();

            throw new ApplicationException();
        }

    }
}