using ASP.NETCoreMVCByLaxmiBhattarai.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreMVCByLaxmiBhattarai.DAO
{
    public class MyAppDBContext : IdentityDbContext
    {
		public DbSet<Student> Students { get; set; }
		public MyAppDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
