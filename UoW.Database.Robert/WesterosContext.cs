namespace UoW.Database.Robert
{
    using Microsoft.EntityFrameworkCore;
    using UoW.Database.Robert.Entities;
    using UoW.Database.Robert.Entities.Specifications;

    public class WesterosContext : DbContext 
    {
        public WesterosContext(DbContextOptions<WesterosContext> options) : base(options)
        { }

        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>(b => b.Configure());
            modelBuilder.Entity<Semester>(b => b.Configure());
        }
    }
}
