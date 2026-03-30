namespace Git_MVC_PRO.Middleware
{
    public static class RateLimitingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomRateLimiting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitingMiddleware>();
        }
    }
}