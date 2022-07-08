
using Microsoft.Extensions.Caching.Memory;
namespace HerokuCoreAPI.Data{
    public class ResultsIDData
    {
        public async Task<List<int>> GetResultsInts()
        {
            return new List<int>
                {
                    67518,
                    120697,
                    806613,
                    762440,
                    553141,
                    988079,
                    939136,
                    583596,
                    573055,
                    939136,
                    583596,
                    573055,
                };
        }
        public async Task<List<int>> GetResultsIntsCache(IMemoryCache memoryCashe)
        {
            List<int> output = new List<int>();
            //check if there is a cache for the results
            output = memoryCashe.Get<List<int>>("ResultsInt");
            if (output is null)
            {
                Console.WriteLine("New Data...");

                // if no caches return data then catch data.
                output = await GetResultsInts();
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
