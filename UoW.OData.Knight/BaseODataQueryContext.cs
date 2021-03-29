namespace UoW.OData.Knight
{
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using UoW.OData.Knight.Brokers;

    public class BaseODataQueryContext<T> : IODataQueryContext<T> where T : class, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseODataQueryContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public virtual string Name { get; }

        public virtual async Task<long> CountAsync()
        {
            return await Task.FromResult(0);
        }

        public ODataQueryOptions<T> SpawnOdataQueryOptions()
        {
            return SpawnOdataQueryOptions(_httpContextAccessor.HttpContext.Request);
        }

        public ODataQueryOptions<T> SpawnOdataQueryOptions(HttpRequest httpRequest)
        {
            var path = httpRequest.ODataFeature().Path;
            var model = httpRequest.GetModel();
            var queryContext = new ODataQueryContext(model, typeof(T), path);
            return new ODataQueryOptions<T>(queryContext, httpRequest);
        }
    }
}
