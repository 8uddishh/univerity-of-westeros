namespace UoW.Students.Martell.Web.Packages
{
    using Autofac;
    using Microsoft.Extensions.Configuration;
    using UoW.Students.Martell.Application;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Infrastructure;

    public class ApiPackage : IAutofacPackage
    {
        public void Register(ContainerBuilder builder, IConfiguration configuration, string environment)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
        }
    }
}
