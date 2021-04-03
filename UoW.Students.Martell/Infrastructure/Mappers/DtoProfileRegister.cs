namespace UoW.Students.Martell.Infrastructure.Mappers
{
    using Mapster;
    using System;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Domains.Entities;

    public class DtoProfileRegister : IMapperRegister
    {
        private readonly ICourseMapper _courseMapper;

        public DtoProfileRegister(ICourseMapper courseMapper)
        {
            _courseMapper = courseMapper ?? throw new ArgumentNullException(nameof(courseMapper));
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseAggregateDto>()
                .MapWith(x => _courseMapper.MapToAggr(x));
        }
    }
}
