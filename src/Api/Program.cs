using Microsoft.OpenApi.Models;
using Domain.DependencyInjection;
using Infrastructure.DependencyInjection;
using Domain.Configuration;
using Api.Middlewares;


var builder = WebApplication.CreateBuilder(args);

var logger = LoggerFactory.Create(x => x.AddConsole()).CreateLogger("category");

builder.Services.AddSingleton(logger);

builder.Logging.AddConsole();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleApi", Version = "v1" });
});

DependencyInjectionDomain.Add(builder.Services);

DependencyInjectionInfrastructure.Add(builder.Services);

builder.Services.AddSingleton(builder.Configuration.GetSection("FileReaderOptions").Get<FileReaderOptions>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleApi v1"));
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandler>();

app.Run();

namespace Api
{
    public partial class Program
    {

    }
}