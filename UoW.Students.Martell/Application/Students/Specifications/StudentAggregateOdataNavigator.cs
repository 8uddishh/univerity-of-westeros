namespace UoW.Students.Martell.Application.Students.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OData.UriParser;
    using System;
    using System.Linq;
    using UoW.OData.Knight;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentAggregateOdataNavigator : OdataNavigator<StudentAggregateDto, Student>
    {
        private readonly IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> _studentCourseFilterMapper;

        public StudentAggregateOdataNavigator(IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> studentCourseFilterMapper)
        {
            _studentCourseFilterMapper = studentCourseFilterMapper ?? throw new ArgumentNullException(nameof(studentCourseFilterMapper));
        }

        public override IQueryable<Student> SafeApplyNavigationSource(ExpandedNavigationSelectItem selectedItem,
            IQueryable<Student> queryable)
        {
            switch (selectedItem.NavigationSource?.Name)
            {
                case "StudentCourses":
                    var studentSourseWhere = _studentCourseFilterMapper.MapAsSearchExpression(selectedItem.FilterOption);
                    return studentSourseWhere != default ?
                    queryable.Include(s => s.StudentCourses.AsQueryable().Where(studentSourseWhere)) :
                    queryable.Include(s => s.StudentCourses.AsQueryable());
                default:
                    return queryable;
            }
        }
    }
}
