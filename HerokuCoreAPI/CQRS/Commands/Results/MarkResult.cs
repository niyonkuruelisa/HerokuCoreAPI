using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Commands.Results
{
    public class MarkResult
    {

        // Data to execute
        public record Command(string auth,int resultIds,bool isMarked) : IRequest<Response>;
        //Handler
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IMemoryCache MemoryCache;
            public Handler(IMemoryCache MemoryCache)
            {
                this.MemoryCache = MemoryCache;
            }
            // Business logic goes here.
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                ResultsData results = new ResultsData();
                Models.Result result;
                List<Models.Result> resultsList = await results.GetResultsCache(MemoryCache);
                // change is marked
                resultsList.Find(resultTemp => resultTemp.ResultId == request.resultIds).isMarked = request.isMarked;
                //return the updated object
                result = resultsList.Find(resultTemp => resultTemp.ResultId == request.resultIds);

                return new Response(Result: result);
            }
        }
        //Response
        public record Response(Models.Result Result);
    }
}
