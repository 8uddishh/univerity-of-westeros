namespace UoW.Students.Martell.Application.StudentCourses
{
    using Autofac;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.StudentCourses.Specifications;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentCourseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentCourseAggregateOdataFilterMapper>()
               .As<IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse>>()
               .InstancePerLifetimeScope();

            builder.RegisterType<StudentCourseAggregateOdataNavigator>()
                .As<IOdataNavigator<StudentCourseAggregateDto, StudentCourse>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentCourseAggregateODataQueryContext>().Named<IODataQueryContext>("aggregates/student-courses")
                .InstancePerLifetimeScope();
        }
    }
}
