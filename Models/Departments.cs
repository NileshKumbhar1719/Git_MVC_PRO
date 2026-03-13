using System.ComponentModel.DataAnnotations;

namespace Git_MVC_PRO.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentsId { get; set; }
        public string Name { get;set; }

        public string Description { get;set;}

        public List<Employees> Employees { get; set; }
    }
}
