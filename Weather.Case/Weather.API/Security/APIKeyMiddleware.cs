namespace Weather.API.Security
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public APIKeyMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
