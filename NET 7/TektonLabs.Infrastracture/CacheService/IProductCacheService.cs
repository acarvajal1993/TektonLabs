using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Infrastracture.CacheService
{
    public interface IProductCacheService
    {
        Dictionary<int, string> GetProductState();
    }
}
