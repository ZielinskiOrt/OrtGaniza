using Data;
using Data.Repositories.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OrtganizaPresentacion.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrtganizaDbContext>(options =>
{
    // Obtener la cadena de conexión definida en appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ModelValidationFilter());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
