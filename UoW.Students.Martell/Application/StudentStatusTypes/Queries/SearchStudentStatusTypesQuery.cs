﻿namespace UoW.Students.Martell.Application.StudentStatusTypes.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using System.Collections.Generic;

    public class SearchStudentStatusTypesQuery : IRequest<IEnumerable<StudentStatusTypeAggregateDto>>
    {
        public ODataQueryOptions<StudentStatusTypeAggregateDto> QueryOptions { get; set; }
    }
}
