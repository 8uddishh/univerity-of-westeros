namespace UoW.Students.Martell.Application.Courses.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class CourseAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Course, bool>>>> ContainsChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Course, bool>>>>
            {
                { "Code", (value) => x => x.Code.Contains(value) },
                { "Title", (value) => x => x.Title.Contains(value) },
            };
    }
}