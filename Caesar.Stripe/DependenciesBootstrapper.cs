namespace Caesar.Stripe;

using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

public static class DependenciesBootstrapper
{
    public static IServiceCollection AddStripe(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStripeService, StripeService>();
        return services;
    }
}
