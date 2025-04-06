
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
