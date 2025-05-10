namespace EmployeeService.Model
{
    public class QueryParams
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int SafePageSize => (PageSize > Constants.MaxPageSize) 
            ? Constants.MaxPageSize 
            : PageSize;

        public string SortOrder {  get; set; }
        public string FilterKey { get; set; }
    }
}
