
using MediatR;

namespace BlazorChallengeApp.Server.CQRS.Commands.Movie
{
    public static class CreateMovies
    {
        /// <summary>
        ///Data to execute
        /// </summary>
        public record Command(List<Shared.Movie> Movies) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            
            public Handler() { 

            }

            /// <summary>
            /// Handle All business logic. Get Movie And It's assiated Days And Time.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                
                return new Response(true);
            }
        }
        /// <summary>
        /// Return true
        /// </summary>
        /// <param name="saved"></param>
        public record Response(bool saved);

    }
}
