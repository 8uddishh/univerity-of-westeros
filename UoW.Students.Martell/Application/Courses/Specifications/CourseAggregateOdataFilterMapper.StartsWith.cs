namespace UoW.Students.Martell.Application.Courses.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.OData.Knight;

    public partial class CourseAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Course, bool>>>> StartsWithChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Course, bool>>>>
            {
                { "Code", (value) => x => x.Code.StartsWith(value) },
                { "Title", (value) => x => x.Title.StartsWith(value) },
            };
    }
}