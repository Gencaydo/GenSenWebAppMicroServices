using ECommerceServices.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceServices.Catalog.Dtos
{
    public class CourseDto:BaseDto
    {
        public string? UserId { get; set; }

        public decimal Price { get; set; }

        public string? Picture { get; set; }

        public Feature? Feature { get; set; }

        public string? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
