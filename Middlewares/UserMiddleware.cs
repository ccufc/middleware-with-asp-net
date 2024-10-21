using System.Net.Mime;

namespace Api.Middlewares;

public class UserMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        if (path is not null && path.Contains("/user/me"))
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await context.Response.WriteAsJsonAsync(new
            {
                success = false,
                message = "Unauthorized"
            });
            return;
        }

        await _next(context);
    }
}
