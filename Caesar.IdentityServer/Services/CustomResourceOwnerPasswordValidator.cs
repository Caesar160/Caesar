namespace Caesar.IdentityServer.Services;

using System.Security.Claims;
using Application.Aggregates.Customers.Queries.GetClientByEmail;
using Common.Constants;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using MediatR;

public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly ISender mediator;

    public CustomResourceOwnerPasswordValidator(ISender mediator)
    {
        this.mediator = mediator;
    }

    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        if (context.Request.ClientId != Constants.CaesarWebClient)
        {
            throw new ArgumentException("Invalid client");
        }

        var user = await this.mediator.Send(new GetClientByEmailQuery
        {
            Email = context.UserName, Password = context.Password
        });

        if (user == null)
        {
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest,
                "Your credentials are incorrect. Please try again or reset your password");
            return;
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, Char.ToLowerInvariant(user.Role[0]) + user.Role.Substring(1))
        };

        context.Result = new GrantValidationResult(user.Id.ToString(), "password", claims);
    }
}
