using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Tools.HTTPResponse
{
    public class Result
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public string Type { get; set; } = null!;

        //Constantes
        public const int OK = 200;
        public const int BAD_REQUEST = 400;
        public const int NOT_FOUND = 404;
        public const int INTERNAL_SERVER_ERROR = 500;
        public const int UNPROCESSABLE_ENTITY = 422;
        public const int UNAUTHORIZED = 401;
        public Result()
        {
            Code = 200;
        }
    }
}
