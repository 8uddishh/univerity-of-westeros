namespace UoW.OData.Knight.Attributes
{
    using System;

    public class ODataEntityMapperAttribute : Attribute
    {
        public string EntityName { get; set; }

        public ODataEntityMapperAttribute(string entityName)
        {
            EntityName = entityName;
        }
    }
}
