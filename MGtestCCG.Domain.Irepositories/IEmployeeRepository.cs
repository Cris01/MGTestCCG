using MGtestCCG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MGtestCCG.Domain.Irepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByEmployeePhoneNumber(string employeePhoneNumber);
    }
}
