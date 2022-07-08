
using Microsoft.Extensions.Caching.Memory;
namespace HerokuCoreAPI.Data{
    public class ResultsIDData
    {
        public async Task<List<int>> GetResultsInts()
        {
            var rand = new Random();
            var rtnlist = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                rtnlist.Add(rand.Next(int.Parse(DateTime.Now.ToString("HHmmss"))));
            }
            return rtnlist;
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
