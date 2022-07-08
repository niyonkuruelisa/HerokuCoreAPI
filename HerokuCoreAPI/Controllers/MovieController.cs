using BlazorChallengeApp.Server.CQRS.Commands.Movie;
using BlazorChallengeApp.Server.CQRS.Queries.Movie;
using BlazorChallengeApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChallengeApp.Server.Controllers
{
    [ApiController]
    [Route("/")]
    public class MovieController : ControllerBase
    {
        private IMediator mediator;
        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: MovieController
        [HttpGet]
        public async Task<List<Movie>> IndexAsync()
        {
            var response = await mediator.Send(new GetAllMovies.Query());

            return response.Movies;
        }

    }
}
