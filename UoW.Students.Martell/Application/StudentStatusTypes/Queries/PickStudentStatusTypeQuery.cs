namespace UoW.Students.Martell.Application.StudentStatusTypes.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class PickStudentStatusTypeQuery : IRequest<StudentStatusTypeAggregateDto>
    {
        public int StudentStatusTypeId { get; set; }
        public ODataQueryOptions<StudentStatusTypeAggregateDto> QueryOptions { get; set; }
    }
}
