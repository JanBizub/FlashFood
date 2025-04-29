using FlashFood.Offers.DTOs;
using Microsoft.AspNetCore.Mvc;
using FlashFood.Offers.Models;
using FlashFood.Offers.Services;

namespace FlashFood.WebAPI.Controllers;

[ApiController]
[Route("api/vendors")]
public class VendorsController : ControllerBase
{
    
    private readonly OfferService _offerService;
    private readonly VendorsService _vendorsService;

    public VendorsController(OfferService offerService, VendorsService vendorsService)
    {
        _offerService = offerService;
        _vendorsService = vendorsService;
    }
    
    public async Task<IActionResult> GetAllVendorsAsync()
    {
         var vendors = await _vendorsService.GetAllVendorsAsync();
         
         return Ok(vendors);
    }

    [HttpGet("city/{cityName}")]
    public async Task<IActionResult> GetVendorsWithOffersByCity(string cityName)
    {
        // 1. Find all providers in the given city
        var vendors = await _vendorsService.FindByCityAsync(cityName);

        if (vendors == null || !vendors.Any())
        {
            return NotFound($"No vendors found in city '{cityName}'.");
        }

        var responseList = new List<VendorWithOffersDto>();

        foreach (var vendor in vendors)
        {
            // 2. Find offers for each provider
            var offers = await _offerService.GetOffersByVendorIdAsync(vendor.Id);

            var offerDtos = offers.Select(o => new OfferDto
            {
                Title = o.Meal,
                Price = o.Price,
                OriginalPrice = o.Price,
                AvailableUntil = DateTime.Today // todo - hradcoded.
            }).ToList();

            // 3. Build DTO
            var vendorDto = new VendorWithOffersDto
            {
                VendorName = vendor.Name,
                StreetAddress = vendor.Address,
                Offers = offerDtos
            };

            responseList.Add(vendorDto);
        }

        // 4. Return full list
        return Ok(new CityVendorsResponse
        {
            CityName = cityName,
            Vendors = responseList
        });
    }
}