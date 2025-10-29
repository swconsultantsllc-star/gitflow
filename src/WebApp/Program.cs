using WebApp.Services;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();           // <- built-in
builder.Services.AddSingleton<MathService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // <- built-in
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/add/{a:int}/{b:int}", (int a, int b, MathService math) =>
{
    return Results.Ok(new { sum = math.Add(a, b) });
});

app.Run();

public partial class Program { }
