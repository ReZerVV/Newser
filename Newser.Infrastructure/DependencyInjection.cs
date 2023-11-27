using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newser.Application.Common.Authorization;
using Newser.Application.Common.Persistence;
using Newser.Application.Common.Services;
using Newser.Infrastructure.Authorization;
using Newser.Infrastructure.Persistence;
using Newser.Infrastructure.Services;

namespace Newser.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthorization(config);

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPostRepository, PostRepository>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
        });
        return services;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind(JwtSettings.SectionName, jwtSettings);

        services.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });
        
        return services;
    }
}