using MediatR;
using MGtestCCG.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace MGtestCCG.Application.Query
{
    public class GetEmployeeByPhoneAndContractQuery : IRequest<EmployeeSalaryDTO>
    {
        [Required]
        public string CellPhone { get; set; }
    }
}
