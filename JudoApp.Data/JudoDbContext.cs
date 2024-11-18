namespace JudoApp.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    public class JudoDbContext : IdentityDbContext
    {
        public JudoDbContext()
        {
            
        }

        public JudoDbContext(DbContextOptions options)
        : base(options)
        {

        }

        private virtual DbSet<Club>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
