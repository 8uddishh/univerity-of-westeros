namespace UoW.Students.Martell.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Application.Courses.Queries;
    using UoW.Students.Martell.Web.Specifications;

    [Route("odata/aggregates/courses")]
    public class CourseAggregateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseAggregateController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        [RestrictedEnableQuery()]
        public async Task<IEnumerable<CourseAggregateDto>> SearchCoursesAsync(ODataQueryOptions<CourseAggregateDto> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new SearchCoursesQuery
            {
                QueryOptions = queryOptions
            }, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{course_id}")]
        [RestrictedEnableQuery()]
        public async Task<CourseAggregateDto> GetCourseAsync([FromRoute(Name = "course_id")] int courseId,
            ODataQueryOptions<CourseAggregateDto> queryOptions, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetCourseQuery
            {
                QueryOptions = queryOptions,
                CourseId = courseId
            }, cancellationToken).ConfigureAwait(false);
        }
    }
}
