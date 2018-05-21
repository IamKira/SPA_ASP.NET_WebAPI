using Microsoft.EntityFrameworkCore;
using WebApi1.Models;
using WebApi1.Configuration;

namespace WebApi1
{
    public class Db1Context : DbContext
    {
        public Db1Context(DbContextOptions<Db1Context> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
