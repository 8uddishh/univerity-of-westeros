namespace UoW.Students.Martell.Application.StudentCourses.Specifications
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using UoW.OData.Knight;
    using UoW.Students.Martell.Application.StudentCourses.Queries;

    public class StudentCourseAggregateODataQueryContext : BaseODataQueryContext<StudentCourseAggregateDto>
    {
        private readonly IMediator _mediator;

        public StudentCourseAggregateODataQueryContext(IHttpContextAccessor httpContextAccessor, IMediator mediator)
            : base(httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override string Name => "aggregates/student-courses";

        public override async Task<long> CountAsync()
        {
            return await _mediator.Send(new CountStudentCoursesQuery
            {
                QueryOptions = SpawnOdataQueryOptions()
            });
        }
    }
}
