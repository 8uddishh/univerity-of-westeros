namespace UoW.Students.Martell.Application.StudentStatusTypes.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class StudentStatusTypeAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<StudentStatusType, bool>>>> GreaterThanEqualChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<StudentStatusType, bool>>>>
            {
            };
    }
}
