using CrudPrueba.Exception;
using CrudPrueba.Models;
using CrudPrueba.Service;
using CrudPrueba.Service.Impl;
using CrudPrueba.Service.Mapper;
using CrudPrueba.Service.Mapper.Impl;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbCrudCoreContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("cadenaSql")
    ));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddScoped<EmpleadoService, EmpleadoServiceImpl>();
builder.Services.AddScoped<EmpleadoMapper, EmpleadoMapperImpl>();

var misReglaCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: misReglaCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ExceptionHandler();
app.UseCors(misReglaCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
