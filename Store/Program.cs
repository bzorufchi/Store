using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Entitis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", policy =>
    {
        policy.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseCors("policy");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
