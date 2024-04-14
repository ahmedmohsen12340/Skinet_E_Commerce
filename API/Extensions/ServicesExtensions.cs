﻿using API.Errors;
using Core;
using InfraStructure;
using InfraStucture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<StoreDbContext>((option) =>
            {
                option.UseSqlite(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(m => m.Value.Errors.Count > 0)
                    .SelectMany(m => m.Value.Errors)
                    .Select(e => e.ErrorMessage).ToArray();

                    var validationErrors = new ApiValidationError(errors);

                    return new BadRequestObjectResult(validationErrors);
                };
            });


            return services;
        }
    }
}