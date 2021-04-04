namespace UoW.Students.Martell.Infrastructure
{
    using Autofac;
    using UoW.Students.Martell.Infrastructure.Mappers;
    using UoW.Students.Martell.Infrastructure.Persistence;

    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterModule<MapperModule>();
        }
    }
}
