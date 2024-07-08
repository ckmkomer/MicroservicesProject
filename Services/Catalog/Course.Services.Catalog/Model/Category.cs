using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Course.Services.Catalog.Model
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // mongo db tarafında tipini belirledik.
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
