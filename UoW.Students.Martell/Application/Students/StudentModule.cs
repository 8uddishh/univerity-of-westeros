namespace UoW.Students.Martell.Application.Students
{
    using Autofac;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.Students.Specifications;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentAggregateOdataFilterMapper>()
               .As<IOdataFilterMapper<StudentAggregateDto, Student>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<StudentAggregateOdataNavigator>()
                .As<IOdataNavigator<StudentAggregateDto, Student>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentAggregateODataQueryContext>().Named<IODataQueryContext>("aggregates/students")
                .InstancePerLifetimeScope();
        }
    }
}
