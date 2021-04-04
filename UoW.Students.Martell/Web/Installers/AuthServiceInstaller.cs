namespace UoW.Students.Martell.Web.Installers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    [ExcludeFromCodeCoverage]
    public class AuthServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.Authorization;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddHttpContextAccessor();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer();

            // Custom authorization here
        }
    }
}
