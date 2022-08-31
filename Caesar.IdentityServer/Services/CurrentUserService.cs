namespace Caesar.IdentityServer.Services;

using System.Security.Claims;
using Application.Interfaces;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public long UserId =>
        long.Parse(this.httpContextAccessor.HttpContext?.User?.FindFirstValue("sub"));
}
