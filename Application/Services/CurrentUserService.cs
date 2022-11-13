using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public string getNameCurrentUser()
    {
        return httpContextAccessor.HttpContext.User.Identity!.Name!;
    }

}

