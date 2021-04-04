namespace UoW.Students.Martell.Application.Students.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class GetStudentQuery : IRequest<StudentAggregateDto>
    {
        public int StudentId { get; set; }
        public ODataQueryOptions<StudentAggregateDto> QueryOptions { get; set; }
    }
}
