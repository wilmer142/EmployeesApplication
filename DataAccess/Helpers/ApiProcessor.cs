using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public class ApiProcessor
    {
        private const string url = "http://masglobaltestapi.azurewebsites.net/api/Employees";

        public static async Task<List<EmployeeModel>> LoadEmployeeInformation()
        {
            ApiHelper.InitializeClient();
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<EmployeeModel> employees = await response.Content.ReadAsAsync<List<EmployeeModel>>();

                    return employees;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }
    }
}
