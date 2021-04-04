namespace UoW.Students.Martell.Application.Students.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.OData.Knight;

    public partial class StudentAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Student, bool>>>> StartsWithChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Student, bool>>>>
            {
                { "RollNumber", (value) => x => x.RollNumber.StartsWith(value) },
                { "FirstName", (value) => x => x.FirstName.StartsWith(value) },
                { "LastName", (value) => x => x.LastName.StartsWith(value) },
            };
    }
}