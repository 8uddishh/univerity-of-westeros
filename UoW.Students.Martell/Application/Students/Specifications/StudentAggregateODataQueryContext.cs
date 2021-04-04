namespace UoW.Students.Martell.Application.Students.Specifications
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using UoW.OData.Knight;
    using UoW.Students.Martell.Application.Students.Queries;

    public class StudentAggregateODataQueryContext : BaseODataQueryContext<StudentAggregateDto>
    {
        private readonly IMediator _mediator;

        public StudentAggregateODataQueryContext(IHttpContextAccessor httpContextAccessor, IMediator mediator)
            : base(httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override string Name => "aggregates/students";

        public override async Task<long> CountAsync()
        {
            return await _mediator.Send(new CountStudentsQuery
            {
                QueryOptions = SpawnOdataQueryOptions()
            });
        }
    }
}
