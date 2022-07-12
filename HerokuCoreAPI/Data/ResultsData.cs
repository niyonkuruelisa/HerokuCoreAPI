
using Microsoft.Extensions.Caching.Memory;
using static BlazorChallengeApp.Server.CQRS.Queries.Movie.GetAllMovies;

namespace HerokuCoreAPI.Data{
    public class ResultsData
    {
        public async Task<List<Models.Result>> GetResultsInts(IMemoryCache memoryCashe)
        {
            var rand = new Random();
            var rtnlist = new List<Models.Result>();

            // Get All People
            PeopleData results = new PeopleData();
            List<Models.Person> peopleList = await results.GetPeopleCache(memoryCashe);

            // Create Results based on People
            foreach (var person in peopleList)
            {
                rtnlist.Add(
                    new Models.Result
                    {
                        ResultId = rand.Next(int.Parse(DateTime.Now.ToString("HHmmss"))),
                        Started = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"),
                        Changed = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"),
                        StreamId = Guid.NewGuid().ToString(),
                        ProfileName = $"{person.FirstName} {person.LastName}",
                        ProfileId = person.ActorId,
                    }
                    );
            }
            return rtnlist;
        }

        public async Task<List<Models.Result>> GetResultsCache(IMemoryCache memoryCashe)
        {
            _ = new List<Models.Result>();
            //check if there is a cache for the results
            List<Models.Result> output = memoryCashe.Get<List<Models.Result>>("ResultsInt");
            
            
            if (output is null)
            {
                Console.WriteLine("New Data...");

                // if no caches return data then catch data.
                output = await GetResultsInts(memoryCashe);
                memoryCashe.Set("ResultsInt", output, TimeSpan.FromMinutes(5));
            }
            else
            {
                Console.WriteLine("Cached Data...");
            }
            return output;
        }
    }
}
