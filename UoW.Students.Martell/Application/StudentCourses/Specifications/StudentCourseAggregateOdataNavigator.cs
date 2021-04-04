namespace UoW.Students.Martell.Application.StudentCourses.Specifications
{
    using Microsoft.OData.UriParser;
    using System.Linq;
    using UoW.OData.Knight;
    using UoW.Students.Martell.Domain.Entities;

    public class StudentCourseAggregateOdataNavigator : OdataNavigator<StudentCourseAggregateDto, StudentCourse>
    {
        public StudentCourseAggregateOdataNavigator()
        {
        }

        public override IQueryable<StudentCourse> SafeApplyNavigationSource(ExpandedNavigationSelectItem selectedItem,
            IQueryable<StudentCourse> queryable)
        {
            return queryable;
        }
    }
}
