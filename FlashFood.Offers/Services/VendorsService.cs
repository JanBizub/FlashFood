namespace FlashFood.Offers.Services;

using FlashFood.Offers.Models;
using MongoDB.Driver;

public class VendorsService
{
    private readonly IMongoCollection<Vendor> _vendors;

    public VendorsService(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        _vendors = database.GetCollection<Vendor>(collectionName);
    }

    public async Task<List<Vendor>> GetAllVendorsAsync () 
    {
        return await _vendors.Find(vendor => true).ToListAsync();
    }

    public async Task<Vendor> GetVendorByIdAsync (string id) 
    {
        return await _vendors.Find(vendor => vendor.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List <Vendor>> FindByCityAsync(string cityName)
    {
        return await _vendors.Find(vendor => vendor.City == cityName).ToListAsync();
    }
    
    
}