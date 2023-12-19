using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Tools.API;

namespace TektonLabs.Services.Mocks.Mockapi
{
    public interface IMockapiClient
    {
        Task<APIResponse> GetProduct(string url, string parameter);
    }
}
