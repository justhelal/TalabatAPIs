using Domain.Contracts;
using E_Commerce.Api.CustomMiddlewares;
using E_Commerce.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Data.Seeding;
using Persistence.Repositories;
using Service.Abstraction;
using Service.Configurations;
using Service.Services;
using Shared.ErrorModels;

namespace E_Commerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerCollection();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddWebApplicationServices();

            //----------------------------------------------------

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            await app.InitializeDatabase();

            app.UseCustomMiddlewares();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            
        }
    }
}
