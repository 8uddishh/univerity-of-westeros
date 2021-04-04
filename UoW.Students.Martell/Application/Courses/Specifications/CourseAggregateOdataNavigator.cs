namespace UoW.Students.Martell.Application.Courses.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OData.UriParser;
    using System;
    using System.Linq;
    using UoW.OData.Knight;
    using UoW.OData.Knight.Brokers;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Domain.Entities;

    public class CourseAggregateOdataNavigator : OdataNavigator<CourseAggregateDto, Course>
    {
        private readonly IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> _studentCourseFilterMapper;

        public CourseAggregateOdataNavigator(IOdataFilterMapper<StudentCourseAggregateDto, StudentCourse> studentCourseFilterMapper)
        {
            _studentCourseFilterMapper = studentCourseFilterMapper ?? throw new ArgumentNullException(nameof(studentCourseFilterMapper));
        }

        public override IQueryable<Course> SafeApplyNavigationSource(ExpandedNavigationSelectItem selectedItem,
            IQueryable<Course> queryable)
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
