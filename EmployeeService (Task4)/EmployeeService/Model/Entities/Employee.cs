using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Model.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int FunctionId { get; set; }

        [Required]
        [StringLength(500)]
        public string PostTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Salary { get; set; }
    }
}
