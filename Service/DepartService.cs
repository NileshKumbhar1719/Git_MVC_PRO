using Git_MVC_PRO.Models;
using Git_MVC_PRO.Repogitory;
using System.Runtime.CompilerServices;

namespace Git_MVC_PRO.Service
{
    public class DepartService : IDepartService
    {
        private readonly IDepartments _Depart;

        public DepartService(IDepartments departments) 
        { 
          _Depart= departments;
        }
        public async Task<Departments> AddDepartmentsService(Departments departments)
        {
            return await _Depart.AddDepart(departments);
        }

        public async Task<bool> DeleteDepartmentsService(int id)
        {
            return await _Depart.DeleteDepart(id); 
        }

        public  async Task<Departments> GetBYId(int Id)
        {
            return await _Depart.GetbyIDDepart(Id);

        }

        public async Task<IEnumerable<Departments>> GetDepartmentsService()
        {
            return await _Depart.GetDepart();
            
        }

        public async Task<Departments> UpdateDepartmentsService(Departments updatedDepartments)
        {
            return await _Depart.UpdateDepart(updatedDepartments);
        }
    }
}
