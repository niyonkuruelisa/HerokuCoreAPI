
using BlazorChallengeApp.Shared;
using MediatR;

namespace BlazorChallengeApp.Server.CQRS.Queries.Movie
{
    public static class GetAllMovies
    {


        /// <summary>
        ///Data to execute
        /// </summary>
        public record Query() : IRequest<Response>;

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {

            List<Shared.Movie> movies;

            public Handler()
            {
                movies = new List<Shared.Movie>
                {
                    new Shared.Movie
                    {
                        Id = 1,
                        Title = "The Shawshank Redemption",
                        Director = "",
                        Cast ="",
                        Genre ="",
                        Notes = "",
                        Year = 1994,
                        RunningTimes = new RunningTimes
                        {


                            Id = 1,

                            Mon  = new List<string>(){
                                "[05:00]",
                                "[12:00]"
                            },
                            Tue  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Wed  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Thu  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Fri   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sat   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sun  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            }
                        },
                    },
                    new Shared.Movie
                    {
                        Id = 2,
                        Title = "The Godfather ",
                        Director = "",
                        Cast ="",
                        Genre ="",
                        Notes = "",
                        Year = 1972,
                        RunningTimes = new RunningTimes
                        {


                            Id = 1,

                            Mon  = new List<string>(){
                                "[05:00]",
                                "[12:00]"
                            },
                            Tue  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Wed  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Thu  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Fri   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sat   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sun  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            }
                        },
                    },
                    new Shared.Movie
                    {
                        Id = 3,
                        Title = "The Dark Knight",
                        Director = "",
                        Cast ="",
                        Genre ="",
                        Notes = "",
                        Year = 2008,
                        RunningTimes = new RunningTimes
                        {


                            Id = 1,

                            Mon  = new List<string>(){
                                "[05:00]",
                                "[12:00]"
                            },
                            Tue  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Wed  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Thu  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Fri   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sat   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sun  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            }
                        },
                    },
                    new Shared.Movie
                    {
                        Id = 4,
                        Title = "The Godfather: Part II",
                        Director = "",
                        Cast ="",
                        Genre ="",
                        Notes = "",
                        Year = 1974,
                        RunningTimes = new RunningTimes
                        {


                            Id = 1,

                            Mon  = new List<string>(){
                                "[05:00]",
                                "[12:00]"
                            },
                            Tue  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Wed  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Thu  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Fri   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sat   = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            },
                            Sun  = new List<string>(){
                                "[12:00]",
                                "[12:00]"
                            }
                        },
                    }
                };
            }

            /// <summary>
            /// Handle All business logic. Get Movie And It's assiated Days And Time.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response>? Handle(Query request, CancellationToken cancellationToken)
            {
                var output = movies;

                return new Response(Movies: output) ?? null;
            }
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="Movies"></param>
        
        public record Response(List<Shared.Movie> Movies);
    }
}

