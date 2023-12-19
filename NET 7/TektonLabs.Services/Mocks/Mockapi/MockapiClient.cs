using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Tools.API;

namespace TektonLabs.Services.Mocks.Mockapi
{
    public class MockapiClient : IMockapiClient
    {
        private readonly APIClient httpClient;
        public MockapiClient(HttpClient httpClient)
        {
            this.httpClient = new APIClient(httpClient);
        }

        public async Task<APIResponse> GetProduct(string url, string parameter)
        {
            return await httpClient.Get($"{url}/{parameter}");
        }
    }
}
