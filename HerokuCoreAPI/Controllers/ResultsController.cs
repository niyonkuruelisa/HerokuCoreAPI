using BlazorChallengeApp.Shared;
using HerokuCoreAPI.CQRS.Queries.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HerokuCoreAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ResultsController : ControllerBase
    {
        private IMediator mediator;
        public ResultsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: Results IDs
        [HttpGet("resultids")]
        public async Task<List<Models.Result>> GetResultIds(string auth,DateTime start, DateTime end)
        {
            var response = await mediator.Send(new GetResults.Query(auth, start.ToString("yyy-MM-dd"), end.ToString("yyy-MM-dd")));
            return response.randomInts;
        }

        // GET: Results
        [HttpGet("results")]
        public async Task<List<Models.Result>> GetResults(string auth,DateTime start, DateTime end)
        {
            var response = await mediator.Send(new GetResults.Query(auth, start.ToString("yyy-MM-dd"), end.ToString("yyy-MM-dd")));
            return response.randomInts;
        }
    }
}


