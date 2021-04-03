namespace UoW.Students.Martell.Application
{
    using UoW.OData.Knight.Attributes;
    using FunctionOps = Microsoft.AspNet.OData.Query.AllowedFunctions;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    public class CourseDto
    {
        [ODataPropertyMapper("Id", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int Id { get; set; }

        [ODataPropertyMapper("Code", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual, 
            AllowedFunctions = FunctionOps.Contains | FunctionOps.StartsWith | FunctionOps.EndsWith)]
        public string Code { get; set; }

        [ODataPropertyMapper("Title", AllowedFunctions = FunctionOps.Contains | FunctionOps.StartsWith | FunctionOps.EndsWith)]
        public string Title { get; set; }

        [ODataPropertyMapper("CourseCategoryTypeId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int CourseCategoryTypeId { get; set; }
    }
}
