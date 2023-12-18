using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Tools.API
{
    public class APIResponse
    {
        public string Body { get; set; }
        public HttpStatusCode Code { get; set; }
        public APIResponse()
        {
            Code = 0;
            Body = null;
        }
        public APIResponse(HttpStatusCode Code, string Body)
        {
            this.Code = Code;
            this.Body = Body;
        }
    }
}
