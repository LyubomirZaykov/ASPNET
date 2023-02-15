using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddlewares
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom second middleware starts here!\n");
            await next(context);
            await context.Response.WriteAsync("My custom second middleware ends here!\n");

        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware
            (this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
