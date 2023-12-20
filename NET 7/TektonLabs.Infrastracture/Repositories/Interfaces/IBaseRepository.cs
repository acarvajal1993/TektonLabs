using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Infrastracture.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task AddAsync(object entity);
        Task SaveChangesAsync();
    }
}
