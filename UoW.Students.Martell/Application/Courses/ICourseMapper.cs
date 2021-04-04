namespace UoW.Students.Martell.Application.Courses
{
    using Mapster;
    using UoW.Students.Martell.Domain.Entities;

    [Mapper]
    public interface ICourseMapper
    {
        CourseAggregateDto MapToAggr(Course course);
        CourseDto MapToBase(Course course);
        Course MapToPoco(CourseDto courseDto);
        Course MapToExistingPoco(CourseDto courseDto, Course course);
    }
}
