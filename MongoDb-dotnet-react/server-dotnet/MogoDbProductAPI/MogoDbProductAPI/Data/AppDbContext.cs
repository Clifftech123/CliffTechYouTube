using Microsoft.Extensions.Options;
using MogoDbProductAPI.Domain.Contracts;
using MogoDbProductAPI.Domain.Model;
using MongoDB.Driver;

namespace MogoDbProductAPI.Data
{
    public class AppDbContext
    {
        public IMongoCollection<Product> ProductCollection { get; }


        public AppDbContext(IOptions<MongoDBSettings> settings)
        {
            // This is given us connection string 
            MongoClient client = new MongoClient(settings.Value.ConnectionURI);

            // Connecting to the database name 
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);


            // Connecting to the collection name 
            ProductCollection = database.GetCollection<Product>(settings.Value.CollectionName);

        }
    }
}
