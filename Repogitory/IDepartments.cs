using Git_MVC_PRO.Models;

namespace Git_MVC_PRO.Repogitory
{
    public interface IDepartments
    {

        Task<IEnumerable<Departments>> GetDepart();

        Task<Departments> GetbyIDDepart(int id);

        Task<Departments> AddDepart(Departments departments);

        Task<Departments> UpdateDepart(Departments departments);

        Task<bool> DeleteDepart(int id);








    }
}
