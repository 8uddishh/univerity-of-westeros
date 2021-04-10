namespace UoW.Students.Martell.Application.StudentStatusTypes.Queries
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

    public class StudentStatusTypeQueryHandler : IRequestHandler<PluckStudentStatusTypesQuery, IEnumerable<StudentStatusTypeAggregateDto>>,
        IRequestHandler<PickStudentStatusTypeQuery, StudentStatusTypeAggregateDto>,
        IRequestHandler<CountStudentStatusTypesQuery, long>
    {
        private readonly IOdataFilterMapper<StudentStatusTypeAggregateDto, StudentStatusType> _filterMapper;
        private readonly IOdataNavigator<StudentStatusTypeAggregateDto, StudentStatusType> _odataProjector;
        private readonly IMapper _mapper;
        private readonly IWesterosStudentDbContextFactory _westerosStudentDbContextFactory;

        public StudentStatusTypeQueryHandler(IOdataFilterMapper<StudentStatusTypeAggregateDto, StudentStatusType> filterMapper,
            IOdataNavigator<StudentStatusTypeAggregateDto, StudentStatusType> odataProjector,
            IMapper mapper, IWesterosStudentDbContextFactory westerosStudentDbContextFactory)
        {
            _filterMapper = filterMapper ?? throw new ArgumentNullException(nameof(filterMapper));
            _odataProjector = odataProjector ?? throw new ArgumentNullException(nameof(odataProjector));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _westerosStudentDbContextFactory = westerosStudentDbContextFactory ?? throw new ArgumentNullException(nameof(westerosStudentDbContextFactory));
        }

        public async Task<IEnumerable<StudentStatusTypeAggregateDto>> Handle(PluckStudentStatusTypesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentStatusTypes.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);
            if (filter != null)
                queryable = queryable.Where(filter);
            if (request.QueryOptions.Skip != null)
                queryable = queryable.Skip(request.QueryOptions.Skip.Value);
            if (request.QueryOptions.Top != null)
                queryable = queryable.Take(request.QueryOptions.Top.Value);

            var studentStatusTypes = await queryable.ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<StudentStatusTypeAggregateDto>>(studentStatusTypes);
        }

        public async Task<StudentStatusTypeAggregateDto> Handle(PickStudentStatusTypeQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentStatusTypes.AsQueryable();
            queryable = _odataProjector.ApplyNavigations(request.QueryOptions, queryable);

            var studentStatusType = await queryable.FirstOrDefaultAsync(x => x.Id == request.StudentStatusTypeId, cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<StudentStatusTypeAggregateDto>(studentStatusType);
        }

        public async Task<long> Handle(CountStudentStatusTypesQuery request, CancellationToken cancellationToken)
        {
            var filter = request.QueryOptions.Filter != null ? _filterMapper.MapAsSearchExpression(request.QueryOptions) : default;

            using var dbContext = _westerosStudentDbContextFactory.SpawnStudentDbContext();
            var queryable = dbContext.StudentStatusTypes.AsQueryable();
            if (filter != null)
                queryable = queryable.Where(filter);

            return await queryable.LongCountAsync()
                .ConfigureAwait(false);
        }
    }
}
