namespace EmployeeService.Model.DTOs.Commands
{
    public record EmployeeUpdateDto(int EmployeeId, int DepartmentId, 
        int FunctionId, string PostTitle, string FirstName, string LastName,
        DateTime BirthDate, DateTime EmploymentDate, decimal Salary);
}
