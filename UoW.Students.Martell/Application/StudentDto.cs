namespace UoW.Students.Martell.Application
{
    using System;
    using UoW.OData.Knight.Attributes;
    using FunctionOps = Microsoft.AspNet.OData.Query.AllowedFunctions;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    public class StudentDto
    {
        [ODataPropertyMapper("Id", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int Id { get; set; }

        [ODataPropertyMapper("RollNumber", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual,
            AllowedFunctions = FunctionOps.Contains | FunctionOps.StartsWith | FunctionOps.EndsWith)]
        public string RollNumber { get; set; }

        [ODataPropertyMapper("FirstName", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual,
            AllowedFunctions = FunctionOps.Contains | FunctionOps.StartsWith | FunctionOps.EndsWith)]
        public string FirstName { get; set; }

        [ODataPropertyMapper("LastName", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual,
            AllowedFunctions = FunctionOps.Contains | FunctionOps.StartsWith | FunctionOps.EndsWith)]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        [ODataPropertyMapper("DateOfBirth", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public DateTime DateOfBirth { get; set; }

        [ODataPropertyMapper("Gender", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public string Gender { get; set; }

        [ODataPropertyMapper("DateOfJoin", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public DateTime DateOfJoin { get; set; }

        [ODataPropertyMapper("DepartmentId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public int DepartmentId { get; set; }

        [ODataPropertyMapper("BatchId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public int BatchId { get; set; }

        [ODataPropertyMapper("StudentStatusTypeId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public int StudentStatusTypeId { get; set; }

        [ODataPropertyMapper("CurrentSemesterId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public int CurrentSemesterId { get; set; }
    }
}
