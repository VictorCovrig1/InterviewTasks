namespace EmployeeService.Model.DTOs.Commands
{
    public record EmployeeCreateDto(int DepartmentId, int FunctionId, 
        string PostTitle, string FirstName, string LastName, 
        DateTime BirthDate, DateTime EmploymentDate, decimal Salary);
}
