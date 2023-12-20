using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Business.Productos.CrearProducto;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Test.FunctionalTests.Products
{
    public class CreateProductTest
    {
        [Fact]
        public void CreateProductCorrect()
        {
            //Arrange
            var request = new CreateProductRequest()
            {
                Name = "Laptop Lenovo",
                Stock = 10,
                Description = "This is an amazing product with a lot of functions",
                Price = 1200,
            };

            //Act
            var useCase = new CreateProductUseCase(request);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.OK);
        }

        [Fact]
        public void CreateProductIncorrectStock()
        {
            //Arrange
            var request = new CreateProductRequest()
            {
                Name = "Laptop Lenovo",
                Stock = -10,
                Description = "This is an amazing product with a lot of functions",
                Price = 1200
            };

            //Act
            var useCase = new CreateProductUseCase(request);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.BAD_REQUEST);
        }


        [Fact]
        public void CreateProductIncorrectPrice()
        {
            //Arrange
            var request = new CreateProductRequest()
            {
                Name = "Laptop Lenovo",
                Stock = 10,
                Description = "This is an amazing product with a lot of functions",
                Price = -1200
            };

            //Act
            var useCase = new CreateProductUseCase(request);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.BAD_REQUEST);
        }
    }
}
