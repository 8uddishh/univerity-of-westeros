namespace UoW.Students.Martell.Application.Common.Brokers
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using UoW.Students.Martell.Domains.Enums;

    public interface IMiddlewarePipeline
    {
        PipelineOrder Step { get; }
        void Pipe(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config);
    }
}
