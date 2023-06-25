using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Database
{
    public class TestWorkDbContext: DbContext
    {
        public TestWorkDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Employee> Employee { get; set; }
        
    }
}
