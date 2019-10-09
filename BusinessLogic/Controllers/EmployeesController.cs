using BusinessLogic.Enumerations;
using BusinessLogic.Factories;
using BusinessLogic.Models;
using DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusinessLogic.Controllers
{
    public class EmployeesController : ApiController
    {
        public async Task<List<EmployeeViewModel>> Get()
        {
            List<EmployeeViewModel> employees = await ApiProcessor.LoadEmployeeInformation<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                employee.AnnualSalary = CalculateAnnualSalary.CalculateSalary((EContractType)Enum.Parse(typeof(EContractType), employee.ContractTypeName, true), employee.HourlySalary, employee.MonthlySalary);
            }
            return employees;
        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            var employees = await Get();
            return employees.First(x => x.Id.Equals(id));
        }
    }
}
