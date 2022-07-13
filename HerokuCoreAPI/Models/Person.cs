using Newtonsoft.Json;

namespace HerokuCoreAPI.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public String Id { get; set; } = Guid.NewGuid().ToString();
        [JsonProperty("actorId")]
        public int ActorId { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; } = $"{Faker.Name.First()}";
        [JsonProperty("lastName")]
        public string? LastName { get; set; } = $"{Faker.Name.Last()}-{Faker.RandomNumber.Next(100)}";
        [JsonProperty("email")]
        public string? Email { get; set; }

        public Person()
        {
            this.Email = $"{Faker.Internet.Email($"{FirstName}-{LastName}")}";
        }
    }
}
