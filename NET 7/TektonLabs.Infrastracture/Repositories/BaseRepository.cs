using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.Infrastracture.Data;
using TektonLabs.Infrastracture.Repositories.Interfaces;

namespace TektonLabs.Infrastracture.Repositories
{
    public class BaseRepository: IBaseRepository
    {
        private readonly TektonLabsContext context;
        public BaseRepository(TektonLabsContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(object entity)
        {
            await context.AddAsync(entity);
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
