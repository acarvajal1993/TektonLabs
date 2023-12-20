using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;

namespace TektonLabs.Infrastracture.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int productId);
    }
}
