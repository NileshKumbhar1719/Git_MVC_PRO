using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git_MVC_PRO.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("First_name")]
        public string name { get; set; }

        [Required]
        [Column("Last_Name")]
        public string lastname { get; set; }

        public int age { get; set; }

        [Required]
        [MaxLength(50)]
        public string email { get; set; }

        public decimal salary { get; set; }

        [ForeignKey("DepartmentsId")]

        public Departments departments { get; set; }
    }
}
