namespace UoW.Students.Martell.Infrastructure.Persistence
{
    using Autofac;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using System;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Common.Settings;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var options = c.Resolve<IOptions<DbConnectionSettings>>();
                var dbConnectionSettings = options.Value;
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<WesterosStudentDbContext>()
                    .UseSqlServer(dbConnectionSettings.Westeros, opt =>
                    {
                        opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                        opt.EnableRetryOnFailure(10);
                    });

                return new WesterosStudentDbContext(dbContextOptionsBuilder.Options);
            }).As<IWesterosStudentDbContext>().InstancePerDependency().ExternallyOwned();

            builder.RegisterType<WesterosStudentDbContextFactory>().As<IWesterosStudentDbContextFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
