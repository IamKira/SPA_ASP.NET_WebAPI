using Microsoft.EntityFrameworkCore;
using WebApi2.Models;
using WebApi2.Configuration;

namespace WebApi2
{
    public class Db2Context : DbContext
    {
        public Db2Context(DbContextOptions<Db2Context> options)
            : base(options)
        { }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
        }
    }
}
