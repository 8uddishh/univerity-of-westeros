namespace UoW.Students.Martell.Application.Students.Specifications
{
    using UoW.Students.Martell.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using UoW.DataTypes.Knight;

    public partial class StudentAggregateOdataFilterMapper
    {
        public override Dictionary<string, Func<string, Expression<Func<Student, bool>>>> NotEqualChecks { get; } =
            new Dictionary<string, Func<string, Expression<Func<Student, bool>>>>
            {
                { "Id", (value) => x => x.Id != value.AsInt() },
                { "RollNumber", (value) => x => x.RollNumber != value },
                { "FirstName", (value) => x => x.FirstName != value },
                { "LastName", (value) => x => x.LastName != value },
                { "DateOfBirth", (value) => x => x.DateOfBirth != value.AsDateTime() },
                { "Gender", (value) => x => x.Gender != value },
                { "DateOfJoin", (value) => x => x.DateOfJoin != value.AsDateTime() },
                { "DepartmentId", (value) => x => x.DepartmentId != value.AsInt() },
                { "BatchId", (value) => x => x.BatchId != value.AsInt() },
                { "StudentStatusTypeId", (value) => x => x.StudentStatusTypeId != value.AsInt() },
                { "CurrentSemesterId", (value) => x => x.CurrentSemesterId != value.AsInt() },
            };
    }
}
