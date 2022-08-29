namespace Caesar.Presentation.API.Extensions;

using Common.Constants;
using Settings;

internal static class ApplicationSettingsExtensions
{
    internal static IServiceCollection ConfigureApplicationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<StripeSettings>(configuration.GetSection(Constants.StripeSettings));
        return services;
    }
}
