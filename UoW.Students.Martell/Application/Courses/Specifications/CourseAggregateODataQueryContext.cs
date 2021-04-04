namespace UoW.Students.Martell.Application.Courses.Specifications
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using UoW.OData.Knight;
    using UoW.Students.Martell.Application.Courses.Queries;

    public class CourseAggregateODataQueryContext : BaseODataQueryContext<CourseAggregateDto>
    {
        private readonly IMediator _mediator;

        public CourseAggregateODataQueryContext(IHttpContextAccessor httpContextAccessor, IMediator mediator)
            : base(httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override string Name => "aggregates/courses";

        public override async Task<long> CountAsync()
        {
            return await _mediator.Send(new CountCoursesQuery
            {
                QueryOptions = SpawnOdataQueryOptions()
            });
        }
    }
}
