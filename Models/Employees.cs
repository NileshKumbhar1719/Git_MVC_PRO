using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git_MVC_PRO.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Column("First_name")]
        public string name { get; set; }

        [Column("Last_Name")]
        public string lastname { get; set; }

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int age { get; set; }

        public string email { get; set; }

        [Range(0, 1000000, ErrorMessage = "Salary must be a positive value")]
        public decimal salary { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentsId { get; set; }

        [ForeignKey("DepartmentsId")]

        public Departments departments { get; set; }
    }
}