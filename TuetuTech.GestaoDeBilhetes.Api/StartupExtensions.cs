﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TuetuTech.GestaoDeBilhetes.Api.Services;
using TuetuTech.GestaoDeBilhetes.Api.Utility;
using TuetuTech.GestaoDeBilhetes.Application;
using TuetuTech.GestaoDeBilhetes.Application.Contracts;
using TuetuTech.GestaoDeBilhetes.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Persistence;
namespace TuetuTech.GestaoDeBilhetes.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            builder.Services.AddCors(op =>
            {
                op.AddPolicy("Open", builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TuetuTech Gestão de Bilhetes API");
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("Open");
            app.MapControllers();
            return app;
        }
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TuetuTech Gestão de Bilhetes API"
                });
                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<TuetuTechDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
