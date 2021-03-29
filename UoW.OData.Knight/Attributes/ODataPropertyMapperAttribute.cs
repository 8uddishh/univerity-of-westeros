namespace UoW.OData.Knight.Attributes
{
    using System;
    using FunctionOps = Microsoft.AspNet.OData.Query.AllowedFunctions;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    [AttributeUsage(AttributeTargets.Property)]
    public class ODataPropertyMapperAttribute : Attribute
    {
        public string Name { get; set; }
        public LogicalOps AllowedLogicalOperators { get; set; }
        public FunctionOps AllowedFunctions { get; set; }

        public ODataPropertyMapperAttribute(string name)
        {
            Name = name;
        }
    }
}
