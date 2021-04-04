namespace UoW.Students.Martell.Web.Installers
{
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    public class MediatRServiceInstaller : IServiceInstaller
    {
        public InstallationOrder Order => InstallationOrder.Mediator;
        public void Install(IServiceCollection services, IConfiguration configuration, string environment)
        {
            services.AddMediatR(typeof(Startup));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(IdentityBehavior<,>));
        }
    }
}
