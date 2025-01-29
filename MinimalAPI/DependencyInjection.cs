using Microsoft.EntityFrameworkCore;
using MinimalAPI.Application.Interface;
using MinimalAPI.Application.Service;
using MinimalAPI.Infra.Data;
using MinimalAPI.Infra.Repository;

namespace MinimalAPI;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<BaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<IMinimalService, MinimalService>();
        services.AddTransient<IMinimalRepository, MinimalRepository>();

        return services;
    }
}