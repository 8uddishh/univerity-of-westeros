namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using UoW.Students.Martell.Domains.Enums;

    public interface IServiceInstaller
    {
        InstallationOrder Order { get; }
        void Install(IServiceCollection services, IConfiguration config, string env);
    }
}
