using Microsoft.AspNetCore.Mvc;

namespace TektonLabs.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        public ProductsController()
        {
                
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
            throw new Exception();
        }
    }
}
