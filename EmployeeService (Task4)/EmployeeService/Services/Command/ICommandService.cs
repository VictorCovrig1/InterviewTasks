using EmployeeService.Model.DTOs.Commands;
namespace EmployeeService.Services.Command
{
    public interface ICommandService
    {
        Task<bool> CreateEmployeeAsync(EmployeeCreateDto employee);
        Task<bool> UpdateEmployeeAsync(EmployeeUpdateDto employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}
