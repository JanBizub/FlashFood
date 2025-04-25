using FlashFood.Offers.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<OfferServiceSettings>(builder.Configuration.GetSection("OfferServiceSettings"));
builder.Services.AddScoped<OfferService>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<OfferServiceSettings>>().Value;
    return new OfferService(settings.ConnectionString, settings.DatabaseName, settings.CollectionName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();