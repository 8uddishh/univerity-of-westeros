namespace UoW.Students.Martell.Application.StudentStatusTypes.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OData.UriParser;
    using System;
    using System.Linq;
    using UoW.OData.Knight;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentStatusTypeAggregateOdataNavigator : OdataNavigator<StudentStatusTypeAggregateDto, StudentStatusType>
    {
        private readonly IOdataFilterMapper<StudentDto, Student> _studentFilterMapper;

        public StudentStatusTypeAggregateOdataNavigator(IOdataFilterMapper<StudentDto, Student> studentFilterMapper)
        {
            _studentFilterMapper = studentFilterMapper ?? throw new ArgumentNullException(nameof(studentFilterMapper));
        }

        public override IQueryable<StudentStatusType> SafeApplyNavigationSource(ExpandedNavigationSelectItem selectedItem,
            IQueryable<StudentStatusType> queryable)
        {
            switch (selectedItem.NavigationSource?.Name)
            {
                case "Students":
                    var studentWhere = _studentFilterMapper.MapAsSearchExpression(selectedItem.FilterOption);
                    return studentWhere != default ?
                    queryable.Include(s => s.Students.AsQueryable().Where(studentWhere)) :
                    queryable.Include(s => s.Students.AsQueryable());
                default:
                    return queryable;
            }
        }
    }
}
