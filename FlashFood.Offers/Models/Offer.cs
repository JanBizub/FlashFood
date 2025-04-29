using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlashFood.Offers.Models
{
    public enum OfferType
    {
        Standard,
        HappyHour,
        Combo,
        LimitedTime
    }

    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("restaurant")]
        public string Restaurant { get; set; }

        [BsonElement("meal")]
        public string Meal { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("user")]
        public User User { get; set; }

        [BsonElement("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [BsonElement("pickupTime")]
        public DateTime PickupTime { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("offerType")]
        [BsonRepresentation(BsonType.String)]
        public OfferType OfferType {get; set; }

        [BsonElement("details")]
        public Dictionary<string, object>? OfferTypeDetails { get; set; }
    }

    public class User
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
