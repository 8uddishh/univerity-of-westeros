namespace UoW.Students.Martell.Application
{
    using UoW.OData.Knight.Attributes;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    public class StudentStatusTypeDto
    {
        [ODataPropertyMapper("Id", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public int Id { get; set; }

        [ODataPropertyMapper("Name", AllowedLogicalOperators = LogicalOps.Equal | LogicalOps.NotEqual)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
