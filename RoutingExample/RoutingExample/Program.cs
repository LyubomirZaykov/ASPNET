var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//enable routing
app.UseRouting();
app.Use(async (context, next) =>
{
    Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");

    }

    await next(context);
});
app.UseEndpoints(endpoints =>
{
    //add your end points
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
       string? fileName=Convert.ToString(context.Request.RouteValues["filename"]);
       string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync("In files - {filename - {extension}}");
    });
    endpoints.Map("employee/profile/{employeename}", async (context) =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync("In files - {employeeName - {employeeName}}");

    });


});
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
