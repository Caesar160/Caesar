namespace Caesar.Presentation.API.Extensions
{
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using NSwag;
    using NSwag.Generation.Processors.Security;

    public static class OpenAPIExtensions
    {
        internal static IServiceCollection AddOpenAPI(this IServiceCollection services)
        {
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "DefyED API";
                configure.AllowReferencesWithProperties = true;
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            return services;
        }
    }
}
