namespace UoW.Students.Martell.Infrastructure.Mappers
{
    using Autofac;
    using Mapster;
    using MapsterMapper;
    using System.Diagnostics.CodeAnalysis;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Application.Students;
    using UoW.Students.Martell.Application.StudentStatusTypes;

    [ExcludeFromCodeCoverage]
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseMapper>().As<ICourseMapper>()
                .SingleInstance();
            builder.RegisterType<StudentCourseMapper>().As<IStudentCourseMapper>()
                .SingleInstance();
            builder.RegisterType<StudentMapper>().As<IStudentMapper>()
                .SingleInstance();
            builder.RegisterType<StudentStatusTypeMapper>().As<IStudentStatusTypeMapper>()
                .SingleInstance();

            builder.RegisterType<DtoProfileRegister>().Named<IMapperRegister>("dto")
                .SingleInstance();

            builder.Register(ctx =>
            {
                var config = new TypeAdapterConfig();
                var dtoRegister = ctx.ResolveNamed<IMapperRegister>("dto");
                dtoRegister.Register(config);
                return config;
            }).SingleInstance();

            builder.RegisterType<ServiceMapper>().As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
