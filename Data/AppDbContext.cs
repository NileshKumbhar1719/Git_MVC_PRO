using Git_MVC_PRO.Models;
using Microsoft.EntityFrameworkCore;

namespace Git_MVC_PRO.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {
        
        }

      public  DbSet<Departments> Departments { get; set; }

       public DbSet<Employees> Employees { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }


        
    }
}
