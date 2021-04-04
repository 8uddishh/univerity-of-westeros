namespace UoW.Students.Martell.Infrastructure.Mappers
{
    using Mapster;
    using System;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Application.Students;
    using UoW.Students.Martell.Application.StudentStatusTypes;
    using UoW.Students.Martell.Domain.Entities;

    public class DtoProfileRegister : IMapperRegister
    {
        private readonly ICourseMapper _courseMapper;
        private readonly IStudentMapper _studentMapper;
        private readonly IStudentCourseMapper _studentCourseMapper;
        private readonly IStudentStatusTypeMapper _studentStatusTypeMapper;

        public DtoProfileRegister(ICourseMapper courseMapper, IStudentMapper studentMapper, 
            IStudentCourseMapper studentCourseMapper, IStudentStatusTypeMapper studentStatusTypeMapper)
        {
            _courseMapper = courseMapper ?? throw new ArgumentNullException(nameof(courseMapper));
            _studentMapper = studentMapper ?? throw new ArgumentNullException(nameof(studentMapper));
            _studentCourseMapper = studentCourseMapper ?? throw new ArgumentNullException(nameof(studentCourseMapper));
            _studentStatusTypeMapper = studentStatusTypeMapper ?? throw new ArgumentNullException(nameof(studentStatusTypeMapper));
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseAggregateDto>()
                .MapWith(x => _courseMapper.MapToAggr(x));

            config.NewConfig<Student, StudentAggregateDto>()
                .MapWith(x => _studentMapper.MapToAggr(x));

            config.NewConfig<StudentCourse, StudentCourseAggregateDto>()
                .MapWith(x => _studentCourseMapper.MapToAggr(x));

            config.NewConfig<StudentStatusType, StudentStatusTypeAggregateDto>()
                .MapWith(x => _studentStatusTypeMapper.MapToAggr(x));
        }
    }
}
