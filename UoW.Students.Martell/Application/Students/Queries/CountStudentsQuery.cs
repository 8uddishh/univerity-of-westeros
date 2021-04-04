namespace UoW.Students.Martell.Application.Students.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class CountStudentsQuery : IRequest<long>
    {
        public ODataQueryOptions<StudentAggregateDto> QueryOptions { get; set; }
    }
}
