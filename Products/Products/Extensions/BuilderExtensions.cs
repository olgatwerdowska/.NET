using Microsoft.AspNetCore.Builder;
using Products.Middleware;

namespace WebApplication.Extensions
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseElapsedTimeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ElapsedTimeMiddleware>();
        }
    }
}
}