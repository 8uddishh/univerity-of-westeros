namespace UoW.Students.Martell.Application.StudentCourses.Queries
{
    using MapsterMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentCourseQueryHandler : IRequestHandler<SearchStudentCoursesQuery, IEnumerable<StudentCourseAggregateDto>>,
        IRequestHandler<GetStudentCourseQuery, StudentCourseAggregateDto>,
        IRequestHandler<CountStudentCoursesQuery, long>
    {
        private readonly IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> _filterMapper;
        private readonly IOdataNavigator<StudentCourseAggregateDto, StudentCourse> _odataProjector;
        private readonly IMapper _mapper;
        private readonly IWesterosStudentDbContextFactory _westerosStudentDbContextFactory;

        public StudentCourseQueryHandler(IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> filterMapper,
            IOdataNavigator<StudentCourseAggregateDto, StudentCourse> odataProjector,
            IMapper mapper, IWesterosStudentDbContextFactory westerosStudentDbContextFactory)
        {
            _filterMapper = filterMapper ?? throw new ArgumentNullException(nameof(filterMapper));
            _odataProjector = odataProjector ?? throw new ArgumentNullException(nameof(odataProjector));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _westerosStudentDbContextFactory = westerosStudentDbContextFactory ?? throw new ArgumentNullException(nameof(westerosStudentDbContextFactory));
        }

        public async Task<IEnumerable<StudentCourseAggregateDto>> Handle(SearchStudentCoursesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentCourses.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);
            if (filter != null)
                queryable = queryable.Where(filter);
            if (request.QueryOptions.Skip != null)
                queryable = queryable.Skip(request.QueryOptions.Skip.Value);
            if (request.QueryOptions.Top != null)
                queryable = queryable.Take(request.QueryOptions.Top.Value);

            var studentCourses = await queryable.ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<StudentCourseAggregateDto>>(studentCourses);
        }

        public async Task<StudentCourseAggregateDto> Handle(GetStudentCourseQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentCourses.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);

            var student = await queryable.FirstOrDefaultAsync(x => x.Id == request.StudentCourseId, cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<StudentCourseAggregateDto>(student);
        }

        public async Task<long> Handle(CountStudentCoursesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;

            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentCourses.AsQueryable();
            if (filter != null)
                queryable = queryable.Where(filter);

            return await queryable.LongCountAsync()
                .ConfigureAwait(false);
        }
    }
}
