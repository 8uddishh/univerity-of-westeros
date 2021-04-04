namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Common.Settings;
    using UoW.Students.Martell.Domains.Enums;

    [ExcludeFromCodeCoverage]
    public class OptionsServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.Options;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddOptions();
            services.Configure<DbConnectionSettings>(configuration.GetSection(nameof(DbConnectionSettings)));
        }
    }
}
