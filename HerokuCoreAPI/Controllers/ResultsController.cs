using BlazorChallengeApp.Shared;
using HerokuCoreAPI.CQRS.Queries.Result;
using HerokuCoreAPI.CQRS.Commands.Results;
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
        public async Task<List<int>> GetResultIds(string auth,DateTime start, DateTime end)
        {
            var response = await mediator.Send(new GetResultIds.Query(auth, start.ToString("yyy-MM-dd"), end.ToString("yyy-MM-dd")));
            return response.resultIdsList ?? null;
        }


        // GET: Results
        [HttpGet("results")]
        public async Task<Models.Result> GetResults(string auth,int resultids)
        {
            var response = await mediator.Send(new GetResults.Query(auth, resultids));
            return response.result ?? null;
        }
        // Post: change mark of a result
        [HttpPost("results")]
        public async Task<Models.Result> MarkResult(string auth,int resultids,bool isMarked)
        {
            var response = await mediator.Send(new MarkResult.Command(auth, resultids,isMarked));
            return response.Result ?? null;
        }
    }
}


