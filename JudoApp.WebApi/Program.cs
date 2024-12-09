namespace JudoApp.WebApi
{
    using Microsoft.EntityFrameworkCore;

    using Data.Models;
    using JudoApp.Services.Data.Interfaces;
    using Web.Infrastructure.Extensions;
    using Services.Mapping;
    using JudoApp.Web.ViewModels;
    using JudoApp.Web.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;
            string? judoWebAppOrigin = builder.Configuration.GetValue<string>("Client Origins:JudoWebApp");

            // Add services to the container.
            builder.Services
                .AddDbContext<JudoDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(cfg =>
            {
                cfg.AddPolicy("AllowAll", policyBld =>
                {
                    policyBld
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });

            if (!String.IsNullOrWhiteSpace(judoWebAppOrigin))
            {
                cfg.AddPolicy("AllowMyServer", policyBld =>
                {
                    policyBld
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(judoWebAppOrigin);
                });
            }
        });

            builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
            builder.Services.RegisterUserDefinedServices(typeof(IClubService).Assembly);

            var app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            if (!String.IsNullOrWhiteSpace(judoWebAppOrigin))
            {
                app.UseCors("AllowMyServer");
            }

            app.MapControllers();

            app.Run();
        }
    }
}
