
using Git_MVC_PRO.Data;
using Git_MVC_PRO.Models;
using Microsoft.EntityFrameworkCore;

namespace Git_MVC_PRO.Repogitory
{
    public class Employee : IEmployees
    {
        private readonly AppDbContext _context;

        public Employee(AppDbContext context) 
        { 
        _context=context;
        }
        public async Task<Employees> CreateEmployees(Employees employees)
        {
             _context.Employees.Add(employees);
            await _context.SaveChangesAsync();
            return employees;
        }

        public async Task<IEnumerable<Departments>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees> GetIDByEmployees(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}
