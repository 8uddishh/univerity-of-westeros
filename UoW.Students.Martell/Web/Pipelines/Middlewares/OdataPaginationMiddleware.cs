namespace UoW.Students.Martell.Web.Pipelines.Middlewares
{
    using Autofac;
    using MediatR;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using UoW.OData.Knight.Brokers;

    public class OdataPaginationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IComponentContext _context;

        public OdataPaginationMiddleware(RequestDelegate next, IComponentContext context)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Capture the original response body stream
            var responseStream = httpContext.Response.Body;

            // Replace it with our own, so that we can read it
            using (var bodyStream = new MemoryStream())
            {
                var total = 0L;
                httpContext.Response.Body = bodyStream;
                await _next(httpContext);
                httpContext.Response.Body = responseStream;
                bodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(bodyStream).ReadToEndAsync();

                if (httpContext.Response.StatusCode == 200 &&
                    httpContext.Response.ContentType.Contains("odata") &&
                    httpContext.Response.ContentType.Contains("application/json"))
                {
                    var oDataFeature = httpContext.Request.ODataFeature();
                    var isAggregateRoute = httpContext.Request.Path.Value.Contains("aggregates");
                    var odataContext = _context.ResolveNamed<IODataQueryContext>(isAggregateRoute ?
                        $"aggregates/{oDataFeature.Path.NavigationSource.Name}" : oDataFeature.Path.NavigationSource.Name);

                    if (oDataFeature.TotalCount.HasValue && oDataFeature.TotalCount.Value > 0)
                    {
                        total = await odataContext.CountAsync()
                            .ConfigureAwait(false);
                    }

                    responseBody = responseBody.Replace("\"value\"", "\"results\"");

                    if (total > 0)
                    {
                        responseBody = Regex.Replace(responseBody, "\"@odata\\.count\":\\s*(\\d+)", $"\"@odata.count\": {total}");
                    }
                }

                await httpContext.Response.WriteAsync(responseBody);
            }
        }
    }
}
