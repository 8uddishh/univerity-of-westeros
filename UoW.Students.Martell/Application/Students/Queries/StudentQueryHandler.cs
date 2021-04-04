namespace UoW.Students.Martell.Application.Students.Queries
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

    public class StudentQueryHandler : IRequestHandler<SearchStudentsQuery, IEnumerable<StudentAggregateDto>>,
        IRequestHandler<GetStudentQuery, StudentAggregateDto>,
        IRequestHandler<CountStudentsQuery, long>
    {
        private readonly IOdataFilterMapper<StudentAggregateDto, Student> _filterMapper;
        private readonly IOdataNavigator<StudentAggregateDto, Student> _odataProjector;
        private readonly IMapper _mapper;
        private readonly IWesterosStudentDbContextFactory _westerosStudentDbContextFactory;

        public StudentQueryHandler(IOdataFilterMapper<StudentAggregateDto, Student> filterMapper,
            IOdataNavigator<StudentAggregateDto, Student> odataProjector,
            IMapper mapper, IWesterosStudentDbContextFactory westerosStudentDbContextFactory)
        {
            _filterMapper = filterMapper ?? throw new ArgumentNullException(nameof(filterMapper));
            _odataProjector = odataProjector ?? throw new ArgumentNullException(nameof(odataProjector));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _westerosStudentDbContextFactory = westerosStudentDbContextFactory ?? throw new ArgumentNullException(nameof(westerosStudentDbContextFactory));
        }

        public async Task<IEnumerable<StudentAggregateDto>> Handle(SearchStudentsQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Students.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);
            if (filter != null)
                queryable = queryable.Where(filter);
            if (request.QueryOptions.Skip != null)
                queryable = queryable.Skip(request.QueryOptions.Skip.Value);
            if (request.QueryOptions.Top != null)
                queryable = queryable.Take(request.QueryOptions.Top.Value);

            var students = await queryable.ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<StudentAggregateDto>>(students);
        }

        public async Task<StudentAggregateDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Students.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);

            var student = await queryable.FirstOrDefaultAsync(x => x.Id == request.StudentId, cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<StudentAggregateDto>(student);
        }

        public async Task<long> Handle(CountStudentsQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;

            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.Students.AsQueryable();
            if (filter != null)
                queryable = queryable.Where(filter);

            return await queryable.LongCountAsync()
                .ConfigureAwait(false);
        }
    }
}
