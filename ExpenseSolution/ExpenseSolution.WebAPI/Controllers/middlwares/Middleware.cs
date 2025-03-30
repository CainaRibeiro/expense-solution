using ExpenseSolution.Utils.Interfaces;

namespace ExpenseSolution.WebAPI.Controllers.middlwares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private readonly List<string> bypassAuthRoutes = [
            "/api/user/create",
            "/api/user/login",
            "/swagger",
            "/swagger/index.html",
            "/swagger/v1/swagger.json"
            ];

        public async Task Invoke(HttpContext httpContext, IJwt jwt)
        {
            var path = httpContext.Request.Path;

            if (bypassAuthRoutes.Any(r => path.StartsWithSegments(r, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(httpContext);
                return;
            }

            var token = httpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                httpContext.Response.StatusCode = 403;
                await httpContext.Response.WriteAsync("Token not found");
                return;
            }

            if (!jwt.ValidateToken(token))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Invalid token");
                return;
            }
            await _next(httpContext);
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
