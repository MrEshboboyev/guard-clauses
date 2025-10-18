using GuardClauses;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
    config.PostProcess = (settings) =>
    {
        settings.Info.Title = "Guard Clauses Demo API";
        settings.Info.Version = "v1";
        settings.Info.Description = "A demonstration of guard clauses in .NET with a practical web API";
    });

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();