using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Tools.API
{
    public class APIClient
    {
        private HttpClient httpClient;
        public APIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<APIResponse> Get(string url)
        {
            var response = await httpClient.GetAsync(url);
            var sResponse = await response.Content.ReadAsStringAsync();
            return new APIResponse(response.StatusCode, sResponse);
        }
    }
}
