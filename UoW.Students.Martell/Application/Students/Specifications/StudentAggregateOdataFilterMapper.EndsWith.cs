namespace UoW.Students.Martell.Application.Students.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class StudentAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Student, bool>>>> EndsWithChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Student, bool>>>>
            {
                { "RollNumber", (value) => x => x.RollNumber.EndsWith(value) },
                { "FirstName", (value) => x => x.FirstName.EndsWith(value) },
                { "LastName", (value) => x => x.LastName.EndsWith(value) },
            };
    }
}