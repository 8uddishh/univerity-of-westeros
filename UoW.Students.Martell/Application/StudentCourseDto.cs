namespace UoW.Students.Martell.Application
{
    using UoW.OData.Knight.Attributes;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    public class StudentCourseDto
    {
        [ODataPropertyMapper("Id", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int Id { get; set; }

        [ODataPropertyMapper("Percentage", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public decimal Percentage { get; set; }

        [ODataPropertyMapper("StudentId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int StudentId { get; set; }

        [ODataPropertyMapper("CourseId", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.GreaterThan | LogicalOps.GreaterThanOrEqual
            | LogicalOps.LessThan | LogicalOps.LessThanOrEqual | LogicalOps.NotEqual)]
        public int CourseId { get; set; }
    }
}
