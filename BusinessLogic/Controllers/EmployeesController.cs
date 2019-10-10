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
using System.Web.Http.Cors;

namespace BusinessLogic.Controllers
{
    [EnableCors(origins: "http://localhost:63935", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

        public EmployeesController() { }

        public EmployeesController(List<EmployeeViewModel> employees)
        {
            this.employees = employees;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            if (employees == null || !employees.Any())
            {
                employees = await ApiProcessor.LoadEmployeeInformation<EmployeeViewModel>();
            }


            foreach (var employee in employees)
            {
                employee.AnnualSalary = CalculateAnnualSalary.CalculateSalary((EContractType)Enum.Parse(typeof(EContractType), employee.ContractTypeName, true), employee.HourlySalary, employee.MonthlySalary);
            }
            return employees;
        }


        public async Task<IHttpActionResult> GetEmployeeAsync(int id)
        {
            var employees = await GetAllEmployeesAsync();
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
