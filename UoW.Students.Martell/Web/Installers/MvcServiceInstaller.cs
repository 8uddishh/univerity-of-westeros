namespace UoW.Students.Martell.Web.Installers
{
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    [ExcludeFromCodeCoverage]
    public class MvcServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.Mvc;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddControllers()
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
        }
    }
}
