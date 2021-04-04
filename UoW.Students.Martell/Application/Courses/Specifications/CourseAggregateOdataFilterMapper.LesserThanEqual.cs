namespace UoW.Students.Martell.Application.Courses.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class CourseAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Course, bool>>>> LesserThanEqualChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Course, bool>>>>
            {
                { "Id", (value) => x => x.Id <= value.AsInt() },
                { "CourseCategoryTypeId", (value) => x => x.CourseCategoryTypeId <= value.AsInt() },
            };
    }
}
