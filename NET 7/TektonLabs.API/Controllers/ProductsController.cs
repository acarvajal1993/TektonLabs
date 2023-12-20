using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TektonLabs.Core.Business.Productos.ActualizarProducto;
using TektonLabs.Core.Business.Productos.CrearProducto;
using TektonLabs.Core.Business.Productos.ObtenerProducto;
using TektonLabs.Infrastracture.Repositories.Interfaces;
using TektonLabs.Services.Mocks.Mockapi;
using TektonLabs.Services.Mocks.Mockapi.Responses;
using TektonLabs.Tools.API;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController: BaseController
    {
        private readonly IMockapiClient mockapiClient;
        private readonly IBaseRepository baseRepository;
        private readonly IProductRepository productRepository;

        public ProductsController(IMockapiClient mockapiClient, IBaseRepository baseRepository,
            IProductRepository productRepository)
        {
            this.mockapiClient = mockapiClient;
            this.baseRepository = baseRepository;
            this.productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateProductRequest request)
        {
            //State
            //There is nothing to get

            //Execution
            var useCase = new CreateProductUseCase(request);
            var result = useCase.Execute();

            //Save the state
            if (result.Code == Result.OK)
            {
                await baseRepository.AddAsync(useCase.NewProduct);
                await baseRepository.SaveChangesAsync();
            }

            //Response
            return ResultResponse(result);
        }

        [HttpPut("{productId:int}")]
        public async Task<IActionResult> Update(int productId, [FromBody] UpdateProductRequest request)
        {
            //State
            var product = await productRepository.GetProductById(productId);

            //Execution
            var useCase = new UpdateProductUseCase(request, product);
            var result = useCase.Execute();

            //Save the state
            if (result.Code == Result.OK)
                await baseRepository.SaveChangesAsync();

            //Response
            return ResultResponse(result);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetById(int productId)
        {
            APIResponse response = await mockapiClient.GetProduct("https://657b8b55394ca9e4af147821.mockapi.io/api/v1/products", productId.ToString());

            var jResponse = JsonConvert.DeserializeObject<MockapiGetDiscountResponse>(response.Body);

            return ResultResponse(new GetProductResponse());
        }
    }
}
