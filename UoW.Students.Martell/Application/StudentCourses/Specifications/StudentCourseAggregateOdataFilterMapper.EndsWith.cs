namespace UoW.Students.Martell.Application.StudentCourses.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class StudentCourseAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<StudentCourse, bool>>>> EndsWithChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<StudentCourse, bool>>>>
            {
            };
    }
}