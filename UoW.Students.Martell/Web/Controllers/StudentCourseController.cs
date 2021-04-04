namespace UoW.Students.Martell.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Application.StudentCourses.Queries;
    using UoW.Students.Martell.Web.Specifications;

    [Route("odata/aggregates/student-courses")]
    public class StudentCourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentCourseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        [RestrictedEnableQuery()]
        public async Task<IEnumerable<StudentCourseAggregateDto>> SearchCoursesAsync(ODataQueryOptions<StudentCourseAggregateDto> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new SearchStudentCoursesQuery
            {
                QueryOptions = queryOptions
            }, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{student_course_id}")]
        [RestrictedEnableQuery()]
        public async Task<StudentCourseAggregateDto> GetCourseAsync([FromRoute(Name = "student_course_id")] int studentCourseId,
            ODataQueryOptions<StudentCourseAggregateDto> queryOptions, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetStudentCourseQuery
            {
                QueryOptions = queryOptions,
                StudentCourseId = studentCourseId
            }, cancellationToken).ConfigureAwait(false);
        }
    }
}
