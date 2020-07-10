using MediatR;
using MGtestCCG.Application.DTO;
using System.ComponentModel.DataAnnotations;

namespace MGtestCCG.Application.Query
{
    public class GetEmployeeByIdAndContractQuery : IRequest<EmployeeSalaryDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
