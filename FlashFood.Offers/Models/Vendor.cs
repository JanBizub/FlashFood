namespace FlashFood.Offers.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Vendor
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("address")] public string Address { get; set; }

    [BsonElement("city")] public string City { get; set; }
}