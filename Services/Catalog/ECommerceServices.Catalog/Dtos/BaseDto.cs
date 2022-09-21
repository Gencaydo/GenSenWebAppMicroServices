using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceServices.Catalog.Dtos
{
    public class BaseDto
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
