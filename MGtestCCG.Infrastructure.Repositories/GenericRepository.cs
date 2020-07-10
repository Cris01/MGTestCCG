using MGtestCCG.Domain.Irepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGtestCCG.Infrastructure.Repositories
{
    public class GenericRepository<E> : IGenericRepository<E> where E : Domain.Entities.DomainEntity
    {
        private readonly EmployeeContext employeeContext;
        private readonly DbSet<E> _Set;

        public GenericRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
            _Set = this.employeeContext.Set<E>();
        }
        public async Task<IEnumerable<E>> GetAllAsync()
        {
            return await _Set.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<E> GetByIdAsync(object id)
        {
            return await _Set.FindAsync(id).ConfigureAwait(false);
        }
    }
}
