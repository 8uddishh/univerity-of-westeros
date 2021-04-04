namespace UoW.OdataEntitySpecs.Maester
{
    using CommandLine;

    [Verb("generate-for", HelpText = "Generate filters and navigators")]
    public class GeneratorOptions
    {
        [Option('a', "assembly", Required = true, HelpText = "Assembly to scan")]
        public string Assembly { get; set; }

        [Option('p', "project", Required = true, HelpText = "Project namespace")]
        public string ProjectNamespace { get; set; }
    }
}
