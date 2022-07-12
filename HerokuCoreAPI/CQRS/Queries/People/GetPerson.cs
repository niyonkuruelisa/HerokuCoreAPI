using HerokuCoreAPI.Data;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.CQRS.Queries.People
{
    public class GetPerson
    {

        // Data to execute
        public record Query(string auth, Guid Guid) : IRequest<Response>;
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

                PeopleData peopleData = new PeopleData();
                Models.Person person;
                List<Models.Person> peopleList = await peopleData.GetPeopleCache(MemoryCache);
                person = peopleList.Find(personRef => personRef.Id == request.Guid);

                return new Response(Person: person);
            }
        }

        // Response
        public record Response(Models.Person Person);
    }
}
