using Git_MVC_PRO.Models;
using Git_MVC_PRO.Repogitory;

namespace Git_MVC_PRO.Service
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployees _Employees;

        public EmployeesService(IEmployees employees) 
        {
            _Employees=employees;
        
        }
        public async Task<IEnumerable<Employees>> GetAll()
        {
            return await _Employees.GetEmployees(); 
        }

        public async Task<Employees> GetByID(int id)
        {
            return await _Employees.GetIDByEmployees(id);
        }

        public async Task<IEnumerable<Departments>> GetDepartment()
        {
            return await _Employees.GetDepartments();
            
        }

        public async Task<Employees> Post(Employees employees)
        {
           return await _Employees.CreateEmployees(employees);
        }
    }
}
