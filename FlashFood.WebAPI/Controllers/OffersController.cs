using Microsoft.AspNetCore.Mvc;
using FlashFood.Offers.Models;
using FlashFood.Offers.Services;

namespace FlashFood.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OffersController : ControllerBase
{
    private readonly OfferService _offerService;

    public OffersController(OfferService offerService)
    {
        _offerService = offerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOffers()
    {
        var offers = await _offerService.GetAllOffersAsync();
        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferById(string id)
    {
        var offer = await _offerService.GetOfferByIdAsync(id);
        if (offer == null)
        {
            return NotFound();
        }
        return Ok(offer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOffer([FromBody] Offer offer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _offerService.CreateOfferAsync(offer);
        return CreatedAtAction(nameof(GetOfferById), new { id = offer.Id }, offer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOffer(string id, [FromBody] Offer updatedOffer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingOffer = await _offerService.GetOfferByIdAsync(id);
        if (existingOffer == null)
        {
            return NotFound();
        }

        await _offerService.UpdateOfferAsync(id, updatedOffer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOffer(string id)
    {
        var existingOffer = await _offerService.GetOfferByIdAsync(id);
        if (existingOffer == null)
        {
            return NotFound();
        }

        await _offerService.DeleteOfferAsync(id);
        return NoContent();
    }
}