namespace UoW.Students.Martell.Application.StudentStatusTypes
{
    using Autofac;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.StudentStatusTypes.Specifications;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentStatusTypeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentStatusTypeAggregateOdataFilterMapper>()
               .As<IOdataFilterMapper<StudentStatusTypeAggregateDto, StudentStatusType>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<StudentStatusTypeAggregateOdataNavigator>()
                .As<IOdataNavigator<StudentStatusTypeAggregateDto, StudentStatusType>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentStatusTypeAggregateODataQueryContext>().Named<IODataQueryContext>("aggregates/student-status-types")
                .InstancePerLifetimeScope();
        }
    }
}
