using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git_MVC_PRO.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Column("First_name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [Column("Last_Name")]
        public string lastname { get; set; }

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        public string email { get; set; }

        [Range(0, 1000000, ErrorMessage = "Salary must be a positive value")]
        public decimal salary { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentsId { get; set; }

        [ForeignKey("DepartmentsId")]
        public Departments departments { get; set; }
    }
}