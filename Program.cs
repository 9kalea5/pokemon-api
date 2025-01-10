using PokemonAPI.Services;
using PokemonAPI.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PokemonDatabaseSettings>(
    builder.Configuration.GetSection("PokemonDatabase"));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonService, PokemonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokemonAPI V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
