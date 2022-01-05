using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);
//haddle controller
builder.Services.AddControllers();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Map("/test", async context =>
//{
//await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello from map1"));
//  await context.Response.WriteAsync("Hello from map1");
//});
// Add services to the container.


//app.MapControllers();
app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();

});



app.Run();

