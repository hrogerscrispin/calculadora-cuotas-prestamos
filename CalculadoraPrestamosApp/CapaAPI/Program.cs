using CapaDatos.Repositorio;
using CapaNegocio.Interfaces;
using CapaNegocio.Servicios;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<Cuota_Repository>(_=>
    new Cuota_Repository(builder.Configuration.GetConnectionString("cadenaConexion")));


builder.Services.AddScoped<ICuota_Service, Cuota_Service>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
