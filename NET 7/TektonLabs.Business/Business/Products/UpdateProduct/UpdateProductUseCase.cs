using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Core.Business.Productos.ActualizarProducto
{
    public class UpdateProductUseCase
    {
        private readonly UpdateProductRequest request;
        private readonly Product product;

        public UpdateProductUseCase(UpdateProductRequest request, Product product)
        {
            this.request = request;
            this.product = product;
        }

        public Result Execute()
        {
            Result result = ProductValidation();

            if (result == null)
            {
                result = RequestValidation();

                if (result == null)
                {
                    product.Update(request.Name, request.Status, request.Stock, request.Description, request.Price);
                    result = new();
                }
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
        public Result ProductValidation()
        {
            Result result = null;

            if (product == null)
                result = new() { Code = Result.NOT_FOUND, Type = "product_not_found", Message = "The product was not found" };

            return result;
        }
    }
}
