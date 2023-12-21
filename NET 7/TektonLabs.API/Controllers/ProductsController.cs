using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TektonLabs.Infrastracture.CacheService;
using TektonLabs.Core.Business.Productos.ActualizarProducto;
using TektonLabs.Core.Business.Productos.CrearProducto;
using TektonLabs.Core.Business.Productos.ObtenerProducto;
using TektonLabs.Core.Entities;
using TektonLabs.Infrastracture.Repositories.Interfaces;
using TektonLabs.Services.Mocks.Mockapi;
using TektonLabs.Services.Mocks.Mockapi.Responses;
using TektonLabs.Tools.API;
using TektonLabs.Tools.HTTPResponse;
using System.Diagnostics;

namespace TektonLabs.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController: BaseController
    {
        private readonly IMockapiClient mockapiClient;
        private readonly IBaseRepository baseRepository;
        private readonly IProductRepository productRepository;
        private readonly IConfiguration configuration;
        private readonly IProductCacheService productCacheService;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IMockapiClient mockapiClient, IBaseRepository baseRepository,
            IProductRepository productRepository,
            IConfiguration configuration,
            IProductCacheService productCacheService,
            ILogger<ProductsController> logger)
        {
            this.mockapiClient = mockapiClient;
            this.baseRepository = baseRepository;
            this.productRepository = productRepository;
            this.configuration = configuration;
            this.productCacheService = productCacheService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateProductRequest request)
        {
            //State
            //There is nothing to validate
            var stopwatch = Stopwatch.StartNew();

            //Execution
            var useCase = new CreateProductUseCase(request);
            var result = useCase.Execute();

            //Save the state
            if (result.Code == Result.OK)
            {
                await baseRepository.AddAsync(useCase.NewProduct);
                await baseRepository.SaveChangesAsync();
            }

            //Logging
            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;

            logger.LogInformation($"Response time of Insert request: {responseTime} ms");

            //Response
            return ResultResponse(result);
        }

        [HttpPut("{productId:int}")]
        public async Task<IActionResult> Update(int productId, [FromBody] UpdateProductRequest request)
        {
            //State
            var stopwatch = Stopwatch.StartNew();
            var product = await productRepository.GetProductById(productId);

            //Execution
            var useCase = new UpdateProductUseCase(request, product);
            var result = useCase.Execute();

            //Save the state
            if (result.Code == Result.OK)
                await baseRepository.SaveChangesAsync();

            //Logging
            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;

            logger.LogInformation($"Response time of Update request: {responseTime} ms");

            //Response
            return ResultResponse(result);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetById(int productId)
        {
            //State
            var stopwatch = Stopwatch.StartNew();
            var product = await productRepository.GetProductById(productId);
            APIResponse response = await mockapiClient.GetProduct(configuration["URLMockapi"], productId.ToString());

            int productStatus = product.Status ? 1 : 0;

            var statusName = productCacheService.GetProductState()[productStatus];

            var jResponse = JsonConvert.DeserializeObject<MockapiGetDiscountResponse>(response.Body);

            //Logging
            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;

            logger.LogInformation($"Response time of GetById request: {responseTime} ms");

            //Response
            return ResultResponse(new GetProductResponse(jResponse.Discount, statusName, product));
        }
    }
}
