using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace MGtestCCG.Domain.Irepositories
{
    public interface IGenericRepository<E> where E : Domain.Entities.DomainEntity
    {
        Task<IEnumerable<E>> GetAllAsync();

        Task<E> GetByIdAsync(object id);

    }
}
