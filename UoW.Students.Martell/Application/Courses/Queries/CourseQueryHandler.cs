namespace UoW.Students.Martell.Application.Courses.Queries
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

    public class CourseQueryHandler : IRequestHandler<SearchCoursesQuery, IEnumerable<CourseAggregateDto>>,
        IRequestHandler<GetCourseQuery, CourseAggregateDto>,
        IRequestHandler<CountCoursesQuery, long>
    {
        private readonly IOdataFilterMapper<CourseAggregateDto, Course> _filterMapper;
        private readonly IOdataNavigator<CourseAggregateDto, Course> _odataProjector;
        private readonly IMapper _mapper;
        private readonly IWesterosStudentDbContextFactory _westerosStudentDbContextFactory;

        public CourseQueryHandler(IOdataFilterMapper<CourseAggregateDto, Course> filterMapper,
            IOdataNavigator<CourseAggregateDto, Course> odataProjector,
            IMapper mapper, IWesterosStudentDbContextFactory westerosStudentDbContextFactory)
        {
            _filterMapper = filterMapper ?? throw new ArgumentNullException(nameof(filterMapper));
            _odataProjector = odataProjector ?? throw new ArgumentNullException(nameof(odataProjector));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _westerosStudentDbContextFactory = westerosStudentDbContextFactory ?? throw new ArgumentNullException(nameof(westerosStudentDbContextFactory));
        }

        public async Task<IEnumerable<CourseAggregateDto>> Handle(SearchCoursesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Courses.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);
            if (filter != null)
                queryable = queryable.Where(filter);
            if (request.QueryOptions.Skip != null)
                queryable = queryable.Skip(request.QueryOptions.Skip.Value);
            if (request.QueryOptions.Top != null)
                queryable = queryable.Take(request.QueryOptions.Top.Value);

            var courses = await queryable.ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<CourseAggregateDto>>(courses);
        }

        public async Task<CourseAggregateDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Courses.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);

            var student = await queryable.FirstOrDefaultAsync(x => x.Id == request.CourseId, cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<CourseAggregateDto>(student);
        }

        public async Task<long> Handle(CountCoursesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;

            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Courses.AsQueryable();
            if (filter != null)
                queryable = queryable.Where(filter);

            return await queryable.LongCountAsync()
                .ConfigureAwait(false);
        }
    }
}
