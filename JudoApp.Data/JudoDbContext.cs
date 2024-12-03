namespace JudoApp.Web.Data
{
    using JudoApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    public class JudoDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public JudoDbContext()
        {
            
        }

        public JudoDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;

        public virtual DbSet<Judge> Judges { get; set; } = null!;

        public virtual DbSet<Article> Articles { get; set; } = null!;

        public virtual DbSet<Manager> Managers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
