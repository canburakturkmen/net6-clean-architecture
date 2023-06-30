using Microsoft.EntityFrameworkCore;
using TicketManagement.Api.Services;
using TicketManagement.Api.Utility;
using TicketManagement.Application;
using TicketManagement.Application.Contracts;
using TicketManagement.Infrastructure;
using TicketManagement.Persistence;

namespace TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistanceServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open",builder => builder.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Management API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.MapControllers();

            return app;
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ticket Management API"
                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var context = scope.ServiceProvider.GetService<TicketDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {
                //add logging here later on
            }
        }
    }
}
