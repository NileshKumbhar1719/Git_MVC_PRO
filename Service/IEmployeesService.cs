using Git_MVC_PRO.Models;

namespace Git_MVC_PRO.Service
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employees>> GetAll();

        Task<Employees> Post(Employees employees);

        Task<Employees> GetByID(int id);
        Task<IEnumerable<Departments>> GetDepartment();

        Task<bool> Delete(int id);
        Task<Employees> Edit(Employees employees);


    }
}
