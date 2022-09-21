using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceServices.Catalog.Models
{
    public class Course:Base
    {
        public string? UserId { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public string? Picture { get; set; }

        public Feature? Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonIgnore]
        public Category? Category { get; set; }
    }
}
