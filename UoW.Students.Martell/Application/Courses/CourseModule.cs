namespace UoW.Students.Martell.Application.Courses
{
    using Autofac;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.Courses.Specifications;
    using UoW.Students.Martell.Domain.Entities;

    public class CourseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseAggregateOdataFilterMapper>()
               .As<IOdataFilterMapper<CourseAggregateDto, Course>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CourseAggregateOdataNavigator>()
                .As<IOdataNavigator<CourseAggregateDto, Course>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseAggregateODataQueryContext>().Named<IODataQueryContext>("aggregates/courses")
                .InstancePerLifetimeScope();
        }
    }
}
