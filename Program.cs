using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Thêm logging và controllers
builder.Services.AddControllers();
builder.Logging.AddConsole();

var app = builder.Build();

// Phục vụ file tĩnh
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html");
});

app.Run();