namespace UoW.Database.Robert
{
    using Microsoft.EntityFrameworkCore;
    using UoW.Database.Robert.Entities;

    public class WesterosContext : DbContext 
    {
        public WesterosContext(DbContextOptions<WesterosContext> options) : base(options)
        { }

        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
