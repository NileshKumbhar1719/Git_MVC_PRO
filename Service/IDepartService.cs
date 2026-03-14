using Git_MVC_PRO.Models;

namespace Git_MVC_PRO.Service
{
    public interface IDepartService
    {

        Task<IEnumerable<Departments>> GetDepartmentsService();

        Task<Departments> AddDepartmentsService(Departments departments);

        Task<Departments> UpdateDepartmentsService(Departments updatedDepartments);

        Task<bool> DeleteDepartmentsService( int Id );

        Task<Departments> GetBYId( int Id );
    }
}
