using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));

// AutoMapper configuration
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IMovies, Movies1Repository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hata ayýklama için
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
