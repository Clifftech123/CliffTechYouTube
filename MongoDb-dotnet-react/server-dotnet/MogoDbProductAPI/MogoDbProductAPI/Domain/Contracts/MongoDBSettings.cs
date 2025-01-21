namespace MogoDbProductAPI.Domain.Contracts
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string CollectionName { get; set; } = null!;
    }
}
