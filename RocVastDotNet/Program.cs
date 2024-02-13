using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RocVastDotNet.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure DbContext options
builder.Services.AddDbContext<ProductContext>(options =>
{
    // Use ServerVersion.AutoDetect() for automatic server version detection
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
