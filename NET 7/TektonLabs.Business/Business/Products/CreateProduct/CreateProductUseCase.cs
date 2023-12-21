using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Core.Business.Productos.CrearProducto
{
    public class CreateProductUseCase
    {
        private readonly CreateProductRequest request;
        public Product NewProduct { get; set; }
        public CreateProductUseCase(CreateProductRequest request)
        {
            this.request = request;
        }

        public Result Execute()
        {
            Result result = RequestValidation();

            if (result == null)
            {
                CreateProduct();
                result = new() { Message = "The product has been created successfully" };
            }

            return result;
        }

        public Result RequestValidation()
        {
            Result result = null;

            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Description) || request.Stock <= 0 ||
                request.Price <= 0)
                result = new() { Code = Result.BAD_REQUEST, Type = "invalid_information", Message = "There is one or more errors, please set all the fields correctly" };

            return result;
        }

        public void CreateProduct()
        {
            NewProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Status = true
            };
        }
    }
}
