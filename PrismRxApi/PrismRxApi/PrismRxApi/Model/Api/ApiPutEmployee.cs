using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismRxApi.Model.Api
{
    public class ApiPutEmployee : ApiPut<Employee>
    {
        public async Task PutDataAsync(Employee employee)
        {
            var jsonSetting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var parameters = new Dictionary<string, string>
            {
                {"name", employee.Name}
                ,{"salary", employee.Salary }
                ,{"age", employee.Age}
            };
            var json = JsonConvert.SerializeObject(parameters, jsonSetting);
            var content = new StringContent(json, Encoding.UTF8, @"application/json");
            var url = Constants.API_END_POINT + "update/" + employee.Id;
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
