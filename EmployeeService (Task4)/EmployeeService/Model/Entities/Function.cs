using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Model.Entities
{
    [Table("Functions")]
    public class Function
    {
        [Key]
        public int FunctionId { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionName { get; set; }
    }
}
