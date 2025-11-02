namespace Weather.API.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string ApiKey = "X-API-Key";

        public APIKeyMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKey, out var inputKeyValue))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsJsonAsync(
                    new 
                    {
                        error = "Unauthorized",
                        message = "API key not found."
                    });
            }
            else
            {
                var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

                // For demo, key is stored in appsettings.
                // For production we would probably use Azure Keyvault or something similar.
                var secretValue = appSettings.GetValue<string>(ApiKey);

                if (secretValue != null && !secretValue.Equals(inputKeyValue))
                {
                    context.Response.StatusCode = 401;

                    await context.Response.WriteAsJsonAsync(
                        new
                        {
                            error = "Unauthorized",
                            message = "The client was not authorized to access the API."
                        });
                }
            }

            await _requestDelegate(context);
        }
    }
}
