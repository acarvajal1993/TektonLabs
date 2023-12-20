using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;

namespace TektonLabs.Test.UnitTests.Products
{
    public class UpdateProductTest
    {
        [Fact]
        public void UpdateProductCorrect()
        {
            //Arrange
            var product = new Product
            {
                Name = "Product 1",
                Price = 200,
                Stock = 5,
                Description = "Description 1",
                Status = false
            };

            //Act
            product.Update("Product updated", true, 10, "Description updated", 450);

            //Assert
            Assert.Equal(product.Name, "Product updated");
            Assert.Equal(product.Price, 450);
            Assert.Equal(product.Stock, 10);
            Assert.Equal(product.Description, "Description updated");
            Assert.Equal(product.Status, true);
        }
    }
}
