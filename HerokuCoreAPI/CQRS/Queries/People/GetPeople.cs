using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.People
{
    public class GetPeople
    {

        // Data to execute
        public record Query(string auth) : IRequest<Response>;
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

                PeopleData results = new PeopleData();
                List<Models.Person> peopleList = await results.GetPeopleCache(MemoryCache);
                return new Response(People: peopleList);
            }
        }

        // Response
        public record Response(List<Models.Person> People);
    }
}
