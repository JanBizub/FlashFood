namespace FlashFood.Offers.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Vendor
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("name")] 
    public string Name { get; set; } = string.Empty;

    [BsonElement("address")] 
    public string Address { get; set; } = string.Empty;

    [BsonElement("city")] 
    public string City { get; set; } = string.Empty;
}