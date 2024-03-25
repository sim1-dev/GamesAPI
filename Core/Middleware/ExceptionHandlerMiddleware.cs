using GamesAPI.Core.Models;

namespace GamesAPI.Core.Middleware;

public class ExceptionHandlerMiddleware {
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext){
        try {
            await _next(httpContext);
        } catch (Exception e) {
            await HandleException(e, httpContext);
        }
    }

    private async Task HandleException(Exception e, HttpContext httpContext) {
        this._logger.LogError(e, "ExceptionHandlerMiddleware");

        httpContext.Response.StatusCode = 500;

        await httpContext.Response.WriteAsJsonAsync(new Response {   
            Success = false,
            Message = "An unexpected error has occurred. Please contact the system administrator"
        });
    }
}

public static class ExceptionHandlerMiddlewareExtensions {
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder) {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}