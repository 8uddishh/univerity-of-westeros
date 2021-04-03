namespace UoW.Students.Martell.Application.StudentStatusTypes
{
    using System.Collections.Generic;
    using UoW.OData.Knight.Attributes;

    [ODataEntityMapper("StudentStatusType")]
    public class StudentStatusTypeAggregateDto
    {
        public IList<StudentDto> Students { get; set; }
    }
}
