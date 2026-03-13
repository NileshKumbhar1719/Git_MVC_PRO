using System.ComponentModel.DataAnnotations;

namespace Git_MVC_PRO.Models
{
    public class Departments
    {
        public int DepartmentsId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get;set; }

        public string Description { get;set;}
    }
}
