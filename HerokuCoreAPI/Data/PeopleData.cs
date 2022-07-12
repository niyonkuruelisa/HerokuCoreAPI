using Microsoft.Extensions.Caching.Memory;

namespace HerokuCoreAPI.Data
{
    public class PeopleData
    {
        public async Task<List<Models.Person>> GetPeople()
        {
            var rand = new Random();
            var rtnlist = new List<Models.Person>();

            int flag = 1000;
            for (int i = 0; i < 100; i++)
            {
                rtnlist.Add(
                    new Models.Person
                    {
                        ActorId = flag,
                    }
                    );
                flag++;
            }
            return rtnlist;
        }

        public async Task<List<Models.Person>> GetPeopleCache(IMemoryCache memoryCashe)
        {
            _ = new List<Models.Person>();
            //check if there is a cache for the results
            List<Models.Person> output = memoryCashe.Get<List<Models.Person>>("PeopleList");


            if (output is null)
            {
                Console.WriteLine("New People...");

                // if no caches return data then catch data.
                output = await GetPeople();
                memoryCashe.Set("PeopleList", output, TimeSpan.FromMinutes(5));
            }
            else
            {
                Console.WriteLine("Cached people...");
            }
            return output;
        }
    }
}
