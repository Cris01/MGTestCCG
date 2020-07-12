using MediatR;
using MGtestCCG.Application.DTO;
using System.Collections.Generic;

namespace MGtestCCG.Application.Query
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeSalaryDTO>>
    {
    }
}
