namespace Caesar.IdentityServer;

using Common.Constants;
using IdentityServer4;
using IdentityServer4.Models;

public static class Configuration
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("Caesar", "Caesar API")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client()
            {
                ClientId = Constants.CaesarWebClient,
                AllowedGrantTypes = new List<string>() { "password" },
                Description = "Caesar web client API",

                ClientSecrets =
                {
                    new Secret("d1a444ed-6845-48b7-b0d5-855386de45ee".Sha256())
                },
                AccessTokenLifetime = 3600, 
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "CaesarApi",
                    "offline_access"
                },

                AllowOfflineAccess = true,
                AllowAccessTokensViaBrowser = true,
                UpdateAccessTokenClaimsOnRefresh = true,
                RequireConsent = false
            }
        };
}
