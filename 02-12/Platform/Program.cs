using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("routing", async context => {
    await context.Response.WriteAsync("request was routed");
});
app.MapGet("capital/uk", new Capital().Invoke);
app.MapGet("population/paris", new Population().Invoke);

app.Run();
