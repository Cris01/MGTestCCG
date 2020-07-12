using MediatR;
using MGtestCCG.Application.DTO;
using MGtestCCG.Application.Query;
using MGtestCCG.Domain.Irepositories;
using MGtestCCG.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MGtestCCG.Application.QueryHandler
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeSalaryDTO>>
    {

        private readonly IEmployeeRepository _employeeRepository;

        private readonly Func<EmployeeContractType, IEmployeeService> _serviceDelegate;
        public GetAllEmployeeQueryHandler(Func<EmployeeContractType, IEmployeeService> serviceDelegate, IEmployeeRepository employeeRepository)
        {
            _serviceDelegate = serviceDelegate;
            _employeeRepository = employeeRepository;
        }


        public async Task<IEnumerable<EmployeeSalaryDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await this._employeeRepository.GetAllAsync();
                List<EmployeeSalaryDTO> list = new List<EmployeeSalaryDTO>();
                foreach (var item in employee)
                {
                    var serviceEmployee = _serviceDelegate((EmployeeContractType)item.TypeContract);
                    var calculatedSalary = await serviceEmployee.CalculateEmployeeSalaryAsync(item.Id);
                    var employeeWithSalary = new EmployeeSalaryDTO
                    {
                        CalculatedSalary = calculatedSalary,
                        CompleteName = $"{item.Name} {item.LastName}",
                        Id = item.Id,
                        PhoneNumber = item.PhoneNumber
                    };

                    list.Add(employeeWithSalary);
                }
                return list;

            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}


