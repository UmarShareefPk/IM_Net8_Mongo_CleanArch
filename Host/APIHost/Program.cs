using APIHost;
using APIHost.Helpers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Controllers from other assemblies
//builder.Services.AddControllers()
//    .PartManager.ApplicationParts.Add(new AssemblyPart(typeof(Auth.API.Controllers.UserController).Assembly));

// Dynamically load all *.API assemblies
builder.Services.AddControllersFromBoundedContexts(builder);

builder.Services.AddAuthServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(); // You can add options here for grouping, etc.

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();
