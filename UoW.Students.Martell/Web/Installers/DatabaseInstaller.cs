namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;
    using UoW.Students.Martell.Infrastructure.Persistence;

    [ExcludeFromCodeCoverage]
    public class DatabaseInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.DatabaseContext;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddDbContext<WesterosStudentDbContext>(options => options.UseSqlServer(configuration["DbConnectionSettings:Westros-Robert"]));
        }
    }
}
