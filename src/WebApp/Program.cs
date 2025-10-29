using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MathService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/add/{a:int}/{b:int}", (int a, int b, MathService math) =>
{
    return Results.Ok(new { sum = math.Add(a, b) });
});

app.Run();

public partial class Program { }
