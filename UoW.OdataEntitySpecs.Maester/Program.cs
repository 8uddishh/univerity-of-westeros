namespace UoW.OdataEntitySpecs.Maester
{
    using CommandLine;
    using HandlebarsDotNet;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using UoW.OData.Knight.Attributes;
    using FunctionOps = Microsoft.AspNet.OData.Query.AllowedFunctions;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    class Program
    {
        async static Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<GeneratorOptions>(args)
                .WithParsedAsync(async opt => await GenarateOdataSpecificationsAsync(opt))
                .ConfigureAwait(false);
        }

        private async static Task WriteFileAsync(string code, string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (dir != null)
                Directory.CreateDirectory(dir);

            if (File.Exists(path))
            {
                var old = await File.ReadAllTextAsync(path)
                    .ConfigureAwait(false);
                if (old == code)
                    return;
            }

            await File.WriteAllTextAsync(path, code)
                .ConfigureAwait(false);
        }

        private async static Task GenarateOdataSpecificationsAsync(GeneratorOptions opt)
        {
            using var dynamicContext = new AssemblyResolver(Path.GetFullPath(opt.Assembly));
            var assembly = dynamicContext.Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsInterface)
                    continue;
                var attr = type.GetCustomAttribute<ODataEntityMapperAttribute>();
                if (attr == null)
                    continue;

                var entityName = type.Name.EndsWith("AggregateDto") ? $"{attr.EntityName}Aggregate" : attr.EntityName;
                var specWritePath = Path.GetFullPath($"Application\\{attr.EntityName}s\\Specifications\\");
                // var specWritePath = "C:\\builds\\Test\\";
                var templatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.hbs";
                var templateContent = await File.ReadAllTextAsync(templatePath);
                var fileContent = Handlebars.Compile(templateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    DtoName = type.Name,
                    ClassEntityName = entityName
                });

                await WriteFileAsync(fileContent, $"{specWritePath}{entityName}OdataFilterMapper.cs")
                    .ConfigureAwait(false);

                var typeDictionary = new Dictionary<Type, string>
                {
                    { typeof(int), ".AsInt()" },
                    { typeof(int?), ".AsInt()" },
                    { typeof(long), ".AsLong()" },
                    { typeof(long?), ".AsLong()" },
                    { typeof(decimal), ".AsDecimal()" },
                    { typeof(decimal?), ".AsDecimal()" },
                    { typeof(DateTime), ".AsDateTime()" },
                    { typeof(DateTime?), ".AsDateTime()" },
                    { typeof(string), "" },
                };

                #region Filter Operations
                var validProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                var equalityChecks = new List<ODataPropertyMap>();
                var greaterThanChecks = new List<ODataPropertyMap>();
                var greaterThanEqualChecks = new List<ODataPropertyMap>();
                var lesserThanChecks = new List<ODataPropertyMap>();
                var lesserThanEqualChecks = new List<ODataPropertyMap>();
                var notEqualChecks = new List<ODataPropertyMap>();

                var containsChecks = new List<ODataPropertyMap>();
                var startsWithChecks = new List<ODataPropertyMap>();
                var endsWithChecks = new List<ODataPropertyMap>();

                foreach (var property in validProperties)
                {
                    var odataProp = property.GetCustomAttribute<ODataPropertyMapperAttribute>(true);
                    if (odataProp == null)
                        continue;

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.Equal))
                        equalityChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.GreaterThan))
                        greaterThanChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.GreaterThanOrEqual))
                        greaterThanEqualChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.LessThan))
                        lesserThanChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.LessThanOrEqual))
                        lesserThanEqualChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedLogicalOperators.HasFlag(LogicalOps.NotEqual))
                        notEqualChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name,
                            PostFix = typeDictionary.Any(x => x.Key == property.PropertyType) ?
                                typeDictionary[property.PropertyType] : string.Empty
                        });

                    if (odataProp.AllowedFunctions.HasFlag(FunctionOps.Contains))
                        containsChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name
                        });

                    if (odataProp.AllowedFunctions.HasFlag(FunctionOps.StartsWith))
                        startsWithChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name
                        });

                    if (odataProp.AllowedFunctions.HasFlag(FunctionOps.EndsWith))
                        endsWithChecks.Add(new ODataPropertyMap
                        {
                            PropertyName = odataProp.Name
                        });
                }

                #region Logical Operations
                var eqTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.Equal.hbs";
                var eqTemplateContent = await File.ReadAllTextAsync(eqTemplatePath)
                    .ConfigureAwait(false);
                var eqFileContent = Handlebars.Compile(eqTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = equalityChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(eqFileContent, $"{specWritePath}{entityName}OdataFilterMapper.Equal.cs")
                    .ConfigureAwait(false);

                var gtTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.GreaterThan.hbs";
                var gtTemplateContent = await File.ReadAllTextAsync(gtTemplatePath)
                    .ConfigureAwait(false);
                var gtFileContent = Handlebars.Compile(gtTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = greaterThanChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(gtFileContent, $"{specWritePath}{entityName}OdataFilterMapper.GreaterThan.cs")
                    .ConfigureAwait(false);

                var gteTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.GreaterThanEqual.hbs";
                var gteTemplateContent = await File.ReadAllTextAsync(gteTemplatePath)
                    .ConfigureAwait(false);
                var gteFileContent = Handlebars.Compile(gteTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = greaterThanEqualChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(gteFileContent, $"{specWritePath}{entityName}OdataFilterMapper.GreaterThanEqual.cs")
                    .ConfigureAwait(false);

                var ltTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.LesserThan.hbs";
                var ltTemplateContent = await File.ReadAllTextAsync(ltTemplatePath)
                    .ConfigureAwait(false);
                var ltFileContent = Handlebars.Compile(ltTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = lesserThanChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(ltFileContent, $"{specWritePath}{entityName}OdataFilterMapper.LesserThan.cs")
                    .ConfigureAwait(false);

                var lteTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.LesserThanEqual.hbs";
                var lteTemplateContent = await File.ReadAllTextAsync(lteTemplatePath)
                    .ConfigureAwait(false);
                var lteFileContent = Handlebars.Compile(lteTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = lesserThanEqualChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(lteFileContent, $"{specWritePath}{entityName}OdataFilterMapper.LesserThanEqual.cs")
                    .ConfigureAwait(false);

                var neqTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.NotEqual.hbs";
                var neqTemplateContent = await File.ReadAllTextAsync(neqTemplatePath)
                    .ConfigureAwait(false);
                var neqFileContent = Handlebars.Compile(neqTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = notEqualChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(neqFileContent, $"{specWritePath}{entityName}OdataFilterMapper.NotEqual.cs")
                    .ConfigureAwait(false);
                #endregion

                #region Functional Operations
                var conTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.Contains.hbs";
                var conTemplateContent = await File.ReadAllTextAsync(conTemplatePath)
                    .ConfigureAwait(false);
                var conFileContent = Handlebars.Compile(conTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = containsChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(conFileContent, $"{specWritePath}{entityName}OdataFilterMapper.Contains.cs")
                    .ConfigureAwait(false);

                var stwTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.StartsWith.hbs";
                var stwTemplateContent = await File.ReadAllTextAsync(stwTemplatePath)
                    .ConfigureAwait(false);
                var stwFileContent = Handlebars.Compile(stwTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = containsChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(stwFileContent, $"{specWritePath}{entityName}OdataFilterMapper.StartsWith.cs")
                    .ConfigureAwait(false);

                var enwTemplatePath = $"{AppContext.BaseDirectory}Templates\\Filters\\OdataFilterMapper.EndsWith.hbs";
                var enwTemplateContent = await File.ReadAllTextAsync(enwTemplatePath)
                    .ConfigureAwait(false);
                var enwFileContent = Handlebars.Compile(enwTemplateContent)(new
                {
                    opt.ProjectNamespace,
                    attr.EntityName,
                    Properties = containsChecks,
                    ClassEntityName = entityName
                });
                await WriteFileAsync(enwFileContent, $"{specWritePath}{entityName}OdataFilterMapper.EndsWith.cs")
                    .ConfigureAwait(false);
                #endregion
                #endregion
            }
        }
    }
}
