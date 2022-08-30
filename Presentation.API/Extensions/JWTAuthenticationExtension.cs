namespace Caesar.Presentation.API.Extensions
{
    using System;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;

    internal static class JWTAuthenticationExtension
    {
        internal static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
                {
                    opts.Authority = configuration["Authority"];
                    opts.RequireHttpsMetadata = true;

                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = ClaimTypes.Role,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.FromSeconds(0)
                    };
                });

            return services;
        }
    }
}
