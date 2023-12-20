using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Business.Productos.ActualizarProducto;
using TektonLabs.Core.Business.Productos.CrearProducto;
using TektonLabs.Core.Entities;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Test.FunctionalTests.Products
{
    public class UpdateProductTest
    {
        [Fact]
        public void UpdateProductCorrect()
        {
            //Arrange
            Product product = new Product
            {
                Name = "Laptop Lenovo",
                Stock = 5,
                Description = "Old description",
                Price = 1200,
                Status = true
            };

            var request = new UpdateProductRequest()
            {
                Name = "Laptop Lenovo updated",
                Stock = 10,
                Description = "New description",
                Price = 1000,
                Status = false
            };


            //Act
            var useCase = new UpdateProductUseCase(request, product);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.OK);
        }

        [Fact]
        public void UpdateProductIncorrectPrince()
        {
            //Arrange
            Product product = new Product
            {
                Name = "Laptop Lenovo",
                Stock = 5,
                Description = "Old description",
                Price = 1200,
                Status = true
            };

            var request = new UpdateProductRequest()
            {
                Name = "Laptop Lenovo updated",
                Stock = 10,
                Description = "Great product",
                Price = -1200,
                Status = false
            };

            //Act
            var useCase = new UpdateProductUseCase(request, product);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.BAD_REQUEST);
        }

        [Fact]
        public void UpdateProductNullName()
        {
            //Arrange
            Product product = new Product
            {
                Name = "Laptop Lenovo",
                Stock = 5,
                Description = "Old description",
                Price = 1200,
                Status = true
            };

            var request = new UpdateProductRequest()
            {
                Name = null,
                Stock = 10,
                Description = "Great product",
                Price = 1200,
                Status = false
            };

            //Act
            var useCase = new UpdateProductUseCase(request, product);
            var result = useCase.Execute();

            //Assert
            Assert.Equal(result.Code, Result.BAD_REQUEST);
        }
    }
}
