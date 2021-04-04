namespace UoW.Students.Martell
{
    using Autofac;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using UoW.Students.Martell.Web.Installers;
    using UoW.Students.Martell.Web.Packages;
    using UoW.Students.Martell.Web.Pipelines;

    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _environment = environment ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServices(_configuration, _environment);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterDependencies(_configuration, _environment);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ChainPipelines(_configuration, _environment);
        }
    }
}
