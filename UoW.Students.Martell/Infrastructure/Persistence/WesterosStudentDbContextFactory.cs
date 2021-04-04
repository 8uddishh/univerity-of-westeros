namespace UoW.Students.Martell.Infrastructure.Persistence
{
    using Autofac;
    using System;
    using UoW.Students.Martell.Application.Common.Brokers;

    public class WesterosStudentDbContextFactory : IWesterosStudentDbContextFactory
    {
        private readonly IComponentContext _context;

        public WesterosStudentDbContextFactory(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IWesterosStudentDbContext SpawnStudentDbContext()
        {
            return _context.Resolve<IWesterosStudentDbContext>();
        }
    }
}
