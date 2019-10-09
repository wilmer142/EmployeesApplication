using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public class ApiProcessor
    {
        private const string url = "http://masglobaltestapi.azurewebsites.net/api/Employees";

        public static async Task<List<T>> LoadEmployeeInformation<T>()
        {
            ApiHelper.InitializeClient();
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<T> employees = await response.Content.ReadAsAsync<List<T>>();

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
