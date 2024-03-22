using System.Security.Claims;

namespace GamesAPI.Core.Services;

public class UserContextService {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor) {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAdmin() {
        return _httpContextAccessor.HttpContext?.User.IsInRole("Admin") ?? false;
    }
    
    public int GetUserId() {
        string? idClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(idClaim is null)
            throw new ArgumentException("User not authenticated");

        int userId = Convert.ToInt32(idClaim);

        return userId;
    }
}