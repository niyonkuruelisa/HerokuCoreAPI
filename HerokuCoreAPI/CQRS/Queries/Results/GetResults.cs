using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.Result
{
    public class GetResults
    {

        
        // Data to execute
        public record Query(string auth,int resultids) : IRequest<Response>;
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
                Models.Result result;
                List< Models.Result> resultsList= await results.GetResultsCache(MemoryCache);
                result = resultsList.Find(resultTemp => resultTemp.ResultId == request.resultids && resultTemp.isMarked == false);

                return new Response(result: result);
            }
        }

        // Response
        public record Response(Models.Result result);
    }
}
