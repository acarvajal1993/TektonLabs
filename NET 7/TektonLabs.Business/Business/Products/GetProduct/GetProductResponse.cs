using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Tools.HTTPResponse;

namespace TektonLabs.Core.Business.Productos.ObtenerProducto
{
    public class GetProductResponse : Result
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
