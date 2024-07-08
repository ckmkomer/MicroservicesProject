using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Course.Services.Catalog.Model
{
    public class Courses
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // mongo db tarafında tipini belirledik.
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public string UserId { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore] // bunu mongo db ye ekleme 
        public Category Category { get; set; } // bunu kodlama esnasında kullanacağım productları dönerken catalogları dönmek istiyorum yalnız bunun mongo db de karşılığa olmayacak collegino eklemiyeceğiz.
    }
}
