namespace UoW.Students.Martell.Application.StudentCourses.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class StudentCourseAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<StudentCourse, bool>>>> GreaterThanChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<StudentCourse, bool>>>>
            {
                { "Id", (value) => x => x.Id > value.AsInt() },
                { "Percentage", (value) => x => x.Percentage > value.AsDecimal() },
                { "StudentId", (value) => x => x.StudentId > value.AsInt() },
                { "CourseId", (value) => x => x.CourseId > value.AsInt() },
            };
    }
}
