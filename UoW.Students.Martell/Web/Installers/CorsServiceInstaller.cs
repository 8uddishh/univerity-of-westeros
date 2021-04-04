namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    [ExcludeFromCodeCoverage]
    public class CorsServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.Cors;

        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                     .AllowAnyHeader()));
        }
    }
}
