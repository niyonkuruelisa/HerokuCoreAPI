using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.Result
{
    public class GetResults
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
                
                ResultsIDData results = new ResultsIDData();
                List<int> rtnlist = await results.GetResultsIntsCache(MemoryCache);

                return new Response(randomInts: rtnlist);
            }
        }

        // Response
        public record Response(List<int> randomInts);
    }
}
