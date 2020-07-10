using System.Threading.Tasks;

namespace MGtestCCG.Domain.Services
{
    public interface IEmployeeService
    {
        Task<double> CalculateEmployeeSalaryAsync(int employeeId);
    }
}