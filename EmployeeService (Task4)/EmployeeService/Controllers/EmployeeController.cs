using EmployeeService.Model;
using EmployeeService.Model.DTOs.Commands;
using EmployeeService.Services.Command;
using EmployeeService.Services.Query;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IQueryService _queryService;
        private readonly ICommandService _commandService;

        public EmployeeController(ICommandService commandService, IQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _queryService.GetEmployeeAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] QueryParams parms)
        {
            var result = await _queryService.GetEmployeesAsync(parms);

            if (result == null)
                return NotFound();

            return Ok(new { result.Employees, result.HasPreviousPage, result.HasNextPage, result.TotalPages });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await _commandService.DeleteEmployeeAsync(id) ?
                Ok() : 
                BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateDto employee)
        {
            return await _commandService.UpdateEmployeeAsync(employee) ? 
                Ok() : 
                BadRequest();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto employee)
        {
            return await _commandService.CreateEmployeeAsync(employee) ?
                Ok() :
                BadRequest();
        }
    }
}
