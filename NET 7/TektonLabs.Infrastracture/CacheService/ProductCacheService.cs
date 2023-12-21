using Microsoft.Extensions.Caching.Memory;

namespace TektonLabs.Infrastracture.CacheService
{
    public class ProductCacheService : IProductCacheService
    {
        private readonly IMemoryCache memoryCache;
        public ProductCacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public Dictionary<int, string> GetProductState()
        {
            if (!memoryCache.TryGetValue("ProductStates", out Dictionary<int, string> productStates))
            {
                productStates = UploadProductState();
                memoryCache.Set("ProductStates", productStates, TimeSpan.FromMinutes(5));
            }

            return productStates;
        }
        private Dictionary<int, string> UploadProductState()
        {
            return new Dictionary<int, string>
        {
            { 1, "Active" },
            { 0, "Inactive" }
        };
        }
    }
}
