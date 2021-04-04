namespace UoW.Students.Martell.Web.Pipelines
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Linq;
    using UoW.Students.Martell.Application.Common.Brokers;

    public static class MiddlewarePipelineExtensions
    {
        public static void ChainPipelines(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var pipelines = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IMiddlewarePipeline).IsAssignableFrom(x)
                    && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IMiddlewarePipeline>()
                .OrderBy(x => (int)x.Step)
                .ToList();

            pipelines.ForEach(installer =>
            {
                installer.Pipe(app, configuration, environment.EnvironmentName);
            });
        }
    }
}
