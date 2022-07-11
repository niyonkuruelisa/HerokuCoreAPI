
using Microsoft.Extensions.Caching.Memory;
namespace HerokuCoreAPI.Data{
    public class ResultsData
    {
        public async Task<List<Models.Result>> GetResultsInts()
        {
            var rand = new Random();
            var rtnlist = new List<Models.Result>();

            for (int i = 0; i < 100; i++)
            {
                rtnlist.Add(
                    new Models.Result
                    {
                        ResultId = rand.Next(int.Parse(DateTime.Now.ToString("HHmmss"))),
                        Started = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"),
                        Changed = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"),
                        StreamId = Guid.NewGuid().ToString(),
                        ProfileName = Guid.NewGuid().ToString(),
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
