
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);
// Redis baglantisi
IConfiguration config = builder.Configuration;
var redis = ConnectionMultiplexer.Connect(config.GetConnectionString("RedisCon"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);
// MVC controller servisi
builder.Services.AddControllersWithViews();
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Redis}/{action=Index}/{id?}");

app.Run();
