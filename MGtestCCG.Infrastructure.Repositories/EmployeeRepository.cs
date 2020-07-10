using MGtestCCG.Domain.Entities;
using MGtestCCG.Domain.Irepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MGtestCCG.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly EmployeeContext employeeContext;
        private readonly DbSet<Employee> _Set;
        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
            this.employeeContext = employeeContext;
            _Set = this.employeeContext.Set<Employee>();
        }

        public async Task<Employee> GetByEmployeePhoneNumber(string employeePhoneNumber)
        {
            var employee = await _Set.FirstOrDefaultAsync(epl => epl.PhoneNumber.Contains(employeePhoneNumber)).ConfigureAwait(false);
            return employee;
        }
    }
}
