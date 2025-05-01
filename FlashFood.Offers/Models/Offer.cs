using System;
using System.Collections.Generic;
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

    public enum OfferStatus
    {
        Active,
        PickedUp,
        Expired
    }

    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("restaurant")]
        public string Restaurant { get; set; } = string.Empty;

        [BsonElement("meal")]
        public string Meal { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("user")]
        public User User { get; set; } = new();

        [BsonElement("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [BsonElement("pickupTime")]
        public DateTime PickupTime { get; set; }

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public OfferStatus Status { get; set; }
        
        [BsonElement("vendor_id")]
        public string VendorId { get; set; } = string.Empty;

        [BsonElement("offerType")]
        [BsonRepresentation(BsonType.String)]
        public OfferType OfferType { get; set; }

        [BsonElement("details")]
        public Dictionary<string, object>? OfferTypeDetails { get; set; }
    }

    public class User
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
    }
}
