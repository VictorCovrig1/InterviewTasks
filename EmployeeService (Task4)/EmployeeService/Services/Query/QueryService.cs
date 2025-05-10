using EmployeeService.DBContext;
using EmployeeService.Model;
using EmployeeService.Model.DTOs.Queries;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services.Query
{
    public class QueryService : IQueryService
    {
        private readonly EmployeeDbContext _dbContext;

        public QueryService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeQueryDto?> GetEmployeeAsync(int id)
        {
            try
            {
                var employee = await _dbContext.Employees.Join(
                _dbContext.Departments,
                    employee => employee.DepartmentId,
                    department => department.DepartmentId,
                    (employee, department) => new
                    {
                        employee,
                        department
                    }
                )
                .Join(_dbContext.Functions,
                    employee => employee.employee.FunctionId,
                    function => function.FunctionId,
                    (employee, function) => new
                    {
                        EmployeeId = employee.employee.EmployeeId,
                        DepartmentName = employee.department.DepartmentName,
                        FunctionName = employee.department.DepartmentName,
                        PostTitle = employee.employee.PostTitle,
                        FirstName = employee.employee.FirstName,
                        LastName = employee.employee.LastName,
                        BirthDate = employee.employee.BirthDate,
                        EmploymentDate = employee.employee.EmploymentDate,
                        Salary = employee.employee.Salary
                    })
                .FirstOrDefaultAsync(empl => empl.EmployeeId == id);

                if (employee == null)
                    return null;

                return new EmployeeQueryDto(employee.EmployeeId, employee.DepartmentName,
                    employee.FunctionName, employee.PostTitle, employee.FirstName, employee.LastName,
                    employee.BirthDate, employee.EmploymentDate, employee.Salary);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PaginatedEmployeesDto?> GetEmployeesAsync(QueryParams parms)
        {
            try
            {
                var employees = await _dbContext.Employees.Join(
                _dbContext.Departments,
                    employee => employee.DepartmentId,
                    department => department.DepartmentId,
                    (employee, department) => new
                    {
                        employee,
                        department
                    }
                )
                .Join(_dbContext.Functions,
                    employee => employee.employee.FunctionId,
                    function => function.FunctionId,
                    (employee, function) => new
                    {
                        EmployeeId = employee.employee.EmployeeId,
                        DepartmentName = employee.department.DepartmentName,
                        FunctionName = employee.department.DepartmentName,
                        PostTitle = employee.employee.PostTitle,
                        FirstName = employee.employee.FirstName,
                        LastName = employee.employee.LastName,
                        BirthDate = employee.employee.BirthDate,
                        EmploymentDate = employee.employee.EmploymentDate,
                        Salary = employee.employee.Salary
                    }).Where(empl => empl.FunctionName.Contains(parms.FilterKey) || 
                        empl.FirstName.Contains(parms.FilterKey) || 
                        empl.LastName.Contains(parms.FilterKey))
                    .Skip((parms.PageIndex - 1) * parms.PageSize).Take(parms.PageSize).ToListAsync();

                if (employees == null || employees.Count == 0)
                    return null;

                if (parms.SortOrder != null && (parms.SortOrder == "asc" || parms.SortOrder == "desc"))
                {
                    var sortedEmployees = parms.SortOrder.ToLower() == "desc" ?
                                            employees.OrderByDescending(empl => empl.Salary) :
                                            employees.OrderBy(empl => empl.Salary);
                }

                var results = new List<EmployeeQueryDto>();

                foreach (var employee in employees)
                {
                    results.Add(new EmployeeQueryDto(employee.EmployeeId, employee.DepartmentName,
                        employee.FunctionName, employee.PostTitle, employee.FirstName, employee.LastName,
                        employee.BirthDate, employee.EmploymentDate, employee.Salary));
                }

                return new PaginatedEmployeesDto(results, results.Count, parms.PageIndex, parms.SafePageSize);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
