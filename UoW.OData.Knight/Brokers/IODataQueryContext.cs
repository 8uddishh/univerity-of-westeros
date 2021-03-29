namespace UoW.OData.Knight.Brokers
{
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IODataQueryContext
    {
        string Name { get; }
        Task<long> CountAsync();
    }
    public interface IODataQueryContext<T> : IODataQueryContext where T : class, new()
    {

        ODataQueryOptions<T> SpawnOdataQueryOptions();
        ODataQueryOptions<T> SpawnOdataQueryOptions(HttpRequest httpRequest);
    }
}
