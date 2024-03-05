/* fulfilled when User
    - has admin role
        OR
    - has any Developer accounts which belongs to the Software House that created the specific Game
*/

using System.Security.Claims;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Core.Middleware;

public class IsReviewerUserRequirement : IAuthorizationRequirement {
    public IsReviewerUserRequirement() {
        
    }
}

public class IsReviewerUserHandler : AuthorizationHandler<IsReviewerUserRequirement> {
    private readonly BaseContext _db;

    private const string _CLASS_NAME = "IsReviewerUserHandler";

    public IsReviewerUserHandler(BaseContext db) {
        this._db = db;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsReviewerUserRequirement requirement) {

        if(context.Resource is not HttpContext httpContext) {
            context.Fail();
            return Task.CompletedTask;
        }

        RouteData? routeData = httpContext.GetRouteData();

        if(routeData is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: No route data specified"));
            return Task.CompletedTask;
        }

        object? unparsedReviewIdFromRoute = routeData.Values["id"];

        if(unparsedReviewIdFromRoute is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: No game id provided"));
            return Task.CompletedTask;
        }

        string? reviewIdFromRoute = unparsedReviewIdFromRoute.ToString();

        if (reviewIdFromRoute is null) {
            context.Fail();
            return Task.CompletedTask;
        }

        int reviewId = Convert.ToInt32(reviewIdFromRoute);

        int userId = Convert.ToInt32(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
        
        // get game from gameId
        Review? review = _db.Reviews
            .Include(review => review.ReviewerUser)
        .FirstOrDefault(review => review.Id == reviewId);

        if(review is null) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: Review not found"));
            return Task.CompletedTask;
        }


        // check if the user is a reviewer of the review
        if(review.ReviewerUser.Id != userId) {
            context.Fail(new AuthorizationFailureReason(this, $"{_CLASS_NAME}: User is not the original reviewer"));
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}