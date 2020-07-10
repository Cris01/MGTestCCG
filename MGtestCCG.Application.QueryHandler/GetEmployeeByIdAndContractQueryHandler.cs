using MediatR;
using MGtestCCG.Application.DTO;
using MGtestCCG.Application.Query;
using MGtestCCG.Domain.Irepositories;
using MGtestCCG.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MGtestCCG.Application.QueryHandler
{
    public class GetEmployeeByIdAndContractQueryHandler : IRequestHandler<GetEmployeeByIdAndContractQuery, EmployeeSalaryDTO>
    {
       
        private readonly IEmployeeRepository _employeeRepository;

        private readonly Func<EmployeeContractType, IEmployeeService> _serviceDelegate;
        public GetEmployeeByIdAndContractQueryHandler(Func<EmployeeContractType, IEmployeeService> serviceDelegate, IEmployeeRepository employeeRepository)
        {
            _serviceDelegate = serviceDelegate;
            _employeeRepository = employeeRepository;
        }


        public async Task<EmployeeSalaryDTO> Handle(GetEmployeeByIdAndContractQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await this._employeeRepository.GetByIdAsync(request.Id);
                var serviceEmployee = _serviceDelegate((EmployeeContractType)employee.TypeContract);
                var calculatedSalary = await serviceEmployee.CalculateEmployeeSalaryAsync(request.Id);
                return new EmployeeSalaryDTO { CalculatedSalary = calculatedSalary, CompleteName = $"{employee.Name} {employee.LastName}" };
            }
            catch (Exception)
            {

                return null;
            }
            
        }
    }
}
