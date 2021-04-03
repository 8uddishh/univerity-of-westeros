namespace UoW.Students.Martell.Application.Students
{
    using Mapster;
    using UoW.Students.Martell.Domains.Entities;

    [Mapper]
    public interface IStudentMapper
    {
        StudentAggregateDto MapToAggr(Student student);
        StudentDto MapToBase(Student student);
        Student MapToPoco(StudentDto studentDto);
        Student MapToExistingPoco(StudentDto studentDto, Student student);
    }
}
