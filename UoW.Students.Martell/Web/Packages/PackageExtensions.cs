namespace UoW.Students.Martell.Web.Packages
{
    using Autofac;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using UoW.Students.Martell.Application.Common.Brokers;

    [ExcludeFromCodeCoverage]
    public static class PackageExtensions
    {
        public static void RegisterDependencies(this ContainerBuilder builder, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var packages = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IAutofacPackage).IsAssignableFrom(x)
                    && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IAutofacPackage>()
                .ToList();

            packages.ForEach(package =>
            {
                package.Register(builder, configuration, environment.EnvironmentName);
            });
        }

    }
}
