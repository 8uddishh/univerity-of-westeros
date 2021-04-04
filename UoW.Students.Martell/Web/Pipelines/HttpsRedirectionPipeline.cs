namespace UoW.Students.Martell.Web.Pipelines
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Domains.Enums;

    public class HttpsRedirectionPipeline : IMiddlewarePipeline
    {
        public PipelineOrder Step => PipelineOrder.HttpsRedirection;

        public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
        {
            app.UseHttpsRedirection();
        }
    }
}
