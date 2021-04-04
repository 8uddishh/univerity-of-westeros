namespace UoW.Students.Martell.Application.StudentStatusTypes.Specifications
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using UoW.OData.Knight;
    using UoW.Students.Martell.Application.StudentStatusTypes.Queries;

    public class StudentStatusTypeAggregateODataQueryContext : BaseODataQueryContext<StudentStatusTypeAggregateDto>
    {
        private readonly IMediator _mediator;

        public StudentStatusTypeAggregateODataQueryContext(IHttpContextAccessor httpContextAccessor, IMediator mediator)
            : base(httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override string Name => "aggregates/student-status-types";

        public override async Task<long> CountAsync()
        {
            return await _mediator.Send(new CountStudentStatusTypesQuery
            {
                QueryOptions = SpawnOdataQueryOptions()
            });
        }
    }
}
