using Data;
using Data.Repositories.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OrtganizaPresentacion.Filters;
using Business.Services.Interfaces;
using Business.Services;
using Business;
using OrtganizaPresentacion;
using Business.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrtganizaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICookieService, CookieService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
builder.Services.AddScoped<IProyectoServiceValidator, ProyectoServiceValidator>();

builder.Services.AddScoped<IWebRoleRepository, WebRoleRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ModelValidationFilter());
});

builder.Services.AddAutoMapper(
    typeof(MappingProfile).Assembly,
    typeof(PresentacionMappingProfile).Assembly
);

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
