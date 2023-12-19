using Microsoft.AspNetCore.Mvc;
using TektonLabs.Services.Mocks.Mockapi;

namespace TektonLabs.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IMockapiClient mockapiClient;
        public ProductsController(IMockapiClient mockapiClient)
        {
            this.mockapiClient = mockapiClient;
        }

        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            throw new Exception();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            throw new Exception();
        }

        [HttpGet("{IdProducto:int}")]
        public async Task<IActionResult> GetById(int idProducto)
        {
            var response = mockapiClient.GetProduct("https://657b8b55394ca9e4af147821.mockapi.io/api/v1/products", idProducto.ToString());
            throw new Exception();
        }
    }
}
