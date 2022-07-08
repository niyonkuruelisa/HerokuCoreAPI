using BlazorChallengeApp.Shared;
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
        // GET: MovieController
        [HttpGet("resultids")]
        public async Task<List<int>> IndexAsync(string auth,DateTime start, DateTime end)
        {
            Console.WriteLine("Auth {0} start {1} end {2}", auth, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
            var rand = new Random();
            var rtnlist = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                rtnlist.Add(rand.Next(1000000));
            }

            return rtnlist;
        }
    }
}


