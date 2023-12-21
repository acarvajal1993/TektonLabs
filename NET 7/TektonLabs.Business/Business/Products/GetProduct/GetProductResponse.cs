using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Core.Business.Productos.ObtenerProducto
{
    public class GetProductResponse : Result
    {
        public GetProductResponse(int discount, string statusName, Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Discount = discount;
            Stock = product.Stock;
            StatuName = statusName;
            FinalPrice = product.Price * (100 - discount) / 100;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string StatuName { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
