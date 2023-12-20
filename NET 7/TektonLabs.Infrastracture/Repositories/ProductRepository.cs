using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Core.Entities;
using TektonLabs.Infrastracture.Data;
using TektonLabs.Infrastracture.Repositories.Interfaces;

namespace TektonLabs.Infrastracture.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly TektonLabsContext context;
        public ProductRepository(TektonLabsContext context)
        {
            this.context = context;
        }
        public async Task<Product> GetProductById(int productId)
        {
            return await context.Product.FirstOrDefaultAsync(p => p.ProductId == productId);
        }
    }
}
