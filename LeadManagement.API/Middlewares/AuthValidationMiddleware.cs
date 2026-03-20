using System.Text;
using System.Text.Json;
using LeadManagement.Domain.Aggregates;

namespace LeadManagement.API.Middlewares
{
    public class AuthValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthValidationMiddleware> _logger;

        public AuthValidationMiddleware(RequestDelegate next, ILogger<AuthValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, UserAggregate userAggregate)
        {
            var token = context.Request.Headers["x-id-token"].FirstOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Missing token.");
                return;
            }

            var email = ExtractEmailFromToken(token);

            if (string.IsNullOrEmpty(email))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid or missing email claim.");
                return;
            }

            userAggregate.SetEmail(email);

            await _next(context);
        }

        private string? ExtractEmailFromToken(string token)
        {
            try
            {
                var parts = token.Split('.');
                if (parts.Length != 3)
                    return null;

                var payload = parts[1];
                var paddedPayload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
                var decodedBytes = Convert.FromBase64String(paddedPayload.Replace('-', '+').Replace('_', '/'));
                var json = Encoding.UTF8.GetString(decodedBytes);

                using var document = JsonDocument.Parse(json);

                if (document.RootElement.TryGetProperty("email", out var emailElement))
                {
                    return emailElement.GetString();
                }

                return null;
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(ex, "Failed to decode JWT token payload: invalid Base64 format.");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogWarning(ex, "Failed to parse JWT token payload: invalid JSON.");
                return null;
            }
        }
    }
}
