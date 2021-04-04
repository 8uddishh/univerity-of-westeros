namespace UoW.Students.Martell.Application.Students.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using System.Collections.Generic;

    public class SearchStudentsQuery : IRequest<IEnumerable<StudentAggregateDto>>
    {
        public ODataQueryOptions<StudentAggregateDto> QueryOptions { get; set; }
    }
}
