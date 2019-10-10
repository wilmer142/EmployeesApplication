using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BusinessLogic.Controllers;
using BusinessLogic.Enumerations;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TestEmployeesController
    {
        [TestMethod]
        public async Task GetAllEmployeesAsyncShouldReturnAllEmployees()
        {
            var testEmployees = GetTestEmployees();
            var employeesController = new EmployeesController(testEmployees);

            var result = await employeesController.GetAllEmployeesAsync() as List<EmployeeViewModel>;
            Assert.AreEqual(testEmployees.Count, result.Count);
        }

        [TestMethod]
        public async Task GetEmployeeAsyncShouldReturnCorrectEmployee()
        {
            var testEmployees = GetTestEmployees();
            var controller = new EmployeesController(testEmployees);

            var result = await controller.GetEmployeeAsync(4) as OkNegotiatedContentResult<EmployeeViewModel>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testEmployees[3].Id, result.Content.Id);
        }

        [TestMethod]
        public void GetEmployeeAsyncShouldNotFindEmployee()
        {
            var controller = new EmployeesController(GetTestEmployees());

            var result = controller.GetEmployeeAsync(999);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        private List<EmployeeViewModel> GetTestEmployees()
        {
            var testEmployees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel { Id = 1, ContractTypeName = EContractType.HourlySalaryEmployee.ToString(), Name = "Employee1", RoleId = 1, HourlySalary = 10000, MonthlySalary = 20000 },
                new EmployeeViewModel { Id = 2, ContractTypeName = EContractType.MonthlySalaryEmployee.ToString(), Name = "Employee2", RoleId = 2, HourlySalary = 20000, MonthlySalary = 40000 },
                new EmployeeViewModel { Id = 3, ContractTypeName = EContractType.MonthlySalaryEmployee.ToString(), Name = "Employee3", RoleId = 3, HourlySalary = 30000, MonthlySalary = 60000 },
                new EmployeeViewModel { Id = 4, ContractTypeName = EContractType.HourlySalaryEmployee.ToString(), Name = "Employee4", RoleId = 4, HourlySalary = 40000, MonthlySalary = 80000 }
            };

            return testEmployees;
        }
    

    }
}
