using API.Errors;
using API.Extensions;
using API.Middlewares;
using Core;
using InfraStructure;
using InfraStructure.Data.SeedData;
using InfraStucture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddServices(builder.Configuration);

        var app = builder.Build();

        app.UseExceptionMiddleware();

        app.UseStatusCodePagesWithReExecute("/Error/{0}");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<StoreDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();
        try
        {
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedData(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
        app.Run();
    }
}