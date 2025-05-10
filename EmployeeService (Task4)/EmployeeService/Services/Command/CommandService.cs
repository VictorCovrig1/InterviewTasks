using EmployeeService.DBContext;
using EmployeeService.Model.DTOs.Commands;
using EmployeeService.Model.Entities;

namespace EmployeeService.Services.Command
{
    public class CommandService : ICommandService
    {
        private readonly EmployeeDbContext _dbContext;

        public CommandService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeCreateDto employee)
        {
            try
            {
                var employeeEntity = new Employee()
                {
                    DepartmentId = employee.DepartmentId,
                    FunctionId = employee.FunctionId,
                    PostTitle = employee.PostTitle,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BirthDate = employee.BirthDate,
                    EmploymentDate = employee.EmploymentDate,
                    Salary = employee.Salary
                };

                _dbContext.Employees.Add(employeeEntity);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = _dbContext.Employees.FirstOrDefault(empl => empl.EmployeeId == employeeId);
                if (employee != null)
                {
                    _dbContext.Remove(employee);
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeUpdateDto employee)
        {
            try
            {
                var entity = _dbContext.Employees.FirstOrDefault(empl => empl.EmployeeId == employee.EmployeeId);

                if (entity != null)
                {
                    entity.DepartmentId = employee.DepartmentId;
                    entity.FunctionId = employee.FunctionId;
                    entity.FirstName = employee.FirstName;
                    entity.LastName = employee.LastName;
                    entity.BirthDate = employee.BirthDate;
                    entity.EmploymentDate = employee.EmploymentDate;
                    entity.PostTitle = employee.PostTitle;
                    entity.Salary = employee.Salary;

                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
