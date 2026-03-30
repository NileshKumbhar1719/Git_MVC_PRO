using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;

namespace Git_MVC_PRO.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly ConcurrentDictionary<string, (int Count, DateTime Date)> _requests
            = new();

        private readonly int _limit = 3;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();
            var method = context.Request.Method.ToUpper();

            // Apply only for Create POST
            if (path.Contains("/departments/create") && method == "POST")
            {
                var user = context.User.Identity?.Name
                           ?? context.Connection.RemoteIpAddress?.ToString()
                           ?? "anonymous";

                var today = DateTime.UtcNow.Date;

                var entry = _requests.GetOrAdd(user, (0, today));

                if (entry.Date != today)
                {
                    _requests[user] = (1, today);
                }
                else
                {
                    if (entry.Count >= _limit)
                    {
                        // ✅ Instead of WriteAsync, set a flag
                        context.Items["RateLimitExceeded"] = true;

                        // Call next middleware (controller will handle redirect)
                        await _next(context);
                        return;
                    }

                    _requests[user] = (entry.Count + 1, entry.Date);
                }
            }

            await _next(context);
        }
    }
}