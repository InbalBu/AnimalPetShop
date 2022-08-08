using Microsoft.EntityFrameworkCore;
using AnimalShopProject.Data;
using AnimalShopProject.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<AnimalContext>(options => options.UseSqlite("Data Source=c:\\temp\\animals.db"));
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");

});

app.Run();
