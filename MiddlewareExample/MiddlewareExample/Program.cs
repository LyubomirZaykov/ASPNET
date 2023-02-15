using MiddlewareExample.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello First Middleware \n");
    await next(context);
});
//middleware 2

//
//app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello Third Middleware \n");

});
app.Run();
