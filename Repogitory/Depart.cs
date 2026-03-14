using Git_MVC_PRO.Data;
using Git_MVC_PRO.Models;
using Microsoft.EntityFrameworkCore;

namespace Git_MVC_PRO.Repogitory
{
    public class Depart : IDepartments
    {
        private readonly AppDbContext _app;

        public Depart(AppDbContext appDbContext) 
        { 
         _app=appDbContext;
        
        }
        public async Task<Departments> AddDepart(Departments departments)
        {
             _app.Departments.AddAsync(departments);
             await _app.SaveChangesAsync();
            return departments;
        }

        public async Task<bool> DeleteDepart(int id)
        {
            var depart = await _app.Departments.FindAsync(id);
            if (depart == null)
            {
                return false; 
            }

            _app.Departments.Remove(depart);
            await _app.SaveChangesAsync();
            return true; 
        }
        public async Task<Departments> GetbyIDDepart(int id)
        {
            return await _app.Departments.FindAsync(id);
        }

        public  async Task<IEnumerable<Departments>> GetDepart()
        {
            return await _app.Departments.ToListAsync();
        }

        public async Task<Departments> UpdateDepart(Departments departments)
        {
            _app.Departments.Update(departments);
            await _app.SaveChangesAsync();
            return departments;
        }
    }
}
