namespace UoW.Students.Martell.Application.StudentStatusTypes.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class CountStudentStatusTypesQuery : IRequest<long>
    {
        public ODataQueryOptions<StudentStatusTypeAggregateDto> QueryOptions { get; set; }
    }
}
