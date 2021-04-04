namespace UoW.Students.Martell.Application.StudentStatusTypes.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class StudentStatusTypeAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<StudentStatusType, bool>>>> NotEqualChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<StudentStatusType, bool>>>>
            {
                { "Id", (value) => x => x.Id != value.AsInt() },
                { "Name", (value) => x => x.Name != value },
            };
    }
}
