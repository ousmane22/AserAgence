using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AserAgence.Data;
using static System.Formats.Asn1.AsnWriter;
using AserAgence.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AserAgenceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AserAgenceDbContext") ?? throw new InvalidOperationException("Connection string 'AserAgenceDbContext' not found.")));

builder.Services.RegisterRepositories();
builder.Services.AddControllersWithViews();

var app = builder.Build();
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

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AserAgenceDbContext>();
DbInitialize.Initialize(dbContext);
app.Run();
