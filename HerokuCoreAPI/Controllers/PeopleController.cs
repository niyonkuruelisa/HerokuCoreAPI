using HerokuCoreAPI.CQRS.Queries.People;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HerokuCoreAPI.Controllers
{

    [ApiController]
    [Route("api")]
    public class PeopleController : ControllerBase
    {
        private IMediator mediator;
        public PeopleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: Get All People
        [HttpGet("people/all")]
        public async Task<List<Models.Person>> GetPeople(string auth)
        {
            var response = await mediator.Send(new GetPeople.Query(auth));
            return response.People ?? null;
        }

        // GET: Get People By ID
        [HttpGet("people")]
        public async Task<Models.Person> GetPerson(string auth, Guid id)
        {
            var response = await mediator.Send(new GetPerson.Query(auth, id));
            return response.Person ?? null;
        }
    }
}
