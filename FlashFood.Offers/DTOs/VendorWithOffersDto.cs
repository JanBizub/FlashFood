namespace FlashFood.Offers.DTOs;

public class OfferDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public DateTime AvailableUntil { get; set; }
}

public class VendorWithOffersDto
{
    public string VendorName { get; set; }
    public string StreetAddress { get; set; }
    public List<OfferDto> Offers { get; set; }
}

public class CityVendorsResponse
{
    public string CityName { get; set; }
    public List<VendorWithOffersDto> Vendors { get; set; }
}