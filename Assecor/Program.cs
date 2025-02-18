using Domain.Interface;
using Domain.Repositories;

using Interfaces;

using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IColorService, ColorService>();
builder.Services.AddSingleton<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddSingleton<IReadPersonFromFile, ReadCustomCsvFile>();
builder.Services.AddSingleton<IReadColor, ReadColor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
