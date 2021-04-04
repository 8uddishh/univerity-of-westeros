namespace UoW.Students.Martell.Application
{
    using Autofac;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Application.Students;
    using UoW.Students.Martell.Application.StudentStatusTypes;

    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<StudentModule>();
            builder.RegisterModule<CourseModule>();
            builder.RegisterModule<StudentCourseModule>();
            builder.RegisterModule<StudentStatusTypeModule>();
        }
    }
}
