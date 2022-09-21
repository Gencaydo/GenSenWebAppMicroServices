using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceServices.Catalog.Models
{
    public class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }
    }
}
