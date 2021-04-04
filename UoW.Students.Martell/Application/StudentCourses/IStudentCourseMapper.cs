namespace UoW.Students.Martell.Application.StudentCourses
{
    using Mapster;
    using UoW.Students.Martell.Domain.Entities;

    [Mapper]
    public interface IStudentCourseMapper
    {
        StudentCourseAggregateDto MapToAggr(StudentCourse studentCourse);
        StudentCourseDto MapToBase(StudentCourse studentCourse);
        StudentCourse MapToPoco(StudentCourseDto studentCourseDto);
        StudentCourse MapToExistingPoco(StudentCourseDto studentCourseDto, StudentCourse studentCourse);
    }
}
