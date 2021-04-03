namespace UoW.Students.Martell.Application.StudentStatusTypes
{
    using Mapster;
    using UoW.Students.Martell.Domains.Entities;

    [Mapper]
    public interface IStudentStatusTypeMapper
    {
        StudentStatusTypeAggregateDto MapToAggr(StudentStatusType studentStatusType);
        StudentStatusTypeDto MapToBase(StudentStatusType studentStatusType);
        StudentStatusType MapToPoco(StudentStatusTypeDto studentStatusTypeDto);
        StudentStatusType MapToExistingPoco(StudentStatusTypeDto studentDto, StudentStatusType studentStatusType);
    }
}
