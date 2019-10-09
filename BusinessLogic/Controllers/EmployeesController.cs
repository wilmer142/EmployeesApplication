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
            var employees = await ApiProcessor.LoadEmployeeInformation();
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            foreach (var employee in employees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    Id = employee.Id,
                    ContractTypeName = employee.ContractTypeName,
                    HourlySalary = employee.HourlySalary,
                    MonthlySalary = employee.MonthlySalary,
                    Name = employee.Name,
                    RoleDescription = employee.RoleDescription,
                    RoleName = employee.RoleName,
                    AnnualSalary = CalculateAnnualSalary.CalculateSalary((EContractType)Enum.Parse(typeof(EContractType), employee.ContractTypeName, true), employee.HourlySalary, employee.MonthlySalary)
                };

                result.Add(employeeViewModel);
            }
            return result;
        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            var employees = await Get();
            return employees.First(x => x.Id.Equals(id));
        }
    }
}
