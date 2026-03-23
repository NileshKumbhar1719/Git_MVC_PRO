using Git_MVC_PRO.Models;
using System.Collections;

namespace Git_MVC_PRO.Repogitory
{
    public interface IEmployees
    {

        

        Task<IEnumerable<Employees>> GetEmployees();

        Task<Employees> GetIDByEmployees(int id);

        Task<Employees> CreateEmployees(Employees employees);

        Task<IEnumerable<Departments>> GetDepartments();

        Task<Employees>Edit(Employees employees);

        Task<bool> DeleteEmployees(int id);



    }
}
