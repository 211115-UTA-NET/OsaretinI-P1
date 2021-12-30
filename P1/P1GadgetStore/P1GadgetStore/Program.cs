var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Map("/test", async context =>
{
    //await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello from map1"));
    await context.Response.WriteAsync("Hello from map1");
});
app.Run();

