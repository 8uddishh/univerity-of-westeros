namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Autofac;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public interface IAutofacPackage
    {
        void Register(ContainerBuilder container, IWebHostEnvironment env, IConfiguration config);
    }
}
