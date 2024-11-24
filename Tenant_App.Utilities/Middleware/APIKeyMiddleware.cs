using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Tenant_App.Utilities.Middleware
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public APIKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                //Let's check if this is an API Call
                if (context.Request.Headers.Keys.Contains("ApiKey", StringComparer.InvariantCultureIgnoreCase))
                {
                    //Validate the Supplied API Key
                    //Validate it
                    var headerKey = context.Request.Headers["ApiKey"].FirstOrDefault();
                    await ValidateAPIKey(context, _next, headerKey);
                }
                else
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync("API Key is missing");
                    await _next.Invoke(context);

                }
            }
            else
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("BadRequest");
                await _next.Invoke(context);

            }
        }


        private async Task ValidateAPIKey(HttpContext context, RequestDelegate next, string key)
        {
            //validate Key hear
            var valid = false;
            if (!valid)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
            }
            else
            {
                //await next.n;
            }
        }


    }

    #region ExtensionMethod
    public static class APIKeyMiddlewareExtension
    {
        public static IApplicationBuilder ApplyAPIKeyMiddlewareExtension(this IApplicationBuilder app)
        {
            app.UseMiddleware<APIKeyMiddleware>();
            return app;
        }
    }
    #endregion
}
