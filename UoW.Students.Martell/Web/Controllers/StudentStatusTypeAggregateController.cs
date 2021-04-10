﻿namespace UoW.Students.Martell.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using UoW.Students.Martell.Application.StudentStatusTypes;
    using UoW.Students.Martell.Application.StudentStatusTypes.Queries;
    using UoW.Students.Martell.Web.Specifications;

    [Route("odata/aggregates/student-status-types")]
    public class StudentStatusTypeAggregateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentStatusTypeAggregateController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("")]
        [RestrictedEnableQuery()]
        public async Task<IEnumerable<StudentStatusTypeAggregateDto>> SearchCoursesAsync(ODataQueryOptions<StudentStatusTypeAggregateDto> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new PluckStudentStatusTypesQuery
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
            return await _mediator.Send(new PickStudentStatusTypeQuery
            {
                QueryOptions = queryOptions,
                StudentStatusTypeId = studentStatusId
            }, cancellationToken).ConfigureAwait(false);
        }
    }
}
