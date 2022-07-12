using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.Result
{
    public class GetResultIds
    {

        
        // Data to execute
        public record Query(string auth,string start,string end) : IRequest<Response>;
        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IMemoryCache MemoryCache;
            public Handler(IMemoryCache MemoryCache)
            {
                this.MemoryCache = MemoryCache;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                
                ResultsData results = new ResultsData();
                List <int> rtnlist = new List<int>();
                List <Models.Result> resultList = await results.GetResultsCache(MemoryCache);
                resultList = resultList.FindAll(result => DateTime.Parse(result.Started).ToString("yyyy-MM-dd") == request.start && DateTime.Parse(result.Changed).ToString("yyyy-MM-dd") == request.end);
                resultList.FindAll(result => DateTime.Parse(result.Started).ToString("yyyy-MM-dd") == request.start && DateTime.Parse(result.Changed).ToString("yyyy-MM-dd") == request.end).ForEach(resultObject => rtnlist.Add(resultObject.ResultId));
                return new Response(resultIdsList: rtnlist);
            }
        }

        // Response
        public record Response(List<int> resultIdsList);
    }
}
