namespace Caesar.Stripe
{
    using Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Services;

    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddStripe(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStripeService, StripeService>();
            return services;
        }
    }
}
