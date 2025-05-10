namespace EmployeeService.Model.DTOs.Queries
{
    public record EmployeeQueryDto(int EmployeeId, string DepartmentName, 
        string FunctionName, string PostTitle, string FirstName, string LastName,
        DateTime BirthDate, DateTime EmploymentDate, decimal Salary);
}
