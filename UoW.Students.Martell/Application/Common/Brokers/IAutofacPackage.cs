namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Autofac;
    using Microsoft.Extensions.Configuration;

    public interface IAutofacPackage
    {
        void Register(ContainerBuilder builder, IConfiguration configuration, string environment);
    }
}
