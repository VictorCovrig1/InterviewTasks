using EmployeeService.Model;
using EmployeeService.Model.DTOs.Queries;

namespace EmployeeService.Services.Query
{
    public interface IQueryService
    {
        Task<EmployeeQueryDto?> GetEmployeeAsync(int id);
        Task<PaginatedEmployeesDto?> GetEmployeesAsync(QueryParams parms);
    }
}
