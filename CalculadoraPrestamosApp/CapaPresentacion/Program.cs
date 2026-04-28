using CapaDatos.Repositorio;
using CapaNegocio.Interfaces;
using CapaNegocio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<Cuota_Repository>(_ =>
    new Cuota_Repository(builder.Configuration.GetConnectionString("cadenaConexion"))
);

builder.Services.AddScoped<ICuota_Service, Cuota_Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuota}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
