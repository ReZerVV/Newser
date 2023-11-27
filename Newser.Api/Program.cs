using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newser.Api.Controllers.Common.Errors;
using Newser.Application;
using Newser.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, NewserProblemDetailsFactory>();
}
var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
}
app.Run();
