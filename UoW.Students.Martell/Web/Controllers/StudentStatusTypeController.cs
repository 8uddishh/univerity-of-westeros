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
    using UoW.Students.Martell.Application.StudentStatusTypes;
    using UoW.Students.Martell.Application.StudentStatusTypes.Queries;
    using UoW.Students.Martell.Web.Specifications;

    [Route("odata/aggregates/student-status-types")]
    public class StudentStatusTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentStatusTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        [RestrictedEnableQuery()]
        public async Task<IEnumerable<StudentStatusTypeAggregateDto>> SearchCoursesAsync(ODataQueryOptions<StudentStatusTypeAggregateDto> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new SearchStudentStatusTypesQuery
            {
                QueryOptions = queryOptions
            }, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{student_status_type_id}")]
        [RestrictedEnableQuery()]
        public async Task<StudentStatusTypeAggregateDto> GetCourseAsync([FromRoute(Name = "student_status_type_id")] int studentStatusId,
            ODataQueryOptions<StudentStatusTypeAggregateDto> queryOptions, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetStudentStatusTypeQuery
            {
                QueryOptions = queryOptions,
                StudentStatusTypeId = studentStatusId
            }, cancellationToken).ConfigureAwait(false);
        }
    }
}
