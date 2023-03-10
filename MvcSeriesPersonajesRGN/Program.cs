using Microsoft.EntityFrameworkCore;
using MvcSeriesPersonajesRGN.Data;
using MvcSeriesPersonajesRGN.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string conexion = builder.Configuration.GetConnectionString("sqlseries");
builder.Services.AddTransient<SeriesRepository>();
builder.Services.AddDbContext<SeriesContext>
    (options => options.UseSqlServer(conexion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Series}/{action=Index}/{id?}");

app.Run();
