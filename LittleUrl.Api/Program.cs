using LittleUrl.Api.Contracts;
using LittleUrl.Api.Data;
using LittleUrl.Api.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IUrlShortener, UrlShortener>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IStorageProvider, InMemoryStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/url/create",
        (CreateShortUrl req, IUrlShortener urlShortener) => { return urlShortener.Shorten(req.Url); })
    .WithName("CreateShortUrl");

app.MapGet("/{shortcode}", (string shortcode) => { return Results.Redirect(shortcode); }).WithName("ResolveShortUrl");

app.Run();