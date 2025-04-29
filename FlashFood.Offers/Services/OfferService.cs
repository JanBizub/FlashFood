using FlashFood.Offers.Models;
using MongoDB.Driver;

namespace FlashFood.Offers.Services
{
    public class OfferService
    {
        private readonly IMongoCollection<Offer> _offers;

        public OfferService(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _offers = database.GetCollection<Offer>(collectionName);
        }

        public async Task<List<Offer>> GetAllOffersAsync()
        {
            return await _offers.Find(offer => true).ToListAsync();
        }

        public async Task<Offer> GetOfferByIdAsync(string id)
        {
            return await _offers.Find(offer => offer.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateOfferAsync(Offer offer)
        {
            await _offers.InsertOneAsync(offer);
        }

        public async Task UpdateOfferAsync(string id, Offer updatedOffer)
        {
            await _offers.ReplaceOneAsync(offer => offer.Id == id, updatedOffer);
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _offers.DeleteOneAsync(offer => offer.Id == id);
        }

        public async Task<List<Offer>> GetOffersByVendorIdAsync(string vendorId)
        {
            return await _offers.Find(offer => offer.VendorId == vendorId).ToListAsync();
        }
    }
}
