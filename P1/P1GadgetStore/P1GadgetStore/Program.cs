using Microsoft.AspNetCore.Mvc.Formatters;
using OsaGadgetStore;


var builder = WebApplication.CreateBuilder(args);

//string connectionString = await File.ReadAllTextAsync("");
///string connectionString = builder.Configuration.GetConnectionString("RPS-DB-Connection");
//haddle controller
builder.Services.AddControllers();


//app.MapGet("/", () => "Hello World!");
bool prettyPrintJson = builder.Configuration.GetValue<string>("PrettyPrintJsonOutput") == "true";

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // custom formatters configured here to enable any/all action methods to either
    // get new/different/non-json formats in model binding and/or their results
    //  to get serialized in new/different/non-json formats
    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

    var jsonFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First();
    jsonFormatter.SerializerOptions.WriteIndented = prettyPrintJson;
});
//app.Map("/test", async context =>
//{
//await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello from map1"));
//  await context.Response.WriteAsync("Hello from map1");
//});
// Add services to the container.
//builder.Services.AddSingleton(sp => new Connection(connectionString));



var app = builder.Build();


//app.MapControllers();
app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();

});



app.Run();

