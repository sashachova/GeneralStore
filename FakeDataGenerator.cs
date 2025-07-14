using Bogus;

namespace GeneralStore
{
    public class FakeDataGenerator
{
    private static readonly Faker faker = new Faker("en");

    public static string GenerateName()
    {
        return faker.Name.FullName();
    }

    public static string GenerateCountry()
    {
        return faker.Address.Country();
    }
}
}

