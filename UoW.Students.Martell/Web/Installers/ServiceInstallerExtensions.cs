namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using UoW.Students.Martell.Application.Common.Brokers;

    [ExcludeFromCodeCoverage]
    public static class ServiceInstallerExtensions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var serviceInstallers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IServiceInstaller).IsAssignableFrom(x)
                    && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>()
                .OrderBy(x => (int)x.Order)
                .ToList();

            serviceInstallers.ForEach(installer =>
            {
                installer.Install(services, configuration, environment.EnvironmentName);
            });
        }
    }
}
