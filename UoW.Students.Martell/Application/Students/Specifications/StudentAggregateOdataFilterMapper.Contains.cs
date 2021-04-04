namespace UoW.Students.Martell.Application.Students.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class StudentAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Student, bool>>>> ContainsChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Student, bool>>>>
            {
                { "RollNumber", (value) => x => x.RollNumber.Contains(value) },
                { "FirstName", (value) => x => x.FirstName.Contains(value) },
                { "LastName", (value) => x => x.LastName.Contains(value) },
            };
    }
}