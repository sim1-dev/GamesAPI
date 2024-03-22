using GamesAPI.Core.Models;
using Newtonsoft.Json;

namespace GamesAPI.Core.Middleware;
public class ResponseWrapperMiddleware {
    private readonly RequestDelegate _next;
    public ResponseWrapperMiddleware(RequestDelegate next) {
        _next = next; 
    }

    public async Task Invoke(HttpContext context) {
        var originalBody = context.Response.Body;
        using (var memStream = new MemoryStream()) {
            context.Response.Body = memStream;
            await _next(context);

            memStream.Seek(0, SeekOrigin.Begin);

            if (context.Response.ContentType != null &&
                context.Response.ContentType.StartsWith("application/json") &&
                context.Response.StatusCode >= 200 &&
                context.Response.StatusCode < 300)
            {
                var responseBody = await FormatResponse(memStream);
                context.Response.ContentType = "application/json";
                context.Response.Body = originalBody;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new Response {   
                    Success = true,
                    Data = responseBody
                }));
            } else {
                await memStream.CopyToAsync(originalBody);
                context.Response.Body = originalBody;
            }
        }
    }

    private async Task<object?> FormatResponse(Stream responseStream) {
        using var reader = new StreamReader(responseStream);
        var body = await reader.ReadToEndAsync();
        return JsonConvert.DeserializeObject(body);
    }
}