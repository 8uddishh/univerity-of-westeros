namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;
    using UoW.Students.Martell.Infrastructure.Persistence;

    [ExcludeFromCodeCoverage]
    public class HealthCheckServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.HealthCheck;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<WesterosStudentDbContext>(tags: new[] { "readiness" });
        }
    }
}
