using ModernHttpClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrismRxApi.Model.Api
{
    public class ApiPutEmployee : ApiPut<Employee>
    {
        public async Task PutDataAsync(Employee employee)
        {
            var parameters = new Dictionary<string, string>
            {
                {"employee_name", employee.Name}
                ,{"employee_salary", employee.Salary }
                ,{"employee_age", employee.Age}
            };
            var content = new FormUrlEncodedContent(parameters);
            var url = Constants.API_END_POINT + "update/" + employee.Id;
            // todo: 更新に成功しない
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var response = await client.PutAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    // show error message
                    return;
                }
                var data = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(data);
            }
            return;
        }
    }
}
