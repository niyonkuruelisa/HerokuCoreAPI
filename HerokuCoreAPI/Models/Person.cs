namespace HerokuCoreAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ActorId { get; set; }
        public string? FirstName { get; set; } = $"{Faker.Name.First()}";
        public string? LastName { get; set; } = $"{Faker.Name.Last()}-{Faker.RandomNumber.Next(100)}";
        public string? Email { get; set; }

        public Person()
        {
            this.Email = $"{Faker.Internet.Email($"{FirstName}-{LastName}")}";
        }
    }
}
