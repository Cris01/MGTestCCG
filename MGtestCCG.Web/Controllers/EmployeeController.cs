using MediatR;
using MGtestCCG.Application.DTO;
using MGtestCCG.Application.Query;
using MGtestCCG.Domain.Entities;
using MGtestCCG.Domain.Irepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGtestCCG.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;
        private readonly IMediator _Mediator;
        public EmployeeController(IMediator mediator, IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this.employeeRepository.GetAllAsync().ConfigureAwait(false);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetEmployeeByIdAndContractQuery request)
        {
            var result = await _Mediator.Send(request).ConfigureAwait(false);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetByPhone([FromQuery] GetEmployeeByPhoneAndContractQuery request)
        {
            var result = await _Mediator.Send(request).ConfigureAwait(false);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}