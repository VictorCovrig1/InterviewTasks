namespace EmployeeService.Model.DTOs.Queries
{
    public record PaginatedEmployeesDto
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<EmployeeQueryDto> Employees { get; private set; } = new List<EmployeeQueryDto>();

        public PaginatedEmployeesDto(List<EmployeeQueryDto> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Employees.AddRange(items);
        }
    }
}
