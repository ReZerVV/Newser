using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newser.Application.Commands.Authorization.Login;
using Newser.Application.Commands.Authorization.Register;

namespace Newser.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => 
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        //services.AddTransient<IRequestHandler<RegisterRequest, RegisterResponse>, RegisterHandler>();
        //services.AddTransient<IRequestHandler<LoginRequest, LoginResponse>, LoginHandler>();
        return services;
    }
}