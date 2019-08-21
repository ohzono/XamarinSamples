using ModernHttpClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrismRxApi.Model.Api
{
    public class ApiGetEmployees : ApiGet<IEnumerable<Employee>>
    {
        public List<Employee> employees;
        public string paramId = string.Empty;
        public async Task<IEnumerable<Employee>> GetDataAsync()
        {
            employees = new List<Employee>();

            var url = Constants.API_END_POINT + "employees";

            if (paramId != string.Empty)
            {
                url += "/" + paramId;
            }

            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var data = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(data);
                employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return employees;
        }

        public void SetParam(string id)
        {
            paramId = id;
        }
    }
}
