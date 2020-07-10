using MGtestCCG.Domain.Irepositories;
using System.Threading.Tasks;

namespace MGtestCCG.Domain.Services
{
    public class EmployeeServicePerHour : IEmployeeService
    {
        private const double YEAR = 12;
        private const double HOUR_PER_MONTH = 120;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeServicePerHour(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<double> CalculateEmployeeSalaryAsync(int employeeId)
        {
            var currentEmployee = await employeeRepository.GetByIdAsync(employeeId).ConfigureAwait(false);
            var calculatedSalary = (currentEmployee.HourlySalary * HOUR_PER_MONTH) * YEAR;
            return calculatedSalary;
        }
    }
}
