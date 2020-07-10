using MGtestCCG.Domain.Irepositories;
using System.Threading.Tasks;

namespace MGtestCCG.Domain.Services
{
    public class EmployeeServicePerMonth : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private const double YEAR = 12;
        public EmployeeServicePerMonth(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<double> CalculateEmployeeSalaryAsync(int employeeId)
        {
            var currentEmployee = await employeeRepository.GetByIdAsync(employeeId).ConfigureAwait(false);
            var calculatedSalary = currentEmployee.MonthlySalary * YEAR;
            return calculatedSalary;
        }
    }
}
