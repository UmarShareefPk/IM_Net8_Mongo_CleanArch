using APIHost;
using APIHost.Helpers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

BsonSerializer.RegisterSerializer(new EnumSerializer<TaskStatus>(BsonType.String));

// Dynamically load all *.API assemblies
builder.Services.AddControllersFromBoundedContexts(builder);

builder.Services.AddServices(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("ClientPermission");

app.UseSwagger();
app.UseSwaggerUI(); // You can add options here for grouping, etc.

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();
