namespace UoW.Students.Martell.Application.Students.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class StudentAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Student, bool>>>> GreaterThanEqualChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Student, bool>>>>
            {
                { "Id", (value) => x => x.Id >= value.AsInt() },
                { "DateOfBirth", (value) => x => x.DateOfBirth >= value.AsDateTime() },
                { "DateOfJoin", (value) => x => x.DateOfJoin >= value.AsDateTime() },
            };
    }
}
