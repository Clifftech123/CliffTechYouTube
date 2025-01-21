using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MogoDbProductAPI.Domain.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Price")]

        public Double? Price { get; set; }

    }
}
