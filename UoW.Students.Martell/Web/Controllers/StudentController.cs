namespace UoW.Students.Martell.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Application.Students;
    using UoW.Students.Martell.Application.Students.Queries;
    using UoW.Students.Martell.Web.Specifications;

    [Route("odata/aggregates/students")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        [RestrictedEnableQuery()]
        public async Task<IEnumerable<StudentAggregateDto>> SearchCoursesAsync(ODataQueryOptions<StudentAggregateDto> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new SearchStudentsQuery
            {
                QueryOptions = queryOptions
            }, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{student_id}")]
        [RestrictedEnableQuery()]
        public async Task<StudentAggregateDto> GetCourseAsync([FromRoute(Name = "student_id")] int studentId,
            ODataQueryOptions<StudentAggregateDto> queryOptions, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetStudentQuery
            {
                QueryOptions = queryOptions,
                StudentId = studentId
            }, cancellationToken).ConfigureAwait(false);
        }
    }
}
