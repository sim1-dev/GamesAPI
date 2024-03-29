/* fulfilled when User
    - has admin role
        OR
    - has any Developer accounts which belongs to the Software House that created the specific Game
*/

using System.Security.Claims;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using GamesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Middleware;

public class IsGameDeveloperRequirement : IAuthorizationRequirement {
    public IsGameDeveloperRequirement() {
        
    }
}

// TODO rename to IsGameDeveloperOrAdminHandler
public class IsGameDeveloperHandler : AuthorizationHandler<IsGameDeveloperRequirement> {
    private readonly BaseContext _db;

    private const string _CLASS_NAME = "IsGameDeveloperHandler";

    public IsGameDeveloperHandler(BaseContext db) {
        this._db = db;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsGameDeveloperRequirement requirement) {
        if(context.Resource is not HttpContext httpContext) {
            context.Fail();
            return Task.CompletedTask;
        }

        if(httpContext.User.IsInRole("admin")){
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        RouteData? routeData = httpContext.GetRouteData();

        if(routeData is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: No route data specified"));
            return Task.CompletedTask;
        }

        object? unparsedGameIdFromRoute = routeData.Values["id"] ?? routeData.Values["gameId"];

        if(unparsedGameIdFromRoute is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: No game id provided"));
            return Task.CompletedTask;
        }

        string? gameIdFromRoute = unparsedGameIdFromRoute.ToString();

        if (gameIdFromRoute is null) {
            context.Fail();
            return Task.CompletedTask;
        }

        int gameId = Convert.ToInt32(gameIdFromRoute);

        int userId = Convert.ToInt32(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
        
        // get game from gameId
        Game? game = _db.Games.FirstOrDefault(g => g.Id == gameId);

        if(game is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: Game not found"));
            return Task.CompletedTask;
        }
    
        // check if the user has developer accounts that belong to the same softwarehouse as the one in the target game
        List<Developer> developerAccounts = _db.Developers.Where(developer => EF.Property<int?>(developer, "SoftwareHouseId") == game.SoftwareHouseId && developer.UserId == userId).ToList();

        if(developerAccounts.Count == 0) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: User doesn't belong to game's software house"));
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}