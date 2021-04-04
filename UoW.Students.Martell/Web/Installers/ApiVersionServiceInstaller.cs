namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    [ExcludeFromCodeCoverage]
    public class ApiVersionServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.ApiVersion;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 0);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;
                cfg.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            });
        }
    }
}
