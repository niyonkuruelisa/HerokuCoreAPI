using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace HerokuCoreAPI.Controllers
{
    [ApiController]
    [Route("cosmos")]
    public class CosmosController : ControllerBase
    {
        private IMediator mediator;

        // The Cosmos DB endpoint 
        private static readonly string? EndpointUri = System.Configuration.ConfigurationManager.AppSettings["EndpointUri"];
        // The  Cosmos DB PrimaryKey 
        private static readonly string? PrimaryKey = System.Configuration.ConfigurationManager.AppSettings["PrimaryKey"];

        // The Cosmos Client instance
        private CosmosClient? cosmosClient;

        // The Cosmos Databases
        private Database? PeopleDB;

        // The Cosmos Container
        private Container? PeopleContainer;
        // name of database and container that we will create
        private static readonly string PeopleDBName = "PeopleDB";

        public CosmosController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: MovieController
        [HttpGet]
        public async Task<List<Models.Person>> GetPeople(String localEndPointURi)
        {
            // Save Candidate to Database Container

            var rtnlist = new List<Models.Person>();

            
            await SettingProgram(localEndPointURi);
            return rtnlist ?? null;
        }

        /// <summary>
        /// Authentication & Connecting a client to CosmosDb
        /// & Creating Database for Each Microservice:
        /// (CreditManager, CandidateManager, RegionManager, CatalogManager)
        /// </summary>
        /// <returns></returns>
        private async Task SettingProgram([FromBody] string endpointURL)
        {
            try
            {
                Console.WriteLine("Authentication & Connecting a client to CosmosDb...");
                cosmosClient = new(endpointURL, PrimaryKey, new CosmosClientOptions { ApplicationName = "HerokuCoreAPI" });
                
                // creating CandidateManagerDB database
                PeopleDB = await cosmosClient.CreateDatabaseIfNotExistsAsync(id: PeopleDBName);
                Console.WriteLine($"Created Database: #{PeopleDB.Id}");
                

                // creating CandidateManagerDB container
                PeopleContainer = await PeopleDB.CreateContainerIfNotExistsAsync(id: "People", partitionKeyPath: "/lastName", throughput: 400);
                Console.WriteLine($"Created Container: #{PeopleContainer.Id}");

                // Save Candidate to Database Container

                int flag = 1000;
                for (int i = 0; i < 100; i++)
                {
                    //Person
                    Models.Person person1 = new Models.Person();
                    person1 = new Models.Person
                    {
                        ActorId = flag,
                    };
                    Models.Person person = await PeopleContainer.UpsertItemAsync(
                    item: person1, partitionKey: new PartitionKey(person1.LastName));
                    flag++;
                }

            }
            catch (CosmosException cosmosException)
            {
                Exception baseException = cosmosException.GetBaseException();
                Console.WriteLine("Exception: {0} with error: {1}", cosmosException.StatusCode, cosmosException);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: {0}", exception.Message);
            }
            finally
            {
                Console.WriteLine("All Tasks Are done.");
            }

        }

    }
}