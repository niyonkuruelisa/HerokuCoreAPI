using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.Result
{
    public class GetResults
    {
        IMemoryCache MemoryCache { get; }
        public GetResults(IMemoryCache MemoryCache)
        {
            this.MemoryCache = MemoryCache;
        }
        // Data to execute
        public record Query(string auth,string start,string end) : IRequest<Response>;
        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Auth {0} start {1} end {2}", request.auth, request.start, request.end);
                var rand = new Random();
                var rtnlist = new List<int>();

                for (int i = 0; i < 100; i++)
                {
                    rtnlist.Add(rand.Next(1000000));
                }

                return new Response(randomInts: rtnlist);
            }
        }

        // Response
        public record Response(List<int> randomInts);
    }
}
