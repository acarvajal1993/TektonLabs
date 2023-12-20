using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Services.Mocks.Mockapi.Responses
{
    public class MockapiGetDiscountResponse: Result
    {
        public int Id { get; set; }
        public int Discount { get; set; }
    }
}
