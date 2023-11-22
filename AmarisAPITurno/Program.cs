using Microsoft.EntityFrameworkCore;
using AmarisAPITurno.Models;
using System.Text.Json.Serialization;
using AmarisAPITurno.Interfaces;
using AmarisAPITurno.BL;
using AmarisAPITurno.DA;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbAmarisTurnosContext>(opcion => opcion.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddControllers().AddJsonOptions(opcion =>
{
    opcion.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddScoped<ITurnoBL, TurnoBL>();
builder.Services.AddScoped<ITurnoDA, TurnoDA>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
