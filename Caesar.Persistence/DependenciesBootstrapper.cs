namespace Caesar.Domain;

using Application.Interfaces;
using Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

public static class DependenciesBootstrapper
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>(ConfigurationStrings.ConfigSection.UseInMemoryDatabase))
        {
            services.AddDbContext<CaesarDbContext>(options =>
                options.UseInMemoryDatabase(Constants.InMemoryDbName));
        }
        else
        {
            services.AddDbContext<CaesarDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(ConfigurationStrings.ConfigSection.DefaultConnectionName),
                    b => b.MigrationsAssembly(typeof(CaesarDbContext).Assembly.FullName));

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }

        services.AddScoped<ICaesarDbContext>(provider => provider.GetService<CaesarDbContext>()!);

        return services;
    }
}
