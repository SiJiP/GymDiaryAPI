using GymDiaryAPI.BusinessLayers;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.Helpers;
using GymDiaryAPI.Interfaces;
using GymDiaryAPI.Repositories;
using GymDiaryAPI.Repositories.Interfaces;
using GymDiaryAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace GymDiaryAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Configurations
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


            // Business Layers
            services.AddScoped<IAccountBl, AccountBl>();
            services.AddScoped<IUserBl, UserBl>();


            // Database
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Gym Diary API", Version = "1.0.0" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                swagger.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securityScheme, new[] { "Bearer" } }
                };

                swagger.AddSecurityRequirement(securityRequirement);

            });

            return services;
        }
    }
}
