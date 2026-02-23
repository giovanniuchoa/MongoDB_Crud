using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Data.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("customer_name"), BsonRepresentation(Bson.BsonType.String)]
        public string? CustomerName { get; set; }

        [BsonElement("email"), BsonRepresentation(Bson.BsonType.String)]
        public string? Email { get; set; }
    }
}
