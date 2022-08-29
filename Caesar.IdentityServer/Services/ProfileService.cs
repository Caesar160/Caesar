namespace Caesar.IdentityServer.Services;

using System.Security.Claims;
using Application.Aggregates.Customers.Queries.GetClientById;
using Application.Exceptions;
using Common.Constants;
using Domain.Entities;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MediatR;

public class ProfileService : IProfileService
{
    private readonly ISender mediatr;

    public ProfileService(ISender mediatr)
    {
        this.mediatr = mediatr;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var id = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

        if (!long.TryParse(id, out var result))
        {
            throw new ArgumentException($"Invalid sub: {id}");
        }

        var user = context.Client.ClientId
            switch
            {
                //Add clients and handle functions here
                Constants.CaesarWebClient => await this.GetClient(result),
                _ => throw new ArgumentException("Invalid client")
            };

        context.AddRequestedClaims(context.Subject.Claims);

        var roleClaims = context.Subject.Claims.Where(x => x.Type == ClaimTypes.Role);

        context.IssuedClaims.AddRange(roleClaims);

        //TODO: Uncomment after user status implemented.
        //var statusClaim = context.Subject.Claims.FirstOrDefault(x => x.Type == "status");
        //if (statusClaim != null)
        //{
        //    context.IssuedClaims.Add(statusClaim);
        //}
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;

        return Task.CompletedTask;
    }

    private async Task<UserInfo> GetClient(long id)
    {
        var client = await this.mediatr.Send(new GetClientByIdQuery(id));

        if (client == null)
        {
            throw new NotFoundException(nameof(User), id);
        }

        return new UserInfo {Name = client.Name, Id = client.Id};
    }

    private class UserInfo
    {
        public long Id
        {
            get;
            init;
        }

        public string Name
        {
            get;
            init;
        }
    }
}
