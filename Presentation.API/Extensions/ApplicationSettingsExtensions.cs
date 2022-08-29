namespace Caesar.Presentation.API.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Caesar.Settings;
    using Caesar.Constants;

    internal static class ApplicationSettingsExtensions
    {
        internal static IServiceCollection ConfigureApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StripeSettings>(configuration.GetSection(Constants.StripeSettings));
            return services;
        }
    }
}