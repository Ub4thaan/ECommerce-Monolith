namespace Infrastructure;

using Application.Repositories;
using AutoMapper.Extensions.ExpressionMapping;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(cfg =>
        {
            cfg.AddExpressionMapping();
            cfg.AddMaps(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}
